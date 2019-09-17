using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.Services.FileDialog;
using TestApplication.Services.Navigation;
using TestApplication.ViewModels.Testing;

namespace TestApplication.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestingViewModel>();

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


        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();

            //navigationService.Configure();

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            SimpleIoc.Default.Register(() => new TestDbContext());
        }
    }
}
