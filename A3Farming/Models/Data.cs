using A3Farming.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace A3Farming.Models.Data
{
    /// <summary>
    /// data model class
    /// </summary>
    public class Data
    {
        /// <summary>
        /// delegate for getting a data object from an array
        /// </summary>
        /// <param name="array">string array</param>
        /// <returns>datat object</returns>
        private delegate object FromArray(string[] array);

        #region data properties

        /// <summary>
        /// item data
        /// </summary>
        public List<Item> Items { get; } = new List<Item>();

        /// <summary>
        /// vehicle data
        /// </summary>
        public List<Vehicle> Vehicles { get; } = new List<Vehicle>();

        /// <summary>
        /// route data
        /// </summary>
        public List<Route> Routes { get; } = new List<Route>();

        #endregion

        #region data from array

        /// <summary>
        /// gets a item from an array
        /// </summary>
        /// <param name="array">string array</param>
        /// <returns> an object of <see cref="Item"/></returns>
        private object ItemFromArray(string[] array)
        {
            return new Item()
            {
                Name = array[0],
                Price = uint.Parse(array[1]),
                Weight = uint.Parse(array[2])
            };
        }

        /// <summary>
        /// gets a vehicle from an array
        /// </summary>
        /// <param name="array">string array</param>
        /// <returns>an object of <see cref="Vehicle"/></returns>
        private object VehicleFromArray(string[] array)
        {
            return new Vehicle()
            {
                Name = array[0],
                Price = uint.Parse(array[1]),
                Capacity = uint.Parse(array[2])
            };
        }

        /// <summary>
        /// gets a route from an array
        /// </summary>
        /// <param name="array">string array</param>
        /// <returns>an object of <see cref="Route"/></returns>
        private object RouteFromArray(string[] array)
        {
            var item = Items.Where(item => item.Name == array[0]).First();
            return new Route()
            {
                Item = item,
                Distance = double.Parse(array[1]),
                TimeSpan = TimeSpan.Parse(array[2])
            };
        }

        #endregion

        #region read data

        /// <summary>
        /// Reads the data of a csv file or creates a new one if the desired file does not exist in the directory.
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>
        /// The data as a string two dimensional string array.
        /// The first index contains the row and the second the data.
        /// </returns>
        private static string[][] ReadCSV(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                return new string[0][];
            }

            using var streamReader = new StreamReader(path);

            var lines = new List<string[]>();

            // regex to filter escaped separators (";")
            var pattern = @"(?<!\\);";

            var line = streamReader.ReadLine();
            while (line != null)
            {
                var split = Regex.Split(line, pattern);
                lines.Add(split);
                line = streamReader.ReadLine();
            }
            return lines.ToArray();
        }

        /// <summary>
        /// Helper method, which reads the data of a file and adds it to the right list.
        /// </summary>
        /// <param name="path">data path</param>
        /// <param name="fromArray">conversion method</param>
        private void ReadHelper(string path, FromArray fromArray)
        {
            var table = ReadCSV(path);
            foreach(var row in table)
            {
                var obj = fromArray(row);

                if (obj is Item item)
                    Items.Add(item);
                else if (obj is Vehicle vehicle)
                    Vehicles.Add(vehicle);
                else if (obj is Route route)
                    Routes.Add(route);
            }
        }

        /// <summary>
        /// Reads the stored data. If the desired files are missing, they will be created.
        /// </summary>
        public void ReadData()
        {
            var myfolders = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\A3Faming\CSV\";
            Directory.CreateDirectory(myfolders);

            ReadHelper(myfolders + "Items.csv", ItemFromArray);
            ReadHelper(myfolders + "Vehicles.csv", VehicleFromArray);
            ReadHelper(myfolders + "Routes.csv", RouteFromArray);
        }

        #endregion

        #region write data

        /// <summary>
        /// Writes data into a csv file. If the desired file does not exist in the directory a new one will be created.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <param name="table">
        /// two dimensional string array containing the data
        /// The first index specifies the row and the second the item data.
        /// </param>
        private void WriteCSV(string path, string[][] table)
        {
            using var streamWriter = new StreamWriter(path);

            var stringBuilder = new StringBuilder();
            foreach (var line in table)
            {
                foreach (var cell in line)
                {
                    // escape the seperator (";") if it occurs in a string
                    var escaped = cell.Replace(";", "\\;") + ";";
                    stringBuilder.Append(escaped);
                }
                var row = stringBuilder.ToString();
                streamWriter.WriteLine(row);
                stringBuilder.Clear();
            }
        }

        /// <summary>
        /// Helper method, which writes the data of an item list into a file.
        /// The file will be created, if it does not exist in the desired directory.
        /// </summary>
        /// <param name="path">path to file</param>
        /// <param name="items">list of items</param>
        private void WriteHelper(string path, List<IToStringArray> items)
        {
            var table = new string[items.Count][];
            var enumerator = items.GetEnumerator();

            for (var i = 0; enumerator.MoveNext(); i++)
                table[i] = enumerator.Current.ToStringArray();

            WriteCSV(path, table);
        }

        /// <summary>
        /// Stores the data. If the needed files do not exist they will be created.
        /// </summary>
        public void WriteData()
        {
            var myfolders = @$"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\A3Faming\CSV\";
            Directory.CreateDirectory(myfolders);

            var file = "Items.csv";
            WriteHelper(myfolders + file, Items.ConvertAll(item => (IToStringArray)item));

            file = "Vehicles.csv";
            WriteHelper(myfolders + file, Vehicles.ConvertAll(vehicle => (IToStringArray)vehicle));

            file = "Routes.csv";
            WriteHelper(myfolders + file, Routes.ConvertAll(route => (IToStringArray)route));
        }

        #endregion
    }


}
