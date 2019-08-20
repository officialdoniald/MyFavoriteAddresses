using System.Collections.Generic;
using System.IO;
using Google.Places;
using MyFavoriteAddresses.BLL.Models;
using SQLite;

namespace MyFavoriteAddresses
{
    public class DatabaseConnection
    {
        private SQLiteConnection _conn;

        public DatabaseConnection()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "addresses.db3");

            _conn = new SQLiteConnection(dbPath);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StoreAddress(Place place)
        {
            _conn.CreateTable<Places>();

            Places places = new Places
            {
                Name = place.Name,
                Longitude = place.LatLng.Longitude,
                Latitude = place.LatLng.Latitude
            };

            _conn.Insert(places);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Places> GetPlaces()
        {
            _conn.CreateTable<Places>();

            return _conn.Table<Places>().ToList();
        }
    }
}