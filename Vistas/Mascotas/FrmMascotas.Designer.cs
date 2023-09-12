namespace Veterinaria.Vistas
{
    partial class FrmMascotas
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtNomCli = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblFechaAltaAnt = new System.Windows.Forms.Label();
            this.dtpAltaAntes = new System.Windows.Forms.DateTimePicker();
            this.dtpAltaDes = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dgvMascotas = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.fechaNac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(632, 423);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.txtEdad);
            this.grpFiltros.Controls.Add(this.lblEdad);
            this.grpFiltros.Controls.Add(this.txtNomCli);
            this.grpFiltros.Controls.Add(this.lblNombreCliente);
            this.grpFiltros.Controls.Add(this.lblFechaAltaAnt);
            this.grpFiltros.Controls.Add(this.dtpAltaAntes);
            this.grpFiltros.Controls.Add(this.dtpAltaDes);
            this.grpFiltros.Controls.Add(this.lblFechaAlta);
            this.grpFiltros.Controls.Add(this.lblTipo);
            this.grpFiltros.Controls.Add(this.cboTipo);
            this.grpFiltros.Controls.Add(this.txtCodigo);
            this.grpFiltros.Controls.Add(this.lblCodigo);
            this.grpFiltros.Controls.Add(this.btnConsultar);
            this.grpFiltros.Controls.Add(this.txtNombre);
            this.grpFiltros.Controls.Add(this.lblNombre);
            this.grpFiltros.Location = new System.Drawing.Point(25, 24);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(844, 172);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(120, 60);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(157, 20);
            this.txtEdad.TabIndex = 2;
            this.txtEdad.TextChanged += new System.EventHandler(this.txtEdad_TextChanged);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(78, 63);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(35, 13);
            this.lblEdad.TabIndex = 22;
            this.lblEdad.Text = "Edad:";
            // 
            // txtNomCli
            // 
            this.txtNomCli.Location = new System.Drawing.Point(120, 112);
            this.txtNomCli.Name = "txtNomCli";
            this.txtNomCli.Size = new System.Drawing.Size(637, 20);
            this.txtNomCli.TabIndex = 5;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(32, 115);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(82, 13);
            this.lblNombreCliente.TabIndex = 20;
            this.lblNombreCliente.Text = "Nombre Cliente:";
            // 
            // lblFechaAltaAnt
            // 
            this.lblFechaAltaAnt.AutoSize = true;
            this.lblFechaAltaAnt.Location = new System.Drawing.Point(257, 34);
            this.lblFechaAltaAnt.Name = "lblFechaAltaAnt";
            this.lblFechaAltaAnt.Size = new System.Drawing.Size(52, 13);
            this.lblFechaAltaAnt.TabIndex = 19;
            this.lblFechaAltaAnt.Text = "Antes de:";
            // 
            // dtpAltaAntes
            // 
            this.dtpAltaAntes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAltaAntes.Location = new System.Drawing.Point(315, 30);
            this.dtpAltaAntes.Name = "dtpAltaAntes";
            this.dtpAltaAntes.Size = new System.Drawing.Size(104, 20);
            this.dtpAltaAntes.TabIndex = 1;
            // 
            // dtpAltaDes
            // 
            this.dtpAltaDes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAltaDes.Location = new System.Drawing.Point(134, 30);
            this.dtpAltaDes.Name = "dtpAltaDes";
            this.dtpAltaDes.Size = new System.Drawing.Size(104, 20);
            this.dtpAltaDes.TabIndex = 0;
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Location = new System.Drawing.Point(47, 34);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(81, 13);
            this.lblFechaAlta.TabIndex = 16;
            this.lblFechaAlta.Text = "Alta depues de:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(317, 89);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 15;
            this.lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(354, 86);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(264, 21);
            this.cboTipo.TabIndex = 4;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(120, 86);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(157, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(70, 89);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "Código:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(763, 135);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 137);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(637, 20);
            this.txtNombre.TabIndex = 6;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(66, 140);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(25, 423);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(713, 423);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(794, 423);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 4;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            // 
            // dgvMascotas
            // 
            this.dgvMascotas.AllowUserToAddRows = false;
            this.dgvMascotas.AllowUserToDeleteRows = false;
            this.dgvMascotas.AllowUserToResizeColumns = false;
            this.dgvMascotas.AllowUserToResizeRows = false;
            this.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMascotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.cliente,
            this.nombre,
            this.tipo,
            this.edad,
            this.fechaAlta,
            this.acciones,
            this.fechaNac,
            this.codCliente,
            this.codTipo});
            this.dgvMascotas.Location = new System.Drawing.Point(25, 202);
            this.dgvMascotas.Name = "dgvMascotas";
            this.dgvMascotas.ReadOnly = true;
            this.dgvMascotas.Size = new System.Drawing.Size(844, 210);
            this.dgvMascotas.TabIndex = 7;
            this.dgvMascotas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMascotas_CellContentClick);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Width = 50;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 200;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 200;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // edad
            // 
            this.edad.HeaderText = "Edad";
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            this.edad.Width = 50;
            // 
            // fechaAlta
            // 
            this.fechaAlta.HeaderText = "Fecha de Alta";
            this.fechaAlta.Name = "fechaAlta";
            this.fechaAlta.ReadOnly = true;
            // 
            // acciones
            // 
            this.acciones.HeaderText = "Acciones";
            this.acciones.Name = "acciones";
            this.acciones.ReadOnly = true;
            this.acciones.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.acciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fechaNac
            // 
            this.fechaNac.HeaderText = "fechaNac";
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.ReadOnly = true;
            this.fechaNac.Visible = false;
            // 
            // codCliente
            // 
            this.codCliente.HeaderText = "codCliente";
            this.codCliente.Name = "codCliente";
            this.codCliente.ReadOnly = true;
            this.codCliente.Visible = false;
            // 
            // codTipo
            // 
            this.codTipo.HeaderText = "codTipo";
            this.codTipo.Name = "codTipo";
            this.codTipo.ReadOnly = true;
            this.codTipo.Visible = false;
            // 
            // FrmMascotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 462);
            this.ControlBox = false;
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dgvMascotas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(911, 501);
            this.MinimumSize = new System.Drawing.Size(911, 501);
            this.Name = "FrmMascotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mascotas";
            this.Load += new System.EventHandler(this.FrmMascotas_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dgvMascotas;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblFechaAltaAnt;
        private System.Windows.Forms.DateTimePicker dtpAltaAntes;
        private System.Windows.Forms.DateTimePicker dtpAltaDes;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.TextBox txtNomCli;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAlta;
        private System.Windows.Forms.DataGridViewButtonColumn acciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNac;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTipo;
    }
}