using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestApplication.Data;

namespace TestApplication.ViewModels.Testing
{
    public class TestingViewModel : ViewModelBase
    {
        public TestingViewModel()
        {
            context = new TestDbContext();

            //DevicesPath = @"D:\Стенд LoRa\ПО Вега\v1.2.4\Devices.txt";
            //ProtocolPath = @"D:\Стенд LoRa\stand\";

            DevicesPath = @"C:\Users\LifarenkoKO\Desktop\Test\Devices.txt";
            ProtocolPath = @"C:\Users\LifarenkoKO\Desktop\";

            SetDevicesPathCommand = new RelayCommand(SetDevicesPath);
            SetProtocolPathCommand = new RelayCommand(SetProtocolPath);
            ScanCommand = new RelayCommand(Scan);
        }

        private readonly TestDbContext context;

        public ICommand SetDevicesPathCommand { get; private set; }
        public ICommand SetProtocolPathCommand { get; private set; }
        public ICommand ScanCommand { get; private set; }

        private void SetProtocolPath()
        {

        }

        private void SetDevicesPath()
        {

        }

        private void Scan()
        {
            try
            {
                using (StreamReader sr = File.OpenText(DevicesPath))
                {
                    string s = @"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAdd:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?";
                    Regex regex = new Regex(s);

                    string text = sr.ReadToEnd();
                    MatchCollection matches = regex.Matches(text);

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
                        Protocol = new Protocol()
                        {
                            DateTime = DateTime.Now,
                            Devices = new ObservableCollection<Device>()
                        };

                        int i = 1;

                        foreach (Match match in matches)
                        {
                            Protocol.Devices.Add(new Device
                            {
                                Index = i,
                                DevName = match.Groups["DevName"].Value.Trim(),
                                DevEui = match.Groups["DevEui"].Value.Trim(),
                                AppEui = match.Groups["AppEui"].Value.Trim(),
                                AppKey = match.Groups["AppKey"].Value.Trim(),
                                DevAdd = int.Parse(match.Groups["DevAdd"].Value.Trim()).ToString("X8"),
                                AppSKey = match.Groups["AppSKey"].Value.Trim(),
                                NwkSKey = match.Groups["NwkSKey"].Value.Trim()
                            });

                            i++;
                        }

                        context.Protocols.Add(Protocol);
                        context.SaveChanges();
                    }
                    sr.Close();

                    Services.Excel.Export.ProtocolToXlsx(ProtocolPath, Protocol);

                    //File.WriteAllText(DevicesPath, String.Empty);

                    MessageBox.Show("Протокол успешно создан");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        private Protocol protocol;
        public Protocol Protocol
        {
            get => protocol;
            set => Notify(ref protocol, value);
        }
    }
}
