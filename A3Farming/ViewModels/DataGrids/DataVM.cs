using A3Farming.Models.Data;
using A3Farming.ViewModels.DataGrids.Grids;
using A3Farming.ViewModels.DataGrids.Rows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace A3Farming.ViewModels.DataGrids
{
    /// <summary>
    /// data view model
    /// </summary>
    public class DataVM : BaseViewModel
    {
        /// <summary>
        /// data model
        /// </summary>
        public Data Data { get; }

        #region view models

        /// <summary>
        /// item view models
        /// </summary>
        public ItemsVM ItemsVM { get; }

        /// <summary>
        /// vehicle view models
        /// </summary>
        public VehiclesVM VehiclesVM { get; }

        /// <summary>
        /// route view models
        /// </summary>
        public RoutesVM RoutesVM { get; }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="vehicleSelection">vehicle selection view model</param>
        public DataVM(VehicleSelection vehicleSelection)
        {
            Data = new Data();
            Data.ReadData();

            ItemsVM = new ItemsVM(Data);
            VehiclesVM = new VehiclesVM(Data);
            RoutesVM = new RoutesVM(this, vehicleSelection);
        }

        /// <summary>
        /// write the data to csv files
        /// </summary>
        public void WriteData()
        {
            Data.WriteData();
        }
    }
}
