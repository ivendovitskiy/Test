using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoreApp.Services.Navigation
{
    public interface IFrameNavigationService 
    {
        void ClearHistory();
        void NavigateTo(string pageKey);
        void NavigateTo(string pageKey, string propertyName, object parameter);
    }
}
