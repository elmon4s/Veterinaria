using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.AdmDatos;
using Veterinaria.Dominio;
using Veterinaria.Utilidades;

namespace Veterinaria
{
    public partial class FrmMascotaAtenciones : Form
    {
        public List<Atencion> Atenciones = new List<Atencion>();
        DbHelper dbHelper = new DbHelper();
        int codigo;
        public FrmMascotaAtenciones(int codMascota)
        {
            InitializeComponent();
            codigo = codMascota;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            if(codigo > 0)
                Atenciones = CargarAtenciones(codigo);
        }

        private List<Atencion> CargarAtenciones(int codMascota)
        {
            List<Atencion> lstAtenciones = new List<Atencion>();
            DataTable tabla = dbHelper.ObtenerAtenciones(codMascota);
            dgvAtenciones.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                Atencion a = new Atencion((int)fila.ItemArray[0], fila.ItemArray[1].ToString(), (decimal)fila.ItemArray[2], (DateTime)fila.ItemArray[3]);
                lstAtenciones.Add(a);
                dgvAtenciones.Rows.Add(new object[]
                {
                    a.Codigo.ToString(),
                    a.Descripcion.ToString(),
                    a.FechaAtencion.ToString("dd/MM/yyyy"),
                    a.Importe.ToString(),
                    "Eliminar"
                });
            }
            return lstAtenciones;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length < 1 && Formulario.Mensaje.Confirmacion("¿Seguro que quiere agregar una atencion SIN DESCRIPCIÓN?", "CUIDADO") == DialogResult.No)
                return;
            if (txtImporte.Text.Length <= 0 && Formulario.Mensaje.Confirmacion("¿Seguro que quiere agregar una atencion con IMPORTE IGUAL/INFERIOR A 0?", "CUIDADO") == DialogResult.No)
                return;
            Atencion a = new Atencion(txtDescripcion.Text, Convert.ToDecimal(txtImporte.Text), DateTime.Now);
            Atenciones.Add(a);
            dgvAtenciones.Rows.Add(new object[]
                {
                    a.Codigo.ToString(),
                    a.Descripcion.ToString(),
                    a.FechaAtencion.ToString("dd/MM/yyyy"),
                    a.Importe.ToString(),
                    "Eliminar"
                });
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Decimal(txtImporte);
        }
    }
}