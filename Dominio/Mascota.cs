using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class Mascota
    {
        public List<Atencion> Atenciones = new List<Atencion>();
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public TipoMascota TipoMascota { get; set; }
        public int Codigo { get; set; }

        public Mascota(string nombre, int edad, TipoMascota tipo, int codigo)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.TipoMascota = tipo;
            this.Codigo = codigo;
        }

        public override string ToString()
        {
            return this.Codigo + " - " + this.TipoMascota.Nombre + " " + this.Nombre + " - " + this.Edad + " Años";
        }
    }
}
