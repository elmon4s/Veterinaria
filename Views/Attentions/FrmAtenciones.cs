using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.AdmDatos;
using Veterinaria.Dominio;
using Veterinaria.Utilidades;

namespace Veterinaria.Vistas.Atenciones
{
    public partial class FrmAtenciones : Form
    {
        DbHelper dbHelper = new DbHelper();
        public FrmAtenciones()
        {
            InitializeComponent();
        }

        private void FrmAtenciones_Load(object sender, EventArgs e)
        {
            Formulario.Cargar.Dtp(dtpDespues, dtpAntes, Formulario.Tipos.Fecha.Anio, 2);
            actualizarDgv();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Int(txtCodigo);
        }

        private void txtImporteMin_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Decimal(txtImporteMin);
        }

        private void txtImporteMax_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Decimal(txtImporteMax);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            actualizarDgv();
        }
        private void actualizarDgv()
        {
            bool codValido = int.TryParse(txtCodigo.Text, out int codigo);
            bool importeMinValido = decimal.TryParse(txtImporteMin.Text, out decimal importeMin);
            bool importeMaxValido = decimal.TryParse(txtImporteMax.Text, out decimal importeMax);
            DataTable tabla = dbHelper.ObtenerAtenciones(
                dtpDespues.Value,
                dtpAntes.Value,
                codValido ? codigo : -1,
                importeMinValido ? importeMin : -10000000000,
                importeMaxValido ? importeMax : 10000000000,
                txtNombreCli.Text,
                txtNombreMas.Text,
                txtDescripcion.Text);
            dgvAtenciones.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgvAtenciones.Rows.Add(new object[]
                {
                    fila.ItemArray[0],
                    fila.ItemArray[1],
                    fila.ItemArray[2],
                    fila.ItemArray[3],
                    fila.ItemArray[4],
                    fila.ItemArray[5]
                });
            }
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAtenciones.SelectedCells.Count <= 0)
                return;

            DataGridViewRow fila = dgvAtenciones.Rows[dgvAtenciones.SelectedCells[0].RowIndex];

            if (Formulario.Mensaje.Confirmacion("¿Seguro que quieres borrar esta atención?", "CUIDADO") != DialogResult.Yes)
                return;
            if (dbHelper.BajarAtencion((int) fila.Cells[0].Value))
                Formulario.Mensaje.Informacion("Atención borrada con éxito", "ÉXITO");
            else
                Formulario.Mensaje.Error("Error al borrar atención", "ERROR");
            actualizarDgv();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAtenciones.SelectedCells.Count <= 0)
                return;

            DataGridViewRow fila = dgvAtenciones.Rows[dgvAtenciones.SelectedCells[0].RowIndex];

            new FrmModificarAtencion((int) fila.Cells[0].Value).ShowDialog();

            actualizarDgv();
        }
    }
}
