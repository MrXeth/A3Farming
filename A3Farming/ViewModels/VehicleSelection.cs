using A3Farming.ViewModels.DataGrids.Grids;
using A3Farming.ViewModels.DataGrids.Rows;
using System.Collections.ObjectModel;
using System.Linq;

namespace A3Farming.ViewModels
{
    /// <summary>
    /// vehicle selection view model
    /// </summary>
    public class VehicleSelection : BaseViewModel
    {
        /// <summary>
        /// view model of selected vehicle
        /// </summary>
        private VehicleVM selectedVehicle;

        public RoutesVM RoutesVM { get; set; }

        /// <summary>
        /// collection of all vehicle view models
        /// </summary>
        public ObservableCollection<VehicleVM> VehicleVMs { get; set; }

        /// <summary>
        /// selected vehicle
        /// </summary>
        public VehicleVM SelectedVehicle
        {
            get => selectedVehicle ?? VehicleVMs.First();
            set
            {
                selectedVehicle = value;
                RoutesVM.Update();
                OnPropertyChanged();
            }
        }
    }
}
