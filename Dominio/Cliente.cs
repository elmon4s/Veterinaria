using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinaria.Dominio
{
    public class Cliente
    {
        private List<Mascota> mascotas;
        public string Nombre { get; set; }
        public bool Sexo { get; set; }
        public int Codigo { get; set; }

        public Cliente(string nombre, bool sexo, int codigo)
        {
            this.Nombre = nombre;
            this.Sexo = sexo;
            this.Codigo = codigo;
            mascotas = new List<Mascota>();
        }

        public List<Mascota> ObtenerMascotas()
        {
            return mascotas;
        }

        public void AgregarMascota(Mascota mascota)
        {
            mascotas.Add(mascota);
        }
        public void ModificarCodMascota(int codMascota, int nuevoCodMascota)
        {

            foreach (var mascota in mascotas)
            {
                if (mascota.Codigo == codMascota)
                {
                    mascota.Codigo = nuevoCodMascota; 
                    break;
                }
            }

        }
        public void AgregarMascotas(List<Mascota> listaMascotas)
        {
            mascotas.AddRange(listaMascotas);
        }
        public string SexoString()
        {
            return Sexo ? "Masculino" : "Femenino";
        }
        public override string ToString()
        {
            return this.Codigo.ToString() + " - " + this.Nombre + " - " + this.SexoString(); ;
        }
    }
}
