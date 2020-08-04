using A3Farming.ViewModels.DataGrids.Rows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
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
    /// Interaction logic for Prices.xaml
    /// </summary>
    public partial class Items : UserControl
    {
        public Items()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var collection = (ObservableCollection<ItemVM>)Data.ItemsSource;
            var selectedItem = (ItemVM)Data.SelectedItem;
            collection.Remove(selectedItem);
        }
    }
}
