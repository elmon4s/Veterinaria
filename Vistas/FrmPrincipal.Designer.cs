namespace Veterinaria.Vistas
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atencionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mascotasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pcbNuevaMascota = new System.Windows.Forms.PictureBox();
            this.pcbVerAtenciones = new System.Windows.Forms.PictureBox();
            this.pcbNuevoCliente = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNuevaMascota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbVerAtenciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNuevoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atencionesToolStripMenuItem1,
            this.clientesToolStripMenuItem1,
            this.mascotasToolStripMenuItem1});
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // atencionesToolStripMenuItem1
            // 
            this.atencionesToolStripMenuItem1.Name = "atencionesToolStripMenuItem1";
            this.atencionesToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.atencionesToolStripMenuItem1.Text = "Atenciones";
            this.atencionesToolStripMenuItem1.Click += new System.EventHandler(this.atencionesToolStripMenuItem1_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.clientesToolStripMenuItem1.Text = "Clientes";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // mascotasToolStripMenuItem1
            // 
            this.mascotasToolStripMenuItem1.Name = "mascotasToolStripMenuItem1";
            this.mascotasToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.mascotasToolStripMenuItem1.Text = "Mascotas";
            this.mascotasToolStripMenuItem1.Click += new System.EventHandler(this.mascotasToolStripMenuItem1_Click);
            // 
            // pcbNuevaMascota
            // 
            this.pcbNuevaMascota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbNuevaMascota.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbNuevaMascota.Image = global::Veterinaria.Properties.Resources.nueva_mascota;
            this.pcbNuevaMascota.InitialImage = null;
            this.pcbNuevaMascota.Location = new System.Drawing.Point(12, 210);
            this.pcbNuevaMascota.Name = "pcbNuevaMascota";
            this.pcbNuevaMascota.Size = new System.Drawing.Size(231, 172);
            this.pcbNuevaMascota.TabIndex = 3;
            this.pcbNuevaMascota.TabStop = false;
            this.pcbNuevaMascota.WaitOnLoad = true;
            this.pcbNuevaMascota.Click += new System.EventHandler(this.pcbNuevaMascota_Click);
            this.pcbNuevaMascota.MouseEnter += new System.EventHandler(this.pcbNuevaMascota_MouseEnter);
            this.pcbNuevaMascota.MouseLeave += new System.EventHandler(this.pcbNuevaMascota_MouseLeave);
            // 
            // pcbVerAtenciones
            // 
            this.pcbVerAtenciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbVerAtenciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbVerAtenciones.Image = global::Veterinaria.Properties.Resources.ver_atenciones;
            this.pcbVerAtenciones.InitialImage = null;
            this.pcbVerAtenciones.Location = new System.Drawing.Point(249, 32);
            this.pcbVerAtenciones.Name = "pcbVerAtenciones";
            this.pcbVerAtenciones.Size = new System.Drawing.Size(519, 350);
            this.pcbVerAtenciones.TabIndex = 2;
            this.pcbVerAtenciones.TabStop = false;
            this.pcbVerAtenciones.WaitOnLoad = true;
            this.pcbVerAtenciones.Click += new System.EventHandler(this.pcbVerAtenciones_Click);
            this.pcbVerAtenciones.MouseEnter += new System.EventHandler(this.pcbVerAtenciones_MouseEnter);
            this.pcbVerAtenciones.MouseLeave += new System.EventHandler(this.pcbVerAtenciones_MouseLeave);
            // 
            // pcbNuevoCliente
            // 
            this.pcbNuevoCliente.BackColor = System.Drawing.SystemColors.Control;
            this.pcbNuevoCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbNuevoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbNuevoCliente.Image = global::Veterinaria.Properties.Resources.nuevo_cliente;
            this.pcbNuevoCliente.InitialImage = null;
            this.pcbNuevoCliente.Location = new System.Drawing.Point(12, 32);
            this.pcbNuevoCliente.Name = "pcbNuevoCliente";
            this.pcbNuevoCliente.Size = new System.Drawing.Size(231, 172);
            this.pcbNuevoCliente.TabIndex = 1;
            this.pcbNuevoCliente.TabStop = false;
            this.pcbNuevoCliente.WaitOnLoad = true;
            this.pcbNuevoCliente.Click += new System.EventHandler(this.pcbNuevoCliente_Click);
            this.pcbNuevoCliente.MouseEnter += new System.EventHandler(this.pcbNuevoCliente_MouseEnter);
            this.pcbNuevoCliente.MouseLeave += new System.EventHandler(this.pcbNuevoCliente_MouseLeave);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 391);
            this.Controls.Add(this.pcbNuevaMascota);
            this.Controls.Add(this.pcbVerAtenciones);
            this.Controls.Add(this.pcbNuevoCliente);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(794, 430);
            this.MinimumSize = new System.Drawing.Size(794, 430);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNuevaMascota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbVerAtenciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNuevoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atencionesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mascotasToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pcbNuevoCliente;
        private System.Windows.Forms.PictureBox pcbVerAtenciones;
        private System.Windows.Forms.PictureBox pcbNuevaMascota;
    }
}