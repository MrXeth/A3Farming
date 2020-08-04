using A3Farming.Models;
using A3Farming.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace A3Farming.ViewModels.DataGrids.Rows
{
    /// <summary>
    /// route view model
    /// </summary>
    public class RouteVM : BaseViewModel
    {
        /// <summary>
        /// route model
        /// </summary>
        public Route Route { get; }

        /// <summary>
        /// data view model
        /// </summary>
        public DataVM Data { get; set; }

        /// <summary>
        /// vehicle selection
        /// </summary>
        public VehicleSelection VehicleSelection { get; set; }

        /// <summary>
        /// updates proceeds and proceeds per km
        /// </summary>
        public void Update()
        {
            OnPropertyChanged(nameof(Proceeds));
            OnPropertyChanged(nameof(ProceedsPerKm));
        }

        #region gui properties

        /// <summary>
        /// name
        /// </summary>
        public string Name 
        {
            get => Route.Item == null ? "Item not found" : Route.Item.Name;
            set
            {
                foreach(var item in Data.Data.Items)
                {
                    if (item.Name == value)
                    {
                        Route.Item = item;
                        OnPropertyChanged();
                        OnPropertyChanged(nameof(ItemPrice));
                        Update();
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// distance
        /// </summary>
        public double Distance
        {
            get => Route.Distance;
            set
            {
                Route.Distance = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ProceedsPerKm));
            }
        }

        /// <summary>
        /// time span
        /// </summary>
        public TimeSpan TimeSpan
        {
            get => Route.TimeSpan;
            set
            {
                Route.TimeSpan = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// item price
        /// </summary>
        public uint ItemPrice
        {
            get => Route.Item == null ? 0 : Route.Item.Price;
            set
            {
                if (Route.Item == null) return;
                Route.Item.Price = value;
                OnPropertyChanged();
                Update();
            }
        }

        /// <summary>
        /// proceeds per km
        /// </summary>
        public double ProceedsPerKm
        {
            get =>  Proceeds / Distance;
        }

        /// <summary>
        /// proceeds
        /// </summary>
        public uint Proceeds
        {
            get
            {
                var selectedVehicle = VehicleSelection.SelectedVehicle;
                return selectedVehicle.Capacity * ItemPrice;
            }
        }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public RouteVM()
        {
            Route = new Route();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="route">route model</param>
        /// <param name="data">data model</param>
        /// <param name="vehicleSelection">vehicle selection</param>
        public RouteVM(Route route, DataVM data, VehicleSelection vehicleSelection)
        {
            Route = route;
            Data = data;
            VehicleSelection = vehicleSelection;
        }
    }
}
