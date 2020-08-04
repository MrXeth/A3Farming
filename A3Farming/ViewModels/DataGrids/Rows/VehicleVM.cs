using A3Farming.Models;
using A3Farming.Models.Data;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace A3Farming.ViewModels.DataGrids.Rows
{
    /// <summary>
    /// vehicle view model
    /// </summary>
    public class VehicleVM : BaseViewModel
    {
        /// <summary>
        /// vehicle model
        /// </summary>
        public Vehicle Vehicle { get; }

        #region gui properties

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get => Vehicle.Name;
            set
            {
                Vehicle.Name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// capacity
        /// </summary>
        public uint Capacity
        {
            get => Vehicle.Capacity;
            set
            {
                Vehicle.Capacity = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// price
        /// </summary>
        public uint Price
        {
            get => Vehicle.Price;
            set
            {
                Vehicle.Price = value;
                OnPropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public VehicleVM() : this(new Vehicle())
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="vehicle">vehicle model</param>
        public VehicleVM(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }
        
    }
}
