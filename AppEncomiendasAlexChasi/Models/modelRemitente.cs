using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEncomiendasAlexChasi.Models
{
    public class modelRemitente
    {

        [PrimaryKey,AutoIncrement]
        public int IdRemitente { get; set; }

        [MaxLength(50)]        
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }

        [MaxLength(10)]
        public string Cedula { get; set; }

        [MaxLength(20)]
        public string Telefono { get; set; }





    }
}
