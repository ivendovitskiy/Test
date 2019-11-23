using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestApplication.Data;

namespace TestApplication.ViewModels.Testing
{
    public class TestingViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public TestingViewModel()
        {
            context = new TestDbContext();
            context.Protocols.Include(i => i.Devices).Where(p => p.IsClosed == false).Load();

            Protocols = context.Protocols.Local.ToObservableCollection();

            //DevicesPath = @"C:\Users\LifarenkoKO\Desktop\Devices.txt";
            //ResponsePath = @"C:\Users\LifarenkoKO\Desktop\Otvet.txt";
            //ProtocolPath = @"D:\StendLoRa\stend\Прочие файлы\С номерами";

            IsWorking = false;

            //DevicesPath = @"C:\Users\LifarenkoKO\Desktop\Test\Devices.txt";
            //ProtocolPath = @"C:\Users\LifarenkoKO\Desktop\";

            //DevicesPath = @"C:\Users\Morri\Desktop\Test\Прочие файлы\Протокол №56.txt";
            //ProtocolPath = @"C:\Users\Morri\Desktop;

            DevicesPath = @"C:\Users\Иван\Desktop\Test\Прочие файлы\devices.txt";
            ResponsePath = @"C:\Users\Иван\Desktop\Test\Прочие файлы\Otvet.txt";
            ProtocolPath = @"C:\Users\Иван\Desktop\Test\Прочие файлы";

            //watcher = new FileSystemWatcher(@"C:\Users\Morri\Desktop\Test\Прочие файлы\")
            //watcher = new FileSystemWatcher(@"C:\Users\Иван\Desktop\Test\Прочие файлы\")
            //responseFileWatcher = new FileSystemWatcher(@"C:\Users\LifarenkoKO\Desktop\")
            //{
            //    NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
            //    Filter = "Otvet.txt",
            //    EnableRaisingEvents = true
            //};

            devicesFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(DevicesPath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(DevicesPath),
                EnableRaisingEvents = true
            };

            responseFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(DevicesPath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(ResponsePath),
                EnableRaisingEvents = true
            };


            ScanCommand = new RelayCommand(Scan);
            StartOrStopCommand = new RelayCommand(StartOrStop);
        }

        private readonly TestDbContext context;
        private readonly FileSystemWatcher responseFileWatcher;
        private readonly FileSystemWatcher devicesFileWatcher;
        public ICommand ScanCommand { get; private set; }
        public ICommand StartOrStopCommand { get; private set; }

        private void StartOrStop()
        {
            if (IsWorking)
            {
                devicesFileWatcher.Changed -= AddProtocolFromFile;
                responseFileWatcher.Changed -= UpdateDevicesFromResponse;
            }
            else
            {
                devicesFileWatcher.Changed += AddProtocolFromFile;
                responseFileWatcher.Changed += UpdateDevicesFromResponse;
            }

            IsWorking = !IsWorking;
        }

        private void AddProtocolFromFile(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            MatchCollection matches;

            using (StreamReader streamReader = File.OpenText(DevicesPath))
            {
                Regex regex = new Regex(@"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAddr:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?");
                matches = regex.Matches(streamReader.ReadToEnd());
            }

            if (matches.Count > 24)
            {
                throw new Exception("Отсканируйте не больше 24 сканеров");
            }
            else if (matches.Count == 0)
            {
                throw new Exception("Отсканируйте хотя бы один сканер");
            }
            else
            {
                Protocol protocol = new Protocol
                {
                    DateTime = DateTime.Now,
                    Devices = new ObservableCollection<Device>()
                };

                int i = 1;

                foreach (Match match in matches)
                {
                    protocol.Devices.Add(new Device
                    {
                        Index = i,
                        DevName = match.Groups["DevName"].Value.Trim(),
                        DevEui = match.Groups["DevEui"].Value.Trim(),
                        AppEui = match.Groups["AppEui"].Value.Trim(),
                        AppKey = match.Groups["AppKey"].Value.Trim(),
                        //DevAdd = int.Parse(match.Groups["DevAdd"].Value.Trim()).ToString("X8"),
                        DevAdd = match.Groups["DevAdd"].Value.Trim(),
                        AppSKey = match.Groups["AppSKey"].Value.Trim(),
                        NwkSKey = match.Groups["NwkSKey"].Value.Trim()
                    });

                    i++;
                }

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    context.Attach(protocol);
                    context.SaveChanges();
                });
            }
        }

        private void UpdateDevicesFromResponse(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            string text;

            using (StreamReader sr2 = File.OpenText(ResponsePath))
            {
                text = sr2.ReadToEnd();
            }

            Regex regex = new Regex(@"(?<DevEui>\w{16})\s(?<Snr>\d+\.?\d*)\s(?<PackageType>\w{2})(?<FactoryNumber>\w{8})(?<Time>\w{8})(?<Unused>.*)");

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Device device = context.Devices.Where(d => d.DevEui == match.Groups["DevEui"].Value.Trim()).FirstOrDefault();

                if (device != null)
                {
                    device.Snr = match.Groups["Snr"].Value.Trim();
                    device.FactoryNumber = Convert.ToUInt32(reverseWord(match.Groups["FactoryNumber"].Value.Trim(), match.Groups["FactoryNumber"].Value.Trim().Length), 16).ToString();
                    //MessageBox.Show(match.Groups["FactoryNumber"].Value.Trim().Length.ToString()); // проверочка
                    context.SaveChanges();
                }
            }
        }

        [Obsolete("Не использовать")]
        private void Scan()
        {
            try
            {
                Services.Excel.Export.ProtocolToXlsx(ProtocolPath, Protocol);

                //File.WriteAllText(DevicesPath, String.Empty);

                MessageBox.Show("Протокол успешно создан");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string responsePath;
        public string ResponsePath
        {
            get => responsePath;
            set => Notify(ref responsePath, value);
        }

        private string devicesPath;
        public string DevicesPath
        {
            get => devicesPath;
            set => Notify(ref devicesPath, value);
        }

        private string protocolPath;
        public string ProtocolPath
        {
            get => protocolPath;
            set => Notify(ref protocolPath, value);
        }

        private ObservableCollection<Protocol> protocols;
        public ObservableCollection<Protocol> Protocols
        {
            get => protocols;
            set => Notify(ref protocols, value);
        }

        private bool isWorking;
        public bool IsWorking
        {
            get => isWorking;
            set => Notify(ref isWorking, value);
        }

        private Protocol protocol;
        public Protocol Protocol
        {
            get => protocol;
            set => Notify(ref protocol, value);
        }

        public string reverseWord (string s, int length)
        {
            string result = "";
            for (int i = 1; i < length; i += 2)
            {
                result = result + s[length - i - 1] + s[length - i];
            }
            return result;
        }

    }
}
