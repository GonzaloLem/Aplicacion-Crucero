
namespace InterfazGrafica.Formulario_Crud_Personas
{
    partial class Frm_ListarPersonas
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
            this.dtGdVw_ListarPersonas = new System.Windows.Forms.DataGridView();
            this.Colum_Personas_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckBox_Apellido = new System.Windows.Forms.CheckBox();
            this.ckBox_Nacionalidad = new System.Windows.Forms.CheckBox();
            this.ckBox_Rol = new System.Windows.Forms.CheckBox();
            this.txtBox_Filtro = new System.Windows.Forms.TextBox();
            this.btn_Filtrar = new System.Windows.Forms.Button();
            this.ckBox_Id = new System.Windows.Forms.CheckBox();
            this.grpBox_Ordenar = new System.Windows.Forms.GroupBox();
            this.ckBox_Dni = new System.Windows.Forms.CheckBox();
            this.ckBox_Nombre = new System.Windows.Forms.CheckBox();
            this.ckBox_Ascendente = new System.Windows.Forms.CheckBox();
            this.ckBox_Descendente = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_ListarPersonas)).BeginInit();
            this.grpBox_Ordenar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGdVw_ListarPersonas
            // 
            this.dtGdVw_ListarPersonas.AllowUserToAddRows = false;
            this.dtGdVw_ListarPersonas.AllowUserToDeleteRows = false;
            this.dtGdVw_ListarPersonas.AllowUserToResizeColumns = false;
            this.dtGdVw_ListarPersonas.AllowUserToResizeRows = false;
            this.dtGdVw_ListarPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGdVw_ListarPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_ListarPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colum_Personas_Id,
            this.Colum_Personas_Nombre,
            this.Colum_Personas_Apellido,
            this.Colum_Personas_Edad,
            this.Colum_Personas_Dni,
            this.Colum_Personas_Nacionalidad,
            this.Colum_Personas_Celular,
            this.Colum_Personas_Rol});
            this.dtGdVw_ListarPersonas.Location = new System.Drawing.Point(13, 13);
            this.dtGdVw_ListarPersonas.Name = "dtGdVw_ListarPersonas";
            this.dtGdVw_ListarPersonas.RowTemplate.Height = 25;
            this.dtGdVw_ListarPersonas.Size = new System.Drawing.Size(841, 184);
            this.dtGdVw_ListarPersonas.TabIndex = 0;
            // 
            // Colum_Personas_Id
            // 
            this.Colum_Personas_Id.HeaderText = "ID";
            this.Colum_Personas_Id.Name = "Colum_Personas_Id";
            this.Colum_Personas_Id.ReadOnly = true;
            // 
            // Colum_Personas_Nombre
            // 
            this.Colum_Personas_Nombre.HeaderText = "Nombre";
            this.Colum_Personas_Nombre.Name = "Colum_Personas_Nombre";
            this.Colum_Personas_Nombre.ReadOnly = true;
            // 
            // Colum_Personas_Apellido
            // 
            this.Colum_Personas_Apellido.HeaderText = "Apellido";
            this.Colum_Personas_Apellido.Name = "Colum_Personas_Apellido";
            this.Colum_Personas_Apellido.ReadOnly = true;
            // 
            // Colum_Personas_Edad
            // 
            this.Colum_Personas_Edad.HeaderText = "Edad";
            this.Colum_Personas_Edad.Name = "Colum_Personas_Edad";
            this.Colum_Personas_Edad.ReadOnly = true;
            // 
            // Colum_Personas_Dni
            // 
            this.Colum_Personas_Dni.HeaderText = "DNI";
            this.Colum_Personas_Dni.Name = "Colum_Personas_Dni";
            this.Colum_Personas_Dni.ReadOnly = true;
            // 
            // Colum_Personas_Nacionalidad
            // 
            this.Colum_Personas_Nacionalidad.HeaderText = "Nacionalidad";
            this.Colum_Personas_Nacionalidad.Name = "Colum_Personas_Nacionalidad";
            this.Colum_Personas_Nacionalidad.ReadOnly = true;
            // 
            // Colum_Personas_Celular
            // 
            this.Colum_Personas_Celular.HeaderText = "Celular";
            this.Colum_Personas_Celular.Name = "Colum_Personas_Celular";
            this.Colum_Personas_Celular.ReadOnly = true;
            // 
            // Colum_Personas_Rol
            // 
            this.Colum_Personas_Rol.HeaderText = "Rol";
            this.Colum_Personas_Rol.Name = "Colum_Personas_Rol";
            this.Colum_Personas_Rol.ReadOnly = true;
            // 
            // ckBox_Apellido
            // 
            this.ckBox_Apellido.AutoSize = true;
            this.ckBox_Apellido.Location = new System.Drawing.Point(90, 18);
            this.ckBox_Apellido.Name = "ckBox_Apellido";
            this.ckBox_Apellido.Size = new System.Drawing.Size(70, 19);
            this.ckBox_Apellido.TabIndex = 1;
            this.ckBox_Apellido.Text = "Apellido";
            this.ckBox_Apellido.UseVisualStyleBackColor = true;
            this.ckBox_Apellido.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Nacionalidad
            // 
            this.ckBox_Nacionalidad.AutoSize = true;
            this.ckBox_Nacionalidad.Location = new System.Drawing.Point(166, 18);
            this.ckBox_Nacionalidad.Name = "ckBox_Nacionalidad";
            this.ckBox_Nacionalidad.Size = new System.Drawing.Size(96, 19);
            this.ckBox_Nacionalidad.TabIndex = 3;
            this.ckBox_Nacionalidad.Text = "Nacionalidad";
            this.ckBox_Nacionalidad.UseVisualStyleBackColor = true;
            this.ckBox_Nacionalidad.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Rol
            // 
            this.ckBox_Rol.AutoSize = true;
            this.ckBox_Rol.Location = new System.Drawing.Point(268, 18);
            this.ckBox_Rol.Name = "ckBox_Rol";
            this.ckBox_Rol.Size = new System.Drawing.Size(43, 19);
            this.ckBox_Rol.TabIndex = 4;
            this.ckBox_Rol.Text = "Rol";
            this.ckBox_Rol.UseVisualStyleBackColor = true;
            this.ckBox_Rol.Click += new System.EventHandler(this.Validar);
            // 
            // txtBox_Filtro
            // 
            this.txtBox_Filtro.Location = new System.Drawing.Point(575, 222);
            this.txtBox_Filtro.Name = "txtBox_Filtro";
            this.txtBox_Filtro.Size = new System.Drawing.Size(146, 23);
            this.txtBox_Filtro.TabIndex = 5;
            this.txtBox_Filtro.TextChanged += new System.EventHandler(this.Filtro);
            // 
            // btn_Filtrar
            // 
            this.btn_Filtrar.Location = new System.Drawing.Point(727, 222);
            this.btn_Filtrar.Name = "btn_Filtrar";
            this.btn_Filtrar.Size = new System.Drawing.Size(114, 23);
            this.btn_Filtrar.TabIndex = 6;
            this.btn_Filtrar.Text = "Filtrar";
            this.btn_Filtrar.UseVisualStyleBackColor = true;
            this.btn_Filtrar.Click += new System.EventHandler(this.btn_Filtrar_Click);
            // 
            // ckBox_Id
            // 
            this.ckBox_Id.AutoSize = true;
            this.ckBox_Id.Location = new System.Drawing.Point(370, 18);
            this.ckBox_Id.Name = "ckBox_Id";
            this.ckBox_Id.Size = new System.Drawing.Size(37, 19);
            this.ckBox_Id.TabIndex = 7;
            this.ckBox_Id.Text = "ID";
            this.ckBox_Id.UseVisualStyleBackColor = true;
            this.ckBox_Id.Click += new System.EventHandler(this.Validar);
            // 
            // grpBox_Ordenar
            // 
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Dni);
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Nombre);
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Id);
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Rol);
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Nacionalidad);
            this.grpBox_Ordenar.Controls.Add(this.ckBox_Apellido);
            this.grpBox_Ordenar.Location = new System.Drawing.Point(13, 203);
            this.grpBox_Ordenar.Name = "grpBox_Ordenar";
            this.grpBox_Ordenar.Size = new System.Drawing.Size(414, 45);
            this.grpBox_Ordenar.TabIndex = 8;
            this.grpBox_Ordenar.TabStop = false;
            this.grpBox_Ordenar.Text = "Ordenar Por:";
            // 
            // ckBox_Dni
            // 
            this.ckBox_Dni.AutoSize = true;
            this.ckBox_Dni.Location = new System.Drawing.Point(317, 18);
            this.ckBox_Dni.Name = "ckBox_Dni";
            this.ckBox_Dni.Size = new System.Drawing.Size(46, 19);
            this.ckBox_Dni.TabIndex = 9;
            this.ckBox_Dni.Text = "DNI";
            this.ckBox_Dni.UseVisualStyleBackColor = true;
            this.ckBox_Dni.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Nombre
            // 
            this.ckBox_Nombre.AutoSize = true;
            this.ckBox_Nombre.Location = new System.Drawing.Point(6, 18);
            this.ckBox_Nombre.Name = "ckBox_Nombre";
            this.ckBox_Nombre.Size = new System.Drawing.Size(70, 19);
            this.ckBox_Nombre.TabIndex = 8;
            this.ckBox_Nombre.Text = "Nombre";
            this.ckBox_Nombre.UseVisualStyleBackColor = true;
            this.ckBox_Nombre.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Ascendente
            // 
            this.ckBox_Ascendente.AutoSize = true;
            this.ckBox_Ascendente.Checked = true;
            this.ckBox_Ascendente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckBox_Ascendente.Location = new System.Drawing.Point(444, 204);
            this.ckBox_Ascendente.Name = "ckBox_Ascendente";
            this.ckBox_Ascendente.Size = new System.Drawing.Size(88, 19);
            this.ckBox_Ascendente.TabIndex = 9;
            this.ckBox_Ascendente.Text = "Ascendente";
            this.ckBox_Ascendente.UseVisualStyleBackColor = true;
            this.ckBox_Ascendente.Click += new System.EventHandler(this.VerificarOrden);
            // 
            // ckBox_Descendente
            // 
            this.ckBox_Descendente.AutoSize = true;
            this.ckBox_Descendente.Location = new System.Drawing.Point(444, 230);
            this.ckBox_Descendente.Name = "ckBox_Descendente";
            this.ckBox_Descendente.Size = new System.Drawing.Size(94, 19);
            this.ckBox_Descendente.TabIndex = 10;
            this.ckBox_Descendente.Text = "Descendente";
            this.ckBox_Descendente.UseVisualStyleBackColor = true;
            this.ckBox_Descendente.Click += new System.EventHandler(this.VerificarOrden);
            // 
            // Frm_ListarPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 261);
            this.Controls.Add(this.ckBox_Descendente);
            this.Controls.Add(this.ckBox_Ascendente);
            this.Controls.Add(this.grpBox_Ordenar);
            this.Controls.Add(this.btn_Filtrar);
            this.Controls.Add(this.txtBox_Filtro);
            this.Controls.Add(this.dtGdVw_ListarPersonas);
            this.Name = "Frm_ListarPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListarPersonas";
            this.Load += new System.EventHandler(this.Frm_ListarPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_ListarPersonas)).EndInit();
            this.grpBox_Ordenar.ResumeLayout(false);
            this.grpBox_Ordenar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGdVw_ListarPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Rol;
        private System.Windows.Forms.CheckBox ckBox_Apellido;
        private System.Windows.Forms.CheckBox ckBox_Nacionalidad;
        private System.Windows.Forms.CheckBox ckBox_Rol;
        private System.Windows.Forms.TextBox txtBox_Filtro;
        private System.Windows.Forms.Button btn_Filtrar;
        private System.Windows.Forms.CheckBox ckBox_Id;
        private System.Windows.Forms.GroupBox grpBox_Ordenar;
        private System.Windows.Forms.CheckBox ckBox_Dni;
        private System.Windows.Forms.CheckBox ckBox_Nombre;
        private System.Windows.Forms.CheckBox ckBox_Ascendente;
        private System.Windows.Forms.CheckBox ckBox_Descendente;
    }
}