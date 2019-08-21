using MyFavoriteAddresses.BLL.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace MyFavoriteAddresses.BLL.Models
{
    [Table("Places")]
    public class Places : IDatabase<Places>
    {
        private SQLiteConnection _conn;

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Longitude")]
        public double Longitude { get; set; }

        [Column("Latitude")]
        public double Latitude { get; set; }

        public Places()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "addresses.db3");

            _conn = new SQLiteConnection(dbPath);
        }

        public List<Places> GetItems()
        {
            _conn.CreateTable<Places>();

            return _conn.Table<Places>().ToList();
        }

        public void StoreItem(Places item)
        {
            _conn.CreateTable<Places>();

            Places places = new Places
            {
                Name = item.Name,
                Longitude = item.Longitude,
                Latitude = item.Latitude
            };

            _conn.Insert(places);
        }

        public void StorePlace(string name, double longitude, double latitude)
        {
            this.Name = name;
            this.Longitude = longitude;
            this.Latitude = latitude;

            StoreItem(this);
        }
    }
}