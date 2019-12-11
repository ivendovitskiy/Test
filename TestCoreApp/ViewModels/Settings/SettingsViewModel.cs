using GalaSoft.MvvmLight.Command;
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
        }

        private readonly SettingsService settingsService;

        private void Save()
        {
            settingsService.SaveSettings();
        }

        public ICommand SaveCommand { get; private set; }

        public TestCoreApp.Services.Settings.Settings Settings
        {
            get => settingsService.Settings;
        }
    }
}
