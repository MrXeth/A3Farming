using A3Farming.Models;
using A3Farming.Models.Data;
using A3Farming.ViewModels;
using A3Farming.ViewModels.DataGrids;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A3Farming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// data view model
        /// </summary>
        public DataVM Data { get; }
        public VehicleSelection VehicleSelectionVM { get; }

        /// <summary>
        /// constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            VehicleSelectionVM = menu.VehicleSelectionVM;
            Data = new DataVM(VehicleSelectionVM);
            VehicleSelectionVM.VehicleVMs = Data.VehiclesVM.VehicleVMs;
            VehicleSelectionVM.RoutesVM = Data.RoutesVM;
            Content.DataContext = Data.RoutesVM;
        }

        /// <summary>
        /// closing window handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Data.WriteData();
        }

    }
}
