using GalaSoft.MvvmLight.Command;
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
using TestCoreApp.Services.Navigation;
using TestCoreApp.ViewModels;

namespace TestCoreApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IFrameNavigationService navigator)
        {
            this.navigator = navigator;

            DisplayTestingCommand = new RelayCommand(DisplayTesting);
            DisplaySettingsCommand = new RelayCommand(DisplaySettings);
        }

        private readonly IFrameNavigationService navigator;

        private void DisplayTesting()
        {
            navigator.NavigateTo("Testing");
        }

        private void DisplaySettings()
        {
            navigator.NavigateTo("Settings");
        }

        public ICommand DisplayTestingCommand { get; private set; }
        public ICommand DisplaySettingsCommand { get; private set; }
    }
}
