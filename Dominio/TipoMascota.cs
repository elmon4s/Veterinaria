using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class TipoMascota
    {
        public string Nombre { get; set; }

        public TipoMascota(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}
