using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.AdmDatos;
using Veterinaria.Dominio;
using Veterinaria.Utilidades;
using Veterinaria.Vistas.Mascotas;

namespace Veterinaria.Vistas.Clientes
{
    public partial class FrmNuevoCliente : Form
    {
        public Cliente cliente;
        DbHelper dbHelper = new DbHelper();
        List<Mascota> lstMascotas = new List<Mascota>();
        bool selec;
        public FrmNuevoCliente(bool seleccionar = false)
        {
            InitializeComponent();
            selec = seleccionar;

        }
        public FrmNuevoCliente(int cod)
        {
            InitializeComponent();
            selec = false;
            cliente = dbHelper.ObtenerCliente(cod);
        }
        private List<Mascota> CargarMascotas(int codCliente)
        {
            List<Mascota> lstMascotas = new List<Mascota>();
            DataTable tabla = dbHelper.ObtenerMascotas(codCliente);
            dgvMascotas.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                Mascota m = new Mascota(fila.ItemArray[0].ToString(), (int)fila.ItemArray[1], new TipoMascota((int)fila.ItemArray[4], fila.ItemArray[2].ToString()), (int)fila.ItemArray[3]);
                lstMascotas.Add(m);
                dgvMascotas.Rows.Add(new object[]
                {
                    m.Codigo.ToString(),
                    m.Nombre,
                    m.TipoMascota.Nombre,
                    m.Edad.ToString(),
                    "Eliminar"
                });
            }

            return lstMascotas;
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            rbtFemenino.Checked = true;
            if (selec)
            {
                lblMascotas.Visible = false;
                btnAgregarMascota.Visible = false;
                dgvMascotas.Visible = false;
                btnAceptar.Location = new Point(559, 145);
                btnVolver.Location = new Point(12, 145);
                this.MaximumSize = this.MaximumSize = this.Size = new Size(668, 211);
            }
            if (cliente != null)
            {
                this.Text = "Modificar Cliente";
                txtNombre.Text = cliente.Nombre;

                rbtMasculino.Checked = cliente.Sexo;
                rbtFemenino.Checked = !cliente.Sexo;

                cliente.AgregarMascotas(CargarMascotas(cliente.Codigo));
            }
        }


        private void btnAgregarMascota_Click(object sender, EventArgs e)
        {
            bool existeCliente = cliente != null;
            if (!existeCliente)
                cliente = new Cliente(txtNombre.Text, rbtMasculino.Checked, 0);
            FrmNuevaMascota form = new FrmNuevaMascota(cliente);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Mascota m = cliente.ObtenerMascotas().Last();

                dgvMascotas.Rows.Add(new object[]
                {
                    m.Codigo.ToString(),
                    m.Nombre,
                    m.TipoMascota.Nombre,
                    m.Edad.ToString(),
                    "Eliminar"
                });
                if (!existeCliente)
                {
                    lstMascotas = cliente.ObtenerMascotas();
                    cliente = null;
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            cliente = null;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length < 0 && Formulario.Mensaje.Confirmacion("¿Está seguro que quiere dejar a este cliente SIN NOMBRE", "CONFIRMAR") == DialogResult.No)
                return;
            if (selec)
            {
                cliente = new Cliente(txtNombre.Text, rbtMasculino.Checked, 0);
                cliente.AgregarMascotas(lstMascotas);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (cliente != null)
                {
                    cliente.Nombre = txtNombre.Text;
                    cliente.Sexo = rbtMasculino.Checked;
                    if (dbHelper.ModificarCliente(cliente, false))
                    {
                        Formulario.Mensaje.Informacion("Cliente modificado con éxito", "ÉXITO AL MODIFICAR");
                        this.Close();
                    }
                    else
                    {
                        Formulario.Mensaje.Error("No se pudo modificar el cliente", "ERROR AL MODIFICAR");
                    }
                }
                else
                {
                    cliente = new Cliente(txtNombre.Text, rbtMasculino.Checked, 0);
                    cliente.AgregarMascotas(lstMascotas);

                    if (dbHelper.ModificarCliente(cliente, true))
                    {
                        Formulario.Mensaje.Informacion("Cliente agregado con éxito", "ÉXITO AL AGREGAR");
                        this.Close();
                    }
                    else
                    {
                        Formulario.Mensaje.Error("No se pudo agregar al cliente", "ERROR AL AGREGAR");
                    }
                }
            }
        }

        private void dgvMascotas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvMascotas.CurrentCell.ColumnIndex == 4)
            {
                int codMascota = Convert.ToInt32(dgvMascotas.CurrentRow.Cells[0].Value);
                dgvMascotas.CurrentRow.Cells[0].Value = codMascota * -1;

                cliente.ModificarCodMascota(codMascota, codMascota * -1);
                dgvMascotas.Rows.RemoveAt(dgvMascotas.CurrentRow.Index);
            }
        }
    }
}
