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
using Veterinaria.Vistas.Atenciones;
using Veterinaria.Vistas.Clientes;

namespace Veterinaria.Vistas
{
    public partial class FrmClientes : Form
    {
        string accion = "Ver Mascotas";
        bool selec;
        DbHelper dbHelper = new DbHelper();
        public Cliente cliente;

        public FrmClientes(bool seleccionar = false)
        {
            InitializeComponent();
            selec = seleccionar;
            if (selec)
            {
                btnBorrar.Visible = false;
                btnModificar.Visible = false;
                btnNuevo.Location = btnBorrar.Location;
                accion = "Seleccionar";
            }
        }
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Formulario.Cargar.Dtp(dtpDesde, dtpHasta, Formulario.Tipos.Fecha.Anio, 2);
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            actualizarDgv();
        }

        private void actualizarDgv()
        {
            bool codValido = int.TryParse(txtCodigo.Text, out int codigo);

            DataTable tabla = dbHelper.ObtenerClientes(
                dtpDesde.Value,
                dtpHasta.Value,
                codValido ? codigo : -1,
                txtNombre.Text,
                chbFemenino.Checked,
                chbMasculino.Checked);
            dgvClientes.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgvClientes.Rows.Add(new object[]
                {
                    fila.ItemArray[0],
                    fila.ItemArray[1],
                    (bool) fila.ItemArray[2] ? "Masculino" : "Femenino",
                    fila.ItemArray[3],
                    accion
                });
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count <= 0)
                return;

            DataGridViewRow fila = dgvClientes.Rows[dgvClientes.SelectedCells[0].RowIndex];

            new FrmNuevoCliente((int)fila.Cells[0].Value).ShowDialog();

            actualizarDgv();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count <= 0)
                return;

            DataGridViewRow fila = dgvClientes.Rows[dgvClientes.SelectedCells[0].RowIndex];

            if (Formulario.Mensaje.Confirmacion("¿Seguro que quieres borrar este cliente? Se borraran TODAS sus MASCOTAS y ATENCIONES", "CUIDADO") != DialogResult.Yes)
                return;
            if (dbHelper.BajarCliente((int)fila.Cells[0].Value))
                Formulario.Mensaje.Informacion("Cliente borrado con éxito", "ÉXITO");
            else
                Formulario.Mensaje.Error("Error al borrar cliente", "ERROR");
            actualizarDgv();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente(selec);
            if (frmNuevoCliente.ShowDialog() == DialogResult.OK && selec)
            {
                cliente = frmNuevoCliente.cliente;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            actualizarDgv();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 4)
            {
                if (selec)
                {
                    DataGridViewRow fila = dgvClientes.CurrentRow;
                    cliente = new Cliente((string) fila.Cells[1].Value, (string) fila.Cells[2].Value == "Masculino", (int) fila.Cells[0].Value);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
