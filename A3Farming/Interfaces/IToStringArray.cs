using System;
using System.Collections.Generic;
using System.Text;

namespace A3Farming.Interfaces
{
    /// <summary>
    /// interface providing an action to convert an object to a string array
    /// </summary>
    public interface IToStringArray
    {
        /// <summary>
        /// converts the object to a string array
        /// </summary>
        /// <returns>string array</returns>
        public string[] ToStringArray();
    }
}
