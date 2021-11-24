using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEncomiendasAlexChasi.Models
{
    public class modelDestinatario
    {
        [PrimaryKey, AutoIncrement]
        public int IdDestinatario { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }


        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(10)]
        public int Cedula { get; set; }

        [MaxLength(20)]
        public int Telefono { get; set; }

    }
}
