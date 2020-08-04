using A3Farming.Models;
using A3Farming.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace A3Farming.ViewModels.DataGrids.Rows
{
    /// <summary>
    /// item view model
    /// </summary>
    public class ItemVM : BaseViewModel
    {
        /// <summary>
        /// item model
        /// </summary>
        public Item Item { get; }

        #region gui properties

        /// <summary>
        /// name
        /// </summary>
        public string Name
        {
            get => Item.Name;
            set
            {
                Item.Name = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// weight
        /// </summary>
        public uint Weight
        {
            get => Item.Weight;
            set
            {
                Item.Weight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// price
        /// </summary>
        public uint Price
        {
            get => Item.Price;
            set
            {
                Item.Price = value;
                OnPropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public ItemVM() : this(new Item())
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="item">item model</param>
        public ItemVM(Item item)
        {
            Item = item;
        }
    }
}
