using A3Farming.Models.Data;
using A3Farming.ViewModels.DataGrids.Rows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;

namespace A3Farming.ViewModels.DataGrids.Grids
{
    /// <summary>
    /// vehicles view models
    /// </summary>
    public class VehiclesVM
    {
        /// <summary>
        /// data
        /// </summary>
        private readonly Data data;

        /// <summary>
        /// vehicle view models collection
        /// </summary>
        public ObservableCollection<VehicleVM> VehicleVMs { get; } = new ObservableCollection<VehicleVM>();
    
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="data">data view model</param>
        public VehiclesVM(Data data)
        {
            this.data = data;

            foreach (var vehicle in data.Vehicles)
            {
                var vehicleVM = new VehicleVM(vehicle);
                VehicleVMs.Add(vehicleVM);
            }

            VehicleVMs.CollectionChanged += VehicleVMs_CollectionChanged;
        }

        /// <summary>
        /// vehicle vms colleciton changed event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void VehicleVMs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (VehicleVM vehicle in e.NewItems)
                    data.Vehicles.Add(vehicle.Vehicle);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                data.Vehicles.RemoveRange(e.OldStartingIndex, e.OldItems.Count);
            }
        }
    }
}
