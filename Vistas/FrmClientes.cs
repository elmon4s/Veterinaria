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

namespace Veterinaria
{
    public partial class FrmClientes : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        AccesoDatos AccesoDatos = new AccesoDatos();
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            clientes.Clear();
            DataTable tabla = AccesoDatos.ObetenerClientes();
            foreach (DataRow fila in tabla.Rows)
            {
                clientes.Add(new Cliente(fila.ItemArray[0].ToString(), (bool) fila.ItemArray[1], (int) fila.ItemArray[2]));
            }
            CargarCombo(cboClientes, clientes);
        }
        private List<Mascota> CargarMascotas(int codCliente)
        {
            List<Mascota> lstMascotas = new List<Mascota>();
            DataTable tabla = AccesoDatos.ObtenerMascotas(codCliente);
            foreach (DataRow fila in tabla.Rows)
            {
                lstMascotas.Add(new Mascota(fila.ItemArray[0].ToString(), (int)fila.ItemArray[1], new TipoMascota(fila.ItemArray[2].ToString()), (int)fila.ItemArray[3]));
            }
            CargarCombo(cboMascotas, lstMascotas);
            return lstMascotas;
        }
        private List<Atencion> CargarAtenciones(int codMascota)
        {
            List<Atencion> lstAtenciones = new List<Atencion>();
            DataTable tabla = AccesoDatos.ObtenerAtenciones(codMascota);
            dgvAtenciones.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                Atencion a = new Atencion((int)fila.ItemArray[0], fila.ItemArray[1].ToString(), (decimal)fila.ItemArray[2], (DateTime)fila.ItemArray[3]);
                lstAtenciones.Add(a);
                dgvAtenciones.Rows.Add(new object[]
                {
                    a.Codigo.ToString(),
                    a.Descripcion.ToString(),
                    a.FechaAtencion.ToString(),
                    a.Importe.ToString(),
                    "Eliminar"
                });
            }
            return lstAtenciones;
        }
        private void CargarCombo<T>(ComboBox combo, List<T> lista)
        {
            combo.Items.Clear();
            foreach (T item in lista)
            {
                combo.Items.Add(item);
            }
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            gboAtencion.Enabled = false;
            dgvAtenciones.Enabled = false;
            Cliente cliente = (Cliente) cboClientes.SelectedItem;
            cliente.AgregarMascotas(CargarMascotas(cliente.Codigo));
            cboMascotas.Enabled = true;
        }

        private void cboMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mascota mascota = (Mascota) cboMascotas.SelectedItem;
            mascota.Atenciones = CargarAtenciones(mascota.Codigo);
            dgvAtenciones.Enabled = true;
            gboAtencion.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text.Length < 1)
            {
                MessageBox.Show("El campo descripción no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!Decimal.TryParse(txtImporte.Text, out decimal num))
            {
                MessageBox.Show("El campo importe debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Mascota m = (Mascota) cboMascotas.SelectedItem;
            Atencion a = new Atencion(txtDescripcion.Text, Convert.ToDecimal(txtImporte.Text), DateTime.Now);
            AccesoDatos.AgregarAtencion(m.Codigo, a);
            m.Atenciones = CargarAtenciones(m.Codigo);
        }
    }
}