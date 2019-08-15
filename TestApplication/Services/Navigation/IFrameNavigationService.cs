using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Services.Navigation
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }

        void ClearHistory();
    }
}
