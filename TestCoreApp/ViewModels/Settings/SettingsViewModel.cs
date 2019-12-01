using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestCoreApp.Services.Settings;

namespace TestCoreApp.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel()
        {
            settingsService = new SettingsService();

            SaveCommand = new RelayCommand(Save);

            DevicesPath = settingsService.Settings.DevicesPath;
            ResponsePath = settingsService.Settings.ResponsePath;
            ProtocolPath = settingsService.Settings.ProtocolPath;
        }



        private readonly SettingsService settingsService;

        private void Save()
        {
            settingsService.Settings.DevicesPath = DevicesPath;
            settingsService.Settings.ResponsePath = ResponsePath;
            settingsService.Settings.ProtocolPath = ProtocolPath;

            settingsService.SaveSettings();
        }

        public ICommand SaveCommand { get; private set; }

        private string devicesPath;
        public string DevicesPath
        {
            get
            {
                return devicesPath;
            }
            set
            {
                Notify(ref devicesPath, value);
            }
        }

        private string responsePath;
        public string ResponsePath
        {
            get
            {
                return responsePath;
            }
            set
            {
                Notify(ref responsePath, value);
            }
        }

        private string protocolPath;
        public string ProtocolPath
        {
            get
            {
                return protocolPath;
            }
            set
            {
                Notify(ref protocolPath, value);
            }
        }
    }
}
