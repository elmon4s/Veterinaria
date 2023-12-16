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
using Veterinaria.Vistas.Clientes;
using Veterinaria.Vistas.Mascotas;

namespace Veterinaria.Vistas
{
    public partial class FrmMascotas : Form
    {
        DbHelper dbHelper = new DbHelper();
        public FrmMascotas()
        {
            InitializeComponent();
        }

        private void FrmMascotas_Load(object sender, EventArgs e)
        {
            Formulario.Cargar.Dtp(dtpAltaDes, dtpAltaAntes, Formulario.Tipos.Fecha.Anio, 2);
            CargarTipos();
            actualizarDgv();

        }

        private void CargarTipos()
        {
            List<TipoMascota> lstTipos = new List<TipoMascota>();
            lstTipos.Add(new TipoMascota(0,"Cualquier Tipo"));

            DataTable tabla = dbHelper.ObtenerTiposMascota();
            foreach (DataRow fila in tabla.Rows)
            {
                lstTipos.Add(new TipoMascota((int) fila.ItemArray[0], fila.ItemArray[1].ToString()));
            }
            Formulario.Cargar.Combo(cboTipo, lstTipos);
            cboTipo.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new FrmNuevaMascota().ShowDialog();
            actualizarDgv();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Int(txtEdad);
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            Formulario.Validar.Int(txtCodigo);
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            actualizarDgv();
        }

        private void actualizarDgv()
        {
            bool codValido = int.TryParse(txtCodigo.Text, out int codigo);

            DataTable tabla = dbHelper.ObtenerMascotas(
                dtpAltaDes.Value,
                dtpAltaAntes.Value,
                txtEdad.Text,
                codValido ? codigo : -1,
                (TipoMascota) cboTipo.SelectedItem,
                txtNombre.Text,
                txtNomCli.Text);

            dgvMascotas.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                dgvMascotas.Rows.Add(new object[]
                {
                    fila.ItemArray[0], // Cod
                    fila.ItemArray[1], // Cliente
                    fila.ItemArray[2], // Nombre
                    fila.ItemArray[3], // Tipo
                    fila.ItemArray[4], // Edad
                    fila.ItemArray[5], // Fecha Alta
                    "Ver atenciones",
                    fila.ItemArray[6], // Fecha Nac
                    fila.ItemArray[7], // Cod cliente
                    fila.ItemArray[8] // Cod tipo
                });
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedCells.Count <= 0)
                return;

            DataGridViewRow fila = dgvMascotas.Rows[dgvMascotas.SelectedCells[0].RowIndex];

            Mascota m = new Mascota((string) fila.Cells[2].Value, (DateTime) fila.Cells[7].Value, new TipoMascota((int) fila.Cells[9].Value, (string) fila.Cells[3].Value), (int) fila.Cells[0].Value);

            new FrmNuevaMascota(m, (int) fila.Cells[9].Value).ShowDialog();
            actualizarDgv();
        }

        private void dgvMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMascotas.CurrentCell.ColumnIndex == 6)
            {
                int codMascota = Convert.ToInt32(dgvMascotas.CurrentRow.Cells[0].Value);
                new FrmMascotaAtenciones(codMascota).ShowDialog();
            }
        }
    }
}
