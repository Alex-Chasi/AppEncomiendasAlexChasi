using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEncomiendasAlexChasi.Models
{
    public class modelDetalle
    {
        [PrimaryKey, AutoIncrement]
        public int IdDetalle { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [MaxLength(150)]
        public string Tamanio { get; set; }

        [MaxLength(50)]
        public string Peso { get; set; }
    }
}
