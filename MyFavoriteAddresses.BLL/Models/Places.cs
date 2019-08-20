﻿using SQLite;

namespace MyFavoriteAddresses.BLL.Models
{
    [Table("Places")]
    public class Places
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}