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

namespace Veterinaria.Vistas.Atenciones
{
    public partial class FrmModificarAtencion : Form
    {
        DbHelper dbHelper = new DbHelper();
        Atencion atencion;
        public FrmModificarAtencion(int codAtencion)
        {
            InitializeComponent();
            atencion = dbHelper.ObtenerAtencion(codAtencion);
        }

        private void FrmModificarAtencion_Load(object sender, EventArgs e)
        {
            txtDescripcion.Text = atencion.Descripcion;
            txtImporte.Text = atencion.Importe.ToString();
            dtpFecha.Value = atencion.FechaAtencion;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Decimal(txtImporte);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            atencion.FechaAtencion = dtpFecha.Value;
            atencion.Importe = decimal.Parse(txtImporte.Text);
            atencion.Descripcion = txtDescripcion.Text;

            if (dbHelper.ModificarAtencion(atencion))
            {
                Formulario.Mensaje.Informacion("Atención modificada con éxito", "ÉXITO");
                this.Close();
            }
            else
                Formulario.Mensaje.Error("Error al modificar atención", "ERROR");
        }
    }
}
