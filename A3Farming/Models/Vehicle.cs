using A3Farming.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace A3Farming.Models
{
    /// <summary>
    /// vehicle model
    /// </summary>
    public class Vehicle : IToStringArray
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
        /// capacity
        /// </summary>
        public uint Capacity { get; set; }

        /// <summary>
        /// implements <see cref="IToStringArray"/>
        /// </summary>
        public string[] ToStringArray() => new string[] { Name, Price.ToString(), Capacity.ToString() };
    }
}
