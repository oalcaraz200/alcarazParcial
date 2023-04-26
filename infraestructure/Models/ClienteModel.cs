using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infraestructure.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public int IdCiudad { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string documento { get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

        public string fechanacimiento { get; set; }

        public string ciudad { get; set; }

        public string nacionalidad { get; set; }

    }
}


