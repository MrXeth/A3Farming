using A3Farming.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace A3Farming.Models
{
    /// <summary>
    /// route model
    /// </summary>
    public class Route : IToStringArray
    {
        /// <summary>
        /// item delivered in the route
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public double Distance { get; set; }
        
        /// <summary>
        /// timespan
        /// </summary>
        public TimeSpan TimeSpan { get; set; } = new TimeSpan();

        /// <summary>
        /// implements <see cref="IToStringArray"/>
        /// </summary>
        public string[] ToStringArray() => new string[] { Item.Name, Distance.ToString(), TimeSpan.ToString() };
    }
}
