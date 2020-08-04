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
    /// items view model
    /// </summary>
    public class ItemsVM
    {
        /// <summary>
        /// data
        /// </summary>
        private readonly Data data;

        /// <summary>
        /// item vms
        /// </summary>
        public ObservableCollection<ItemVM> ItemVMs { get; } = new ObservableCollection<ItemVM>();
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="data">data model</param>
        public ItemsVM(Data data)
        {
            this.data = data;

            foreach (var item in data.Items)
            {
                var itemVM = new ItemVM(item);
                ItemVMs.Add(itemVM);
            }

            ItemVMs.CollectionChanged += ItemVMs_CollectionChanged;
        }

        /// <summary>
        /// fires if the collection changes
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void ItemVMs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ItemVM item in e.NewItems)
                {
                    data.Items.Add(item.Item);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                data.Items.RemoveRange(e.OldStartingIndex, e.OldItems.Count);
            }
        }
    }
}
