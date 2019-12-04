using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestCoreApp.Views.Testing
{
    /// <summary>
    /// Interaction logic for TestingPage.xaml
    /// </summary>
    public partial class TestingPage : Page
    {
        public TestingPage()
        {
            InitializeComponent();
        }

        private void protocolsDataGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            protocolsDataGrid.SelectedItem = null;
        }
    }
}
