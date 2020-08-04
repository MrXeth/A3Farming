using A3Farming.ViewModels;
using A3Farming.ViewModels.DataGrids.Rows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace A3Farming.Views
{
    /// <summary>
    /// Interaction logic for Routes.xaml
    /// </summary>
    public partial class Routes : UserControl
    {

        /// <summary>
        /// constructor
        /// </summary>
        public Routes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// menu item click handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var collection = (ObservableCollection<RouteVM>)Data.ItemsSource;
            var selectedRoute = (RouteVM)Data.SelectedItem;
            collection.Remove(selectedRoute);
        }

        /// <summary>
        /// datagrid adding new item handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Data_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            var routeVM = new RouteVM()
            {
                Data = mainWindow.Data,
                VehicleSelection = mainWindow.VehicleSelectionVM
            };
            e.NewItem = routeVM;
        }
    }
}
