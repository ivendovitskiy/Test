using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCoreApp.Data;
using TestCoreApp.Services.Navigation;
using TestCoreApp.Services.Settings;
using TestCoreApp.ViewModels.Protocols;
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

            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Services = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SettingsService>();

            serviceCollection.AddDbContext<TestDbContext>(options => options.UseSqlServer(new SettingsService().Settings.ConnectionString), ServiceLifetime.Transient);

            var navigationService = new FrameNavigationService();
            navigationService.Configure("Testing", new Uri("../Views/Testing/TestingPage.xaml", UriKind.Relative));
            navigationService.Configure("Protocols", new Uri("../Views/Protocols/ProtocolsPage.xaml", UriKind.Relative));
            navigationService.Configure("Protocol", new Uri("../Views/Protocols/ProtocolPage.xaml", UriKind.Relative));
            navigationService.Configure("Settings", new Uri("../Views/Settings/SettingsPage.xaml", UriKind.Relative));

            serviceCollection.AddSingleton<IFrameNavigationService>(navigationService);

            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<TestingViewModel>();
            serviceCollection.AddTransient<SettingsViewModel>();
            serviceCollection.AddTransient<ProtocolViewModel>();
            serviceCollection.AddTransient<ProtocolsViewModel>();
        }

        public static IServiceProvider Services { get; private set; }

        public MainViewModel Main
        {
            get => Services.GetRequiredService<MainViewModel>();
        }

        public TestingViewModel Testing
        {
            get => Services.GetRequiredService<TestingViewModel>();
        }

        public ProtocolViewModel Protocol
        {
            get => Services.GetRequiredService<ProtocolViewModel>();
        }

        public ProtocolsViewModel Protocols
        {
            get => Services.GetRequiredService<ProtocolsViewModel>();
        }

        public SettingsViewModel Settings
        {
            get => Services.GetRequiredService<SettingsViewModel>();
        }
    }
}
