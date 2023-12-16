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
    public partial class FrmNuevaMascota : Form
    {
        Cliente duenio;
        bool nuevoDuenio = false;
        DbHelper dbHelper = new DbHelper();
        Mascota mascota;
        List<Atencion> atenciones = new List<Atencion>();
        public FrmNuevaMascota(Cliente cliente = null)
        {
            InitializeComponent();
            duenio = cliente;
            
            if (cliente == null)
                btnCliente.Visible = true;
            else
            {
                lblCliente.Text = $"Cliente: {cliente}";
                nuevoDuenio = true;
            }
        }
        public FrmNuevaMascota(Mascota m, int codCliente)
        {
            InitializeComponent();
            duenio = dbHelper.ObtenerCliente(codCliente);
            mascota = m;
            lblCliente.Text = $"Cliente: {duenio}";
            this.Text = "Modificar Mascota";
        }
        private void btnNuevoTipo_Click(object sender, EventArgs e)
        {
            FrmNuevoTipo nuevoTipo = new FrmNuevoTipo();
            if (nuevoTipo.ShowDialog() == DialogResult.OK)
                CargarTipos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes(true);
            if (frmClientes.ShowDialog() == DialogResult.OK)
            {
                duenio = frmClientes.cliente;
                lblCliente.Text = $"Cliente: {duenio}";
                btnCliente.Visible = false;
            }
        }

        private void btnAtencion_Click(object sender, EventArgs e)
        {
            FrmMascotaAtenciones frmAtenciones = new FrmMascotaAtenciones(mascota != null ? mascota.Codigo : 0);
           
            if (frmAtenciones.ShowDialog() == DialogResult.OK)
            {
                if (mascota == null)
                    atenciones = frmAtenciones.Atenciones;
                else
                    mascota.Atenciones = frmAtenciones.Atenciones;
            }
        }

        private void FrmNuevaMascota_Load(object sender, EventArgs e)
        {
            if (mascota != null)
            {
                txtNombre.Text = mascota.Nombre;
                cboTipo.SelectedItem = mascota.TipoMascota;
                dtpFechaNac.Value = mascota.FechaNacimiento;
            }
            CargarTipos();
        }
        private void CargarTipos()
        {
            List<TipoMascota> lstTipos = new List<TipoMascota>();

            DataTable tabla = dbHelper.ObtenerTiposMascota();
            foreach (DataRow fila in tabla.Rows)
            {
                lstTipos.Add(new TipoMascota((int)fila.ItemArray[0], fila.ItemArray[1].ToString()));
            }

            Formulario.Cargar.Combo(cboTipo, lstTipos);
            cboTipo.SelectedIndex = 0;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (duenio == null)
            {
                Formulario.Mensaje.Error("Debes seleccionar un CLIENTE primero.", "ERROR");
                return;
            }
            if (mascota != null)
            {
                if (!dbHelper.ModificarMascota(mascota, duenio, false))
                {
                    Formulario.Mensaje.Error("No se pudo modificar la mascota", "ERRROR AL MODIFICAR MASCOTA");
                }
                else
                {
                    Formulario.Mensaje.Informacion("La mascota se modificó con éxito", "ÉXITO AL MODIFICAR MASCOTA");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                Mascota m = new Mascota(txtNombre.Text, dtpFechaNac.Value, (TipoMascota) cboTipo.SelectedItem, 0);
                m.Atenciones = atenciones;
                if (m.Nombre.Length < 0 && Formulario.Mensaje.Confirmacion("¿Está seguro que quiere dejar a esta mascota SIN NOMBRE", "CONFIRMAR") == DialogResult.No)
                    return;

                if (nuevoDuenio)
                {
                    duenio.AgregarMascota(m);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (!dbHelper.ModificarMascota(m, duenio, true))
                    {
                        Formulario.Mensaje.Error("No se pudo agregar la mascota", "ERRROR AL AGREGAR MASCOTA");
                    }
                    else
                    {
                        Formulario.Mensaje.Informacion("La mascota se agregó con éxito", "ÉXITO AL AGREGAR MASCOTA");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
    }
}
