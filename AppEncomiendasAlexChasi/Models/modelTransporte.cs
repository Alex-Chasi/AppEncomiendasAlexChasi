using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEncomiendasAlexChasi.Models
{
    public class modelTransporte
    {
        [PrimaryKey, AutoIncrement]
        public int IdTransporte { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [MaxLength(100)]
        public string TipoTransporte { get; set; }

        [MaxLength(50)]
        public string Marca { get; set; }

        [MaxLength(50)]
        public string Modelo { get; set; }

        [MaxLength(100)]
        public string Chofer { get; set; }
    }
}
