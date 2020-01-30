using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
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
        private readonly IFrameNavigationService navigator;

        private MainViewModel()
        {
            DisplayTestingCommand = new RelayCommand(DisplayTesting);
            DisplayProtocolsCommand = new RelayCommand(DisplayProtocols);
            DisplaySettingsCommand = new RelayCommand(DisplaySettings);
        }

        public MainViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;
        }

        public ICommand DisplayTestingCommand { get; private set; }
        public ICommand DisplayProtocolsCommand { get; private set; }
        public ICommand DisplaySettingsCommand { get; private set; }

        private void DisplayTesting()
        {
            navigator.NavigateTo("Testing");
        }

        private void DisplayProtocols()
        {
            navigator.NavigateTo("Protocols");
        }

        private void DisplaySettings()
        {
            navigator.NavigateTo("Settings");
        }
    }
}
