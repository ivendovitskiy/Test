using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCoreApp.Data;
using TestCoreApp.Services.Navigation;
using TestCoreApp.Services.Settings;
using TestCoreApp.ViewModels.Settings;
using TestCoreApp.ViewModels.Testing;

namespace TestCoreApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestingViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<ProtocolViewModel>();

            SimpleIoc.Default.Register<SettingsService>(() => new SettingsService());

            SimpleIoc.Default.Register<TestDbContext>();

            
            SetupNavigation();
        }

        public MainViewModel Main
        {
            get => ServiceLocator.Current.GetInstance<MainViewModel>();
        }

        public TestingViewModel Testing
        {
            get => ServiceLocator.Current.GetInstance<TestingViewModel>();
        }

        public ProtocolViewModel Protocol
        {
            get => SimpleIoc.Default.GetInstanceWithoutCaching<ProtocolViewModel>();
        }

        public SettingsViewModel Settings
        {
            get => ServiceLocator.Current.GetInstance<SettingsViewModel>();
        }

        public TestDbContext Context
        {
            get => new TestDbContext(new DbContextOptionsBuilder().UseSqlServer(SimpleIoc.Default.GetInstanceWithoutCaching<SettingsViewModel>().Settings.ConnectionString).Options);
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();

            navigationService.Configure("Testing", new Uri("../Views/Testing/TestingPage.xaml", UriKind.Relative));
            navigationService.Configure("Protocol", new Uri("../Views/Testing/ProtocolPage.xaml", UriKind.Relative));
            navigationService.Configure("Settings", new Uri("../Views/Settings/SettingsPage.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            //SimpleIoc.Default.Register(() => new TestDbContext());
        }
    }
}
