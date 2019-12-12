using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace TestCoreApp.Services.Navigation
{
    public class FrameNavigationService : IFrameNavigationService, INotifyPropertyChanged
    {
        private readonly Dictionary<string, Uri> pagesByKey;
        private readonly List<string> historic;
        private string currentPageKey;

        public string CurrentPageKey
        {
            get
            {
                return currentPageKey;
            }

            private set
            {
                if (currentPageKey == value)
                {
                    return;
                }

                currentPageKey = value;
                OnPropertyChanged("CurrentPageKey");
            }
        }


        public FrameNavigationService()
        {
            this.pagesByKey = new Dictionary<string, Uri>();
            this.historic = new List<string>();
        }

        public void GoBack()
        {
            if (historic.Count > 1)
            {
                this.historic.RemoveAt(historic.Count - 1);
                NavigateTo(this.historic.Last(), null);
            }
        }

        public void ClearHistory()
        {
            //_historic.Clear();

            //var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

            //if (frame != null)
            //{
            //    if(!frame.CanGoBack && !frame.CanGoForward)
            //    {
            //        var entry = frame.RemoveBackEntry();
            //        while (entry != null)
            //        {
            //            entry = frame.RemoveBackEntry();
            //        }
            //    }

            //}
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (pagesByKey)
            {
                if (!pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

                if (frame != null)
                {
                    frame.Source = pagesByKey[pageKey];
                }

                historic.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        public void NavigateTo(string pageKey, string propertyName, object parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }



            lock (pagesByKey)
            {
                if (!pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(string.Format("No such page: {0} ", pageKey), "pageKey");
                }

                Frame frame = (Frame)GetDescendantFromName(Application.Current.MainWindow, "MainFrame");


                if (frame != null)
                {
                    frame.Source = pagesByKey[pageKey];

                    LoadCompletedEventHandler eventHandler = null;
                    eventHandler = delegate (object sender, NavigationEventArgs e)
                    {
                        Page page = (Page)frame.Content;

                        PropertyInfo property = page.DataContext.GetType().GetProperty(propertyName);

                        Type vmType = page.DataContext.GetType();


                        if (property.PropertyType == parameter.GetType())
                        {
                            property.SetValue(Convert.ChangeType(page.DataContext, vmType), Convert.ChangeType(parameter, property.PropertyType), null);
                        }

                        frame.LoadCompleted -= eventHandler;
                    };

                    frame.LoadCompleted += eventHandler;
                }

                historic.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }



        public void Configure(string key, Uri pageType)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(key))
                {
                    pagesByKey[key] = pageType;
                }
                else
                {
                    pagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
