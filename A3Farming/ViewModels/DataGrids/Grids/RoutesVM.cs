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
    /// routes view model
    /// </summary>
    public class RoutesVM
    {
        /// <summary>
        /// data vm
        /// </summary>
        private readonly DataVM data;
       
        /// <summary>
        /// vehicle selection
        /// </summary>
        public VehicleSelection VehicleSelection { get; } 

        /// <summary>
        /// route view models
        /// </summary>
        public ObservableCollection<RouteVM> RouteVMs { get; } = new ObservableCollection<RouteVM>();
    
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="data">data view model</param>
        /// <param name="vehicleSelection">vehicle selection</param>
        public RoutesVM(DataVM data, VehicleSelection vehicleSelection)
        {
            this.data = data;
            VehicleSelection = vehicleSelection;

            foreach (var route in data.Data.Routes)
            {
                var routeVM = new RouteVM(route, data, vehicleSelection);
                RouteVMs.Add(routeVM);
            }

            RouteVMs.CollectionChanged += RouteVMs_CollectionChanged;
        }

        /// <summary>
        /// route collection changed event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void RouteVMs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (RouteVM route in e.NewItems)
                    data.Data.Routes.Add(route.Route);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                data.Data.Routes.RemoveRange(e.OldStartingIndex, e.OldItems.Count);
            }
        }

        /// <summary>
        /// updates the proceeds and proceeds per km for every route view model
        /// </summary>
        public void Update()
        {
            foreach (var routeVM in RouteVMs)
                routeVM.Update();
        }
    }
}
