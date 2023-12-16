namespace Veterinaria.Vistas.Atenciones
{
    partial class FrmAtenciones
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
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblImporteMax = new System.Windows.Forms.Label();
            this.lblImporteMin = new System.Windows.Forms.Label();
            this.txtImporteMax = new System.Windows.Forms.TextBox();
            this.txtImporteMin = new System.Windows.Forms.TextBox();
            this.lblNombreMas = new System.Windows.Forms.Label();
            this.lblNombreCli = new System.Windows.Forms.Label();
            this.txtNombreMas = new System.Windows.Forms.TextBox();
            this.txtNombreCli = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblFechaNacAnt = new System.Windows.Forms.Label();
            this.dtpAntes = new System.Windows.Forms.DateTimePicker();
            this.dtpDespues = new System.Windows.Forms.DateTimePicker();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.dgvAtenciones = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mascota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtenciones)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblImporteMax);
            this.grpFiltros.Controls.Add(this.lblImporteMin);
            this.grpFiltros.Controls.Add(this.txtImporteMax);
            this.grpFiltros.Controls.Add(this.txtImporteMin);
            this.grpFiltros.Controls.Add(this.lblNombreMas);
            this.grpFiltros.Controls.Add(this.lblNombreCli);
            this.grpFiltros.Controls.Add(this.txtNombreMas);
            this.grpFiltros.Controls.Add(this.txtNombreCli);
            this.grpFiltros.Controls.Add(this.txtCodigo);
            this.grpFiltros.Controls.Add(this.lblCodigo);
            this.grpFiltros.Controls.Add(this.btnConsultar);
            this.grpFiltros.Controls.Add(this.txtDescripcion);
            this.grpFiltros.Controls.Add(this.lblDescripcion);
            this.grpFiltros.Controls.Add(this.lblFechaNacAnt);
            this.grpFiltros.Controls.Add(this.dtpAntes);
            this.grpFiltros.Controls.Add(this.dtpDespues);
            this.grpFiltros.Controls.Add(this.lblFechaDesde);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(1104, 175);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros";
            // 
            // lblImporteMax
            // 
            this.lblImporteMax.AutoSize = true;
            this.lblImporteMax.Location = new System.Drawing.Point(487, 65);
            this.lblImporteMax.Name = "lblImporteMax";
            this.lblImporteMax.Size = new System.Drawing.Size(84, 13);
            this.lblImporteMax.TabIndex = 21;
            this.lblImporteMax.Text = "Importe Máximo:";
            // 
            // lblImporteMin
            // 
            this.lblImporteMin.AutoSize = true;
            this.lblImporteMin.Location = new System.Drawing.Point(292, 65);
            this.lblImporteMin.Name = "lblImporteMin";
            this.lblImporteMin.Size = new System.Drawing.Size(83, 13);
            this.lblImporteMin.TabIndex = 20;
            this.lblImporteMin.Text = "Importe Mínimo:";
            // 
            // txtImporteMax
            // 
            this.txtImporteMax.Location = new System.Drawing.Point(577, 62);
            this.txtImporteMax.Name = "txtImporteMax";
            this.txtImporteMax.Size = new System.Drawing.Size(100, 20);
            this.txtImporteMax.TabIndex = 4;
            this.txtImporteMax.TextChanged += new System.EventHandler(this.txtImporteMax_TextChanged);
            // 
            // txtImporteMin
            // 
            this.txtImporteMin.Location = new System.Drawing.Point(381, 62);
            this.txtImporteMin.Name = "txtImporteMin";
            this.txtImporteMin.Size = new System.Drawing.Size(100, 20);
            this.txtImporteMin.TabIndex = 3;
            this.txtImporteMin.TextChanged += new System.EventHandler(this.txtImporteMin_TextChanged);
            // 
            // lblNombreMas
            // 
            this.lblNombreMas.AutoSize = true;
            this.lblNombreMas.Location = new System.Drawing.Point(6, 117);
            this.lblNombreMas.Name = "lblNombreMas";
            this.lblNombreMas.Size = new System.Drawing.Size(91, 13);
            this.lblNombreMas.TabIndex = 17;
            this.lblNombreMas.Text = "Nombre Mascota:";
            // 
            // lblNombreCli
            // 
            this.lblNombreCli.AutoSize = true;
            this.lblNombreCli.Location = new System.Drawing.Point(15, 91);
            this.lblNombreCli.Name = "lblNombreCli";
            this.lblNombreCli.Size = new System.Drawing.Size(82, 13);
            this.lblNombreCli.TabIndex = 16;
            this.lblNombreCli.Text = "Nombre Cliente:";
            // 
            // txtNombreMas
            // 
            this.txtNombreMas.Location = new System.Drawing.Point(103, 114);
            this.txtNombreMas.Name = "txtNombreMas";
            this.txtNombreMas.Size = new System.Drawing.Size(595, 20);
            this.txtNombreMas.TabIndex = 6;
            // 
            // txtNombreCli
            // 
            this.txtNombreCli.Location = new System.Drawing.Point(103, 88);
            this.txtNombreCli.Name = "txtNombreCli";
            this.txtNombreCli.Size = new System.Drawing.Size(595, 20);
            this.txtNombreCli.TabIndex = 5;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(103, 62);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(157, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(54, 65);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "Código:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(1023, 138);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(100, 140);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(917, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(28, 143);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblFechaNacAnt
            // 
            this.lblFechaNacAnt.AutoSize = true;
            this.lblFechaNacAnt.Location = new System.Drawing.Point(213, 36);
            this.lblFechaNacAnt.Name = "lblFechaNacAnt";
            this.lblFechaNacAnt.Size = new System.Drawing.Size(52, 13);
            this.lblFechaNacAnt.TabIndex = 7;
            this.lblFechaNacAnt.Text = "Antes de:";
            // 
            // dtpAntes
            // 
            this.dtpAntes.Checked = false;
            this.dtpAntes.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAntes.Location = new System.Drawing.Point(271, 32);
            this.dtpAntes.Name = "dtpAntes";
            this.dtpAntes.Size = new System.Drawing.Size(104, 20);
            this.dtpAntes.TabIndex = 1;
            // 
            // dtpDespues
            // 
            this.dtpDespues.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDespues.Location = new System.Drawing.Point(103, 32);
            this.dtpDespues.Name = "dtpDespues";
            this.dtpDespues.Size = new System.Drawing.Size(104, 20);
            this.dtpDespues.TabIndex = 0;
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Location = new System.Drawing.Point(30, 36);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(67, 13);
            this.lblFechaDesde.TabIndex = 4;
            this.lblFechaDesde.Text = "Despues de:";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 420);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(960, 420);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(1041, 420);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 3;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // dgvAtenciones
            // 
            this.dgvAtenciones.AllowUserToAddRows = false;
            this.dgvAtenciones.AllowUserToDeleteRows = false;
            this.dgvAtenciones.AllowUserToResizeColumns = false;
            this.dgvAtenciones.AllowUserToResizeRows = false;
            this.dgvAtenciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtenciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.cliente,
            this.mascota,
            this.Descripcion,
            this.FechaAtencion,
            this.Importe});
            this.dgvAtenciones.Location = new System.Drawing.Point(12, 193);
            this.dgvAtenciones.Name = "dgvAtenciones";
            this.dgvAtenciones.ReadOnly = true;
            this.dgvAtenciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAtenciones.Size = new System.Drawing.Size(1104, 221);
            this.dgvAtenciones.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 220;
            // 
            // mascota
            // 
            this.mascota.HeaderText = "Mascota";
            this.mascota.Name = "mascota";
            this.mascota.ReadOnly = true;
            this.mascota.Width = 220;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 400;
            // 
            // FechaAtencion
            // 
            this.FechaAtencion.HeaderText = "Fecha de Atención";
            this.FechaAtencion.Name = "FechaAtencion";
            this.FechaAtencion.ReadOnly = true;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 70;
            // 
            // FrmAtenciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 457);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAtenciones);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBorrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(1153, 496);
            this.MinimumSize = new System.Drawing.Size(1153, 496);
            this.Name = "FrmAtenciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atenciones";
            this.Load += new System.EventHandler(this.FrmAtenciones_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtenciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblFechaNacAnt;
        private System.Windows.Forms.DateTimePicker dtpAntes;
        private System.Windows.Forms.DateTimePicker dtpDespues;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dgvAtenciones;
        private System.Windows.Forms.Label lblNombreMas;
        private System.Windows.Forms.Label lblNombreCli;
        private System.Windows.Forms.TextBox txtNombreMas;
        private System.Windows.Forms.TextBox txtNombreCli;
        private System.Windows.Forms.Label lblImporteMax;
        private System.Windows.Forms.Label lblImporteMin;
        private System.Windows.Forms.TextBox txtImporteMax;
        private System.Windows.Forms.TextBox txtImporteMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn mascota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
    }
}