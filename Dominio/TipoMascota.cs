using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class TipoMascota
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public TipoMascota(int cod, string nombre)
        {
            this.Codigo = cod;
            this.Nombre = nombre;
        }
        public override string ToString()
        {
            return $"{this.Codigo} - {this.Nombre}";
        }
    }
}
