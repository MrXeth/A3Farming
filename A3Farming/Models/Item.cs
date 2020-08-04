using A3Farming.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace A3Farming.Models
{
    /// <summary>
    /// item model
    /// </summary>
    public class Item : IToStringArray
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// price
        /// </summary>
        public uint Price { get; set; }

        /// <summary>
        /// weight
        /// </summary>
        public uint Weight { get; set; }

        /// <summary>
        /// implements <see cref="IToStringArray"/>
        /// </summary>
        public string[] ToStringArray() => new string[] { Name, Price.ToString(), Weight.ToString() };
    }
}
