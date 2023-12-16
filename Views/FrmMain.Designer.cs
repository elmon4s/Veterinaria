namespace Veterinaria.Vistas
{
    partial class FrmMain
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
            this.mstripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConsult = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttentions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClients = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPets = new System.Windows.Forms.ToolStripMenuItem();
            this.pcbNewPet = new System.Windows.Forms.PictureBox();
            this.pcbConsultAttentions = new System.Windows.Forms.PictureBox();
            this.pcbNewClient = new System.Windows.Forms.PictureBox();
            this.mstripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNewPet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbConsultAttentions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNewClient)).BeginInit();
            this.SuspendLayout();
            // 
            // mstripMain
            // 
            this.mstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiConsult});
            this.mstripMain.Location = new System.Drawing.Point(0, 0);
            this.mstripMain.Name = "mstripMain";
            this.mstripMain.Size = new System.Drawing.Size(778, 24);
            this.mstripMain.TabIndex = 0;
            this.mstripMain.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(60, 20);
            this.tsmiFile.Text = "Archivo";
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(180, 22);
            this.tsmiQuit.Text = "Salir";
            this.tsmiQuit.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tsmiConsult
            // 
            this.tsmiConsult.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAttentions,
            this.tsmiClients,
            this.tsmiPets});
            this.tsmiConsult.Name = "tsmiConsult";
            this.tsmiConsult.Size = new System.Drawing.Size(70, 20);
            this.tsmiConsult.Text = "Consultar";
            // 
            // tsmiAttentions
            // 
            this.tsmiAttentions.Name = "tsmiAttentions";
            this.tsmiAttentions.Size = new System.Drawing.Size(180, 22);
            this.tsmiAttentions.Text = "Atenciones";
            this.tsmiAttentions.Click += new System.EventHandler(this.atencionesToolStripMenuItem1_Click);
            // 
            // tsmiClients
            // 
            this.tsmiClients.Name = "tsmiClients";
            this.tsmiClients.Size = new System.Drawing.Size(180, 22);
            this.tsmiClients.Text = "Clientes";
            this.tsmiClients.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // tsmiPets
            // 
            this.tsmiPets.Name = "tsmiPets";
            this.tsmiPets.Size = new System.Drawing.Size(180, 22);
            this.tsmiPets.Text = "Mascotas";
            this.tsmiPets.Click += new System.EventHandler(this.mascotasToolStripMenuItem1_Click);
            // 
            // pcbNewPet
            // 
            this.pcbNewPet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbNewPet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbNewPet.Image = global::Veterinaria.Properties.Resources.nueva_mascota;
            this.pcbNewPet.InitialImage = null;
            this.pcbNewPet.Location = new System.Drawing.Point(12, 210);
            this.pcbNewPet.Name = "pcbNewPet";
            this.pcbNewPet.Size = new System.Drawing.Size(231, 172);
            this.pcbNewPet.TabIndex = 3;
            this.pcbNewPet.TabStop = false;
            this.pcbNewPet.WaitOnLoad = true;
            this.pcbNewPet.Click += new System.EventHandler(this.pcbNuevaMascota_Click);
            this.pcbNewPet.MouseEnter += new System.EventHandler(this.pcbNuevaMascota_MouseEnter);
            this.pcbNewPet.MouseLeave += new System.EventHandler(this.pcbNuevaMascota_MouseLeave);
            // 
            // pcbConsultAttentions
            // 
            this.pcbConsultAttentions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbConsultAttentions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbConsultAttentions.Image = global::Veterinaria.Properties.Resources.ver_atenciones;
            this.pcbConsultAttentions.InitialImage = null;
            this.pcbConsultAttentions.Location = new System.Drawing.Point(249, 32);
            this.pcbConsultAttentions.Name = "pcbConsultAttentions";
            this.pcbConsultAttentions.Size = new System.Drawing.Size(519, 350);
            this.pcbConsultAttentions.TabIndex = 2;
            this.pcbConsultAttentions.TabStop = false;
            this.pcbConsultAttentions.WaitOnLoad = true;
            this.pcbConsultAttentions.Click += new System.EventHandler(this.pcbVerAtenciones_Click);
            this.pcbConsultAttentions.MouseEnter += new System.EventHandler(this.pcbVerAtenciones_MouseEnter);
            this.pcbConsultAttentions.MouseLeave += new System.EventHandler(this.pcbVerAtenciones_MouseLeave);
            // 
            // pcbNewClient
            // 
            this.pcbNewClient.BackColor = System.Drawing.SystemColors.Control;
            this.pcbNewClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbNewClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbNewClient.Image = global::Veterinaria.Properties.Resources.nuevo_cliente;
            this.pcbNewClient.InitialImage = null;
            this.pcbNewClient.Location = new System.Drawing.Point(12, 32);
            this.pcbNewClient.Name = "pcbNewClient";
            this.pcbNewClient.Size = new System.Drawing.Size(231, 172);
            this.pcbNewClient.TabIndex = 1;
            this.pcbNewClient.TabStop = false;
            this.pcbNewClient.WaitOnLoad = true;
            this.pcbNewClient.Click += new System.EventHandler(this.pcbNuevoCliente_Click);
            this.pcbNewClient.MouseEnter += new System.EventHandler(this.pcbNuevoCliente_MouseEnter);
            this.pcbNewClient.MouseLeave += new System.EventHandler(this.pcbNuevoCliente_MouseLeave);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 391);
            this.Controls.Add(this.pcbNewPet);
            this.Controls.Add(this.pcbConsultAttentions);
            this.Controls.Add(this.pcbNewClient);
            this.Controls.Add(this.mstripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mstripMain;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(794, 430);
            this.MinimumSize = new System.Drawing.Size(794, 430);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.mstripMain.ResumeLayout(false);
            this.mstripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNewPet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbConsultAttentions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNewClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmiConsult;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttentions;
        private System.Windows.Forms.ToolStripMenuItem tsmiClients;
        private System.Windows.Forms.ToolStripMenuItem tsmiPets;
        private System.Windows.Forms.PictureBox pcbNewClient;
        private System.Windows.Forms.PictureBox pcbConsultAttentions;
        private System.Windows.Forms.PictureBox pcbNewPet;
    }
}