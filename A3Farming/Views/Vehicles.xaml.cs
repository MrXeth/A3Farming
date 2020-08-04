using A3Farming.Models;
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
    /// Interaction logic for Vehicles.xaml
    /// </summary>
    public partial class Vehicles : UserControl
    {
        /// <summary>
        /// constructor
        /// </summary>
        public Vehicles()
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
            var collection = (ObservableCollection<VehicleVM>)Data.ItemsSource;
            var selectedVehicle = (VehicleVM)Data.SelectedItem;
            collection.Remove(selectedVehicle);
        }
    }
}
