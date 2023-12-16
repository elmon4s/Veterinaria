using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Utilidades;
using Veterinaria.Vistas.Atenciones;
using Veterinaria.Vistas.Clientes;
using Veterinaria.Vistas.Mascotas;

namespace Veterinaria.Vistas
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmClientes().ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mascotasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmMascotas().ShowDialog();
        }

        private void atencionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FrmAtenciones().ShowDialog();
        }

        private void pcbNuevoCliente_Click(object sender, EventArgs e)
        {
            new FrmNuevoCliente().ShowDialog();
        }

        private void pcbNuevaMascota_Click(object sender, EventArgs e)
        {
            new FrmNuevaMascota().ShowDialog();
        }

        private void pcbVerAtenciones_Click(object sender, EventArgs e)
        {
            new FrmAtenciones().ShowDialog();
        }

        private void pcbNuevoCliente_MouseEnter(object sender, EventArgs e)
        {
            pcbNewClient.BackColor = SystemColors.ButtonShadow;
        }

        private void pcbNuevoCliente_MouseLeave(object sender, EventArgs e)
        {
            pcbNewClient.BackColor = SystemColors.Control;
        }

        private void pcbNuevaMascota_MouseEnter(object sender, EventArgs e)
        {
            pcbNewPet.BackColor = SystemColors.ButtonShadow;
        }

        private void pcbNuevaMascota_MouseLeave(object sender, EventArgs e)
        {
            pcbNewPet.BackColor = SystemColors.Control;
        }

        private void pcbVerAtenciones_MouseEnter(object sender, EventArgs e)
        {
            pcbConsultAttentions.BackColor = SystemColors.ButtonShadow;
        }

        private void pcbVerAtenciones_MouseLeave(object sender, EventArgs e)
        {
            pcbConsultAttentions.BackColor = SystemColors.Control;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Formulario.Mensaje.Informacion("La base de datos fue actualizada con nuevos procedimientos almacenados y se modificaron algunas tablas. Por favor dropear base anterior y ejecutar scrpit de nuevo. Para deshabilitar este mensaje cambiar variable en Program.cs", "CUIDADO");
        }
    }
}
