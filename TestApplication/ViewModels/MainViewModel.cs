using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestApplication.Data;
using TestApplication.Services.FileDialog;

namespace TestApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly TestDbContext context;

        private ObservableCollection<Device> devices;
        public ObservableCollection<Device> Devices
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
                RaisePropertyChanged("Devices");
            }
        }

        public ICommand OpenFileCommand { get; private set; }
        public ICommand AddDevicesToVegaCommand { get; private set; }

        public MainViewModel(TestDbContext context)
        {
            this.context = context;

            OpenFileCommand = new RelayCommand(OpenFile);
            AddDevicesToVegaCommand = new RelayCommand(AddDevicesToVega);
        }

        private void AddDevicesToVega()
        {
            List<VegaServerApi.Dto.Device> vegaDevices = new List<VegaServerApi.Dto.Device>();

            foreach (var device in this.devices.Where(d => d.IsActive == true))
            {
                VegaServerApi.Dto.Device vegaDevice = new VegaServerApi.Dto.Device();

                vegaDevice.Abp = new VegaServerApi.Dto.Abp()
                {
                    AppSKey = device.AppSKey,
                    DevAddress = Convert.ToInt32(device.DevAdd),
                    NwkSKey = device.NwkSKey
                };

                vegaDevice.Otaa = new VegaServerApi.Dto.Otaa()
                {
                    AppEui = device.AppEui,
                    AppKey = device.AppKey
                };

                vegaDevice.DevName = device.Name;
                vegaDevice.DevEui = device.DevEui;

                vegaDevices.Add(vegaDevice);
            }

            VegaServerApi.Client client = new VegaServerApi.Client();

            Console.WriteLine(client.Auth(new VegaServerApi.Dto.UserAuthorization.AuthRequest() { Login = "root", Password = "123" }));

            var y = client.AddOrUpdateDevices(vegaDevices);

            MessageBox.Show(y.Result.ErrorString);
        }

        private void OpenFile()
        {
            FileDialog fileDialog = new FileDialog();

            if (fileDialog.OpenFileDialog())
            {
                try
                {
                    using (StreamReader sr = File.OpenText(fileDialog.FilePath))
                    {
                        string s = @"devName:(\r\n|\r|\n)*(?<DevName>.{0,})(\r\n|\r|\n)*DevEui:(\r\n|\r|\n)*(?<DevEui>.{0,})(\r\n|\r|\n)*AppEui:(\r\n|\r|\n)*(?<AppEui>.{0,})(\r\n|\r|\n)*AppKey:(\r\n|\r|\n)*(?<AppKey>.{0,})(\r\n|\r|\n)*DevAdd:(\r\n|\r|\n)*(?<DevAdd>.{0,})(\r\n|\r|\n)*AppSKey:(\r\n|\r|\n)*(?<AppSKey>.{0,})(\r\n|\r|\n)*NwkSKEY:(\r\n|\r|\n)*(?<NwkSKey>.{0,})(\r\n|\r|\n)?";
                        Regex regex = new Regex(s);

                        string text = sr.ReadToEnd();
                        MatchCollection matches = regex.Matches(text);

                        if (matches.Count > 24)
                        {
                            MessageBox.Show("Отсканируйте не больше 24 сканеров");
                            return;
                        }
                        else if (matches.Count == 0)
                        {
                            MessageBox.Show("Отсканируйте хотя бы один сканер");
                        }
                        else
                        {
                            Devices = new ObservableCollection<Device>();

                            int i = 1;

                            foreach (Match match in matches)
                            {
                                Devices.Add(new Device
                                {
                                    Index = i,
                                    Name = match.Groups["DevName"].Value.Trim(),
                                    DevEui = match.Groups["DevEui"].Value.Trim(),
                                    AppEui = match.Groups["AppEui"].Value.Trim(),
                                    AppKey = match.Groups["AppKey"].Value.Trim(),
                                    DevAdd = match.Groups["DevAdd"].Value.Trim(),
                                    AppSKey = match.Groups["AppSKey"].Value.Trim(),
                                    NwkSKey = match.Groups["NwkSKey"].Value.Trim()
                                });

                                i++;
                            }

                            for (; i < 25; i++)
                            {
                                Devices.Add(new Device()
                                {
                                    Index = i,
                                    IsActive = false
                                });
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
    }
}
