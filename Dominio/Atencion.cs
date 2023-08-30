using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.Dominio
{
    public class Atencion
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaAtencion { get; set; }

        public Atencion(int codigo, string descripcion, decimal importe, DateTime fechaAtencion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Importe = importe;
            FechaAtencion = fechaAtencion;
        }
        public Atencion(string descripcion, decimal importe, DateTime fechaAtencion)
        {
            Descripcion = descripcion;
            Importe = importe;
            FechaAtencion = fechaAtencion;
        }
    }
}
