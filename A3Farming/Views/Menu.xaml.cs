using A3Farming.Models.Data;
using A3Farming.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace A3Farming.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public VehicleSelection VehicleSelectionVM { get; }

        public Menu()
        {
            InitializeComponent();
            VehicleSelectionVM = new VehicleSelection();
        }

        private void Click_Menu(object sender, RoutedEventArgs e)
        {
            var menuItm = (MenuItem)sender;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            if(menuItm.Header.ToString() == "Routes")
            {
                mainWindow.Content.DataContext = mainWindow.Data.RoutesVM;
            }
            else if(menuItm.Header.ToString() == "Vehicles")
            {
                mainWindow.Content.DataContext = mainWindow.Data.VehiclesVM;
            }
            else if(menuItm.Header.ToString() == "Items")
            {
                mainWindow.Content.DataContext = mainWindow.Data.ItemsVM;
            }
        }
    }
}
