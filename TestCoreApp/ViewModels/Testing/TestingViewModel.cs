using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
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
using TestCoreApp.Data;
using TestCoreApp.Services.Navigation;
using TestCoreApp.Services.Settings;

namespace TestCoreApp.ViewModels.Testing
{
    public class TestingViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private TestingViewModel()
        {                    
            ScannedDevices = new ObservableCollection<Device>();

            IsWorking = false;      

            StartOrStopCommand = new RelayCommand(StartOrStop);
            CreateProtocolCommand = new RelayCommand<object>(CreateProtocol, CreateProtocolCanExecute, true);
            OpenProtocolCommand = new RelayCommand<Protocol>(OpenProtocol);
        }

        public TestingViewModel(IFrameNavigationService navigator, TestDbContext context, SettingsService settings) : this()
        {
            this.navigator = navigator;
            this.context = context;

            this.context.Protocols.Include(i => i.Devices).Where(p => p.IsClosed == false).Load();

            Protocols = context.Protocols.Local.ToObservableCollection();

            DevicesPath = settings.Settings.DevicesPath;
            ResponsePath = settings.Settings.ResponsePath;
            ProtocolPath = settings.Settings.ProtocolPath;

            devicesFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(DevicesPath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(DevicesPath),
                EnableRaisingEvents = true
            };

            responseFileWatcher = new FileSystemWatcher(Path.GetDirectoryName(ResponsePath))
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = Path.GetFileName(ResponsePath),
                EnableRaisingEvents = true
            };
        }

        private readonly TestDbContext context;
        private readonly IFrameNavigationService navigator;
        private readonly FileSystemWatcher responseFileWatcher;
        private readonly FileSystemWatcher devicesFileWatcher;

        private void StartOrStop()
        {
            if (IsWorking)
            {
                devicesFileWatcher.Changed -= AddScannedDevicesFromFile;
                responseFileWatcher.Changed -= UpdateScannedDevicesFromResponse;
            }
            else
            {
                devicesFileWatcher.Changed += AddScannedDevicesFromFile;
                responseFileWatcher.Changed += UpdateScannedDevicesFromResponse;
            }

            IsWorking = !IsWorking;
        }

        private void OpenProtocol(Protocol protocol)
        {
            navigator.NavigateTo("Protocol", "Protocol", protocol);
        }

        private void CreateProtocol(object selectedItems)
        {
            IList items = (IList)selectedItems;
            List<Device> devices = new List<Device>(items.Cast<Device>());

            for (int i = 0; i < devices.Count(); i++)
            {
                ScannedDevices.Remove(devices[i]);
            }
            items.Clear();

            Protocol protocol = new Protocol();

            protocol.Tester = "Ендовицкий И.Н.";
            protocol.DateTime = DateTime.Now;
            protocol.Devices = new ObservableCollection<Device>(devices);

            context.Attach(protocol);
            context.SaveChanges();

            Services.Excel.Export.ProtocolToXlsx(ProtocolPath, protocol);
        }

        private void AddScannedDevicesFromFile(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            MatchCollection matches;

            using (StreamReader streamReader = File.OpenText(DevicesPath))
            {
                Regex regex = new Regex(@"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAddr:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?");
                matches = regex.Matches(streamReader.ReadToEnd());
            }

            int i = 1;

            App.Current.Dispatcher.Invoke((Action)delegate
            {
                foreach (Match match in matches)
                {
                    ScannedDevices.Add(new Device
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
            });
        }



        private void UpdateScannedDevicesFromResponse(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);

            string text;

            using (StreamReader sr2 = File.OpenText(ResponsePath))
            {
                text = sr2.ReadToEnd();
            }

            Regex regex = new Regex(@"(?<DevEui>\w{16})\s(?<Snr>\d+\.?\d*)\s(?<PackageType>\w{2})(?<FactoryNumber>\w{8})(?<CurrentTime>\w{8})(?<Model>\w{2})(?<Phases>\w{2})(?<Tarrifs>\w{2})(?<Rellay>\w{2})(?<ReleaseDate>\w{8})(?<SoftwareVersion>\w{8})(?<Indications>\w{8})(?<Temperature>\w{2})(?<Stasus>\w{8})(?<Reason>\w{4})(?<UUID>\w{4})(?<Unused>.*)");

            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Device device = ScannedDevices.Where(d => d.DevEui == match.Groups["DevEui"].Value.Trim()).LastOrDefault();

                if (device != null)
                {
                    device.Snr = match.Groups["Snr"].Value.Trim();
                    device.FactoryNumber = Convert.ToUInt64(ReverseWord(match.Groups["FactoryNumber"].Value.Trim()), 16).ToString();
                    DevideBy10((Convert.ToUInt64(ReverseWord(match.Groups["SoftwareVersion"].Value.Trim()), 16)).ToString()); //device.SoftwareVersion = "1.1";
                    if (device.Snr != null)
                    {
                        device.Notes += "1-й пакет";
                    }
                    if ((Convert.ToUInt32(ReverseWord(match.Groups["FactoryNumber"].Value.Trim()), 16) < 2800000000) || (Convert.ToUInt32(ReverseWord(match.Groups["FactoryNumber"].Value.Trim()), 16) > 2800001000))
                    {
                        device.Notes += "Номер?";
                    }
                }
            }
        }

        private string ReverseWord(string s)
        {
            int length = s.Length;
            string result = string.Empty;
            for (int i = 1; i < length; i += 2)
            {
                result = result + s[length - i - 1] + s[length - i];
            }
            return result;
        }

        private string DevideBy10(string s)
        {
            int length = s.Length;
            string result = string.Empty;
            for (int i = 0; i < length - 1; ++i)
            {
                result += s[i];
            }
            result += "." + s[length - 1];
            return result;
        }

        public bool CreateProtocolCanExecute(object obj)
        {
            if (((IList)obj)?.Count == 0)
            {
                return false;
            }

            return true;
        }

        public ICommand StartOrStopCommand { get; private set; }
        public ICommand CreateProtocolCommand { get; private set; }
        public ICommand OpenProtocolCommand { get; private set; }

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

        private ObservableCollection<Device> scannedDevices;
        public ObservableCollection<Device> ScannedDevices
        {
            get => scannedDevices;
            set => Notify(ref scannedDevices, value);
        }

        private bool isWorking;
        public bool IsWorking
        {
            get => isWorking;
            set => Notify(ref isWorking, value);
        }
    }
}
