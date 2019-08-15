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
        private readonly TestDbContext _context;

        private ObservableCollection<Device> _devices;
        public ObservableCollection<Device> Devices
        {
            get
            {
                return _devices;
            }
            set
            {
                _devices = value;
                RaisePropertyChanged("Devices");
            }
        }

        public ICommand OpenFileCommand { get; private set; }

        public MainViewModel(TestDbContext context)
        {
            _context = context;

            OpenFileCommand = new RelayCommand(OpenFile);
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
                                    Name = match.Groups["DevName"].Value,
                                    DevEui = match.Groups["DevEui"].Value,
                                    AppEui = match.Groups["AppEui"].Value,
                                    AppKey = match.Groups["AppKey"].Value,
                                    DevAdd = match.Groups["DevAdd"].Value,
                                    AppSKey = match.Groups["AppSKey"].Value,
                                    NwkSKey = match.Groups["NwkSKey"].Value
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
