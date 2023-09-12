using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.AdmDatos;
using Veterinaria.Dominio;
using Veterinaria.Utilidades;

namespace Veterinaria.Vistas.Mascotas
{
    public partial class FrmNuevoTipo : Form
    {
        DbHelper dbHelper = new DbHelper();
        public FrmNuevoTipo()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TipoMascota tipo = new TipoMascota(0, txtNombre.Text);
            if (tipo.Nombre.Length < 1 && Formulario.Mensaje.Confirmacion("¿Está seguro que quiere agregar un tipo de mascota VACIO?", "CONFIRMAR") == DialogResult.No)
                return;
            if (dbHelper.AgregarTipoMascota(tipo))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FrmNuevoTipo_Load(object sender, EventArgs e)
        {

        }
    }
}
