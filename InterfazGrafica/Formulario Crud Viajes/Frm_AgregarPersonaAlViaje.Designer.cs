
namespace InterfazGrafica.Formulario_Crud_Viajes
{
    partial class Frm_AgregarPersonaAlViaje
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
            this.dtGdVw_InfoDelViaje = new System.Windows.Forms.DataGridView();
            this.Colum_InfoDelViaje_Titulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_InfoDelViaje_Datos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtGdVw_PersonasDisponibles = new System.Windows.Forms.DataGridView();
            this.Column_PersonasDisponibles_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PersonasDisponibles_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PersonasDisponibles_Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PersonasDisponibles_Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PersonasDisponibles_DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PersonasDisponibles_Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtGdVw_InfoAdicional_Persona = new System.Windows.Forms.DataGridView();
            this.Column_InfoAdicional_Pasajero_Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Pasajero_Clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Pasajero_Equipaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Pasajero_Casino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Pasajero_Piscina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Pasajero_Gimnacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Empleado_Puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Capitan_HorasDeViaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_AñadirPersona = new System.Windows.Forms.Button();
            this.grpBox_Filtro = new System.Windows.Forms.GroupBox();
            this.ckBox_Capitan = new System.Windows.Forms.CheckBox();
            this.ckBox_Empleado = new System.Windows.Forms.CheckBox();
            this.ckBox_Cliente = new System.Windows.Forms.CheckBox();
            this.txtBox_Filtro = new System.Windows.Forms.TextBox();
            this.lbl_Filtro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_InfoDelViaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_PersonasDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_InfoAdicional_Persona)).BeginInit();
            this.grpBox_Filtro.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGdVw_InfoDelViaje
            // 
            this.dtGdVw_InfoDelViaje.AllowUserToAddRows = false;
            this.dtGdVw_InfoDelViaje.AllowUserToDeleteRows = false;
            this.dtGdVw_InfoDelViaje.AllowUserToResizeColumns = false;
            this.dtGdVw_InfoDelViaje.AllowUserToResizeRows = false;
            this.dtGdVw_InfoDelViaje.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGdVw_InfoDelViaje.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_InfoDelViaje.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colum_InfoDelViaje_Titulos,
            this.Colum_InfoDelViaje_Datos});
            this.dtGdVw_InfoDelViaje.Location = new System.Drawing.Point(12, 12);
            this.dtGdVw_InfoDelViaje.Name = "dtGdVw_InfoDelViaje";
            this.dtGdVw_InfoDelViaje.RowTemplate.Height = 25;
            this.dtGdVw_InfoDelViaje.Size = new System.Drawing.Size(250, 226);
            this.dtGdVw_InfoDelViaje.TabIndex = 0;
            // 
            // Colum_InfoDelViaje_Titulos
            // 
            this.Colum_InfoDelViaje_Titulos.HeaderText = "";
            this.Colum_InfoDelViaje_Titulos.Name = "Colum_InfoDelViaje_Titulos";
            this.Colum_InfoDelViaje_Titulos.ReadOnly = true;
            // 
            // Colum_InfoDelViaje_Datos
            // 
            this.Colum_InfoDelViaje_Datos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Colum_InfoDelViaje_Datos.HeaderText = "Datos";
            this.Colum_InfoDelViaje_Datos.Name = "Colum_InfoDelViaje_Datos";
            this.Colum_InfoDelViaje_Datos.ReadOnly = true;
            // 
            // dtGdVw_PersonasDisponibles
            // 
            this.dtGdVw_PersonasDisponibles.AllowUserToAddRows = false;
            this.dtGdVw_PersonasDisponibles.AllowUserToDeleteRows = false;
            this.dtGdVw_PersonasDisponibles.AllowUserToResizeColumns = false;
            this.dtGdVw_PersonasDisponibles.AllowUserToResizeRows = false;
            this.dtGdVw_PersonasDisponibles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGdVw_PersonasDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_PersonasDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_PersonasDisponibles_ID,
            this.Column_PersonasDisponibles_Nombre,
            this.Column_PersonasDisponibles_Apellido,
            this.Column_PersonasDisponibles_Edad,
            this.Column_PersonasDisponibles_DNI,
            this.Column_PersonasDisponibles_Rol});
            this.dtGdVw_PersonasDisponibles.Location = new System.Drawing.Point(268, 12);
            this.dtGdVw_PersonasDisponibles.Name = "dtGdVw_PersonasDisponibles";
            this.dtGdVw_PersonasDisponibles.RowTemplate.Height = 25;
            this.dtGdVw_PersonasDisponibles.Size = new System.Drawing.Size(614, 172);
            this.dtGdVw_PersonasDisponibles.TabIndex = 1;
            this.dtGdVw_PersonasDisponibles.SelectionChanged += new System.EventHandler(this.MostrarInfoAdicional);
            // 
            // Column_PersonasDisponibles_ID
            // 
            this.Column_PersonasDisponibles_ID.HeaderText = "ID";
            this.Column_PersonasDisponibles_ID.Name = "Column_PersonasDisponibles_ID";
            this.Column_PersonasDisponibles_ID.ReadOnly = true;
            // 
            // Column_PersonasDisponibles_Nombre
            // 
            this.Column_PersonasDisponibles_Nombre.HeaderText = "Nombre";
            this.Column_PersonasDisponibles_Nombre.Name = "Column_PersonasDisponibles_Nombre";
            this.Column_PersonasDisponibles_Nombre.ReadOnly = true;
            // 
            // Column_PersonasDisponibles_Apellido
            // 
            this.Column_PersonasDisponibles_Apellido.HeaderText = "Apellido";
            this.Column_PersonasDisponibles_Apellido.Name = "Column_PersonasDisponibles_Apellido";
            this.Column_PersonasDisponibles_Apellido.ReadOnly = true;
            // 
            // Column_PersonasDisponibles_Edad
            // 
            this.Column_PersonasDisponibles_Edad.HeaderText = "Edad";
            this.Column_PersonasDisponibles_Edad.Name = "Column_PersonasDisponibles_Edad";
            this.Column_PersonasDisponibles_Edad.ReadOnly = true;
            // 
            // Column_PersonasDisponibles_DNI
            // 
            this.Column_PersonasDisponibles_DNI.HeaderText = "DNI";
            this.Column_PersonasDisponibles_DNI.Name = "Column_PersonasDisponibles_DNI";
            this.Column_PersonasDisponibles_DNI.ReadOnly = true;
            // 
            // Column_PersonasDisponibles_Rol
            // 
            this.Column_PersonasDisponibles_Rol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_PersonasDisponibles_Rol.HeaderText = "Rol";
            this.Column_PersonasDisponibles_Rol.Name = "Column_PersonasDisponibles_Rol";
            this.Column_PersonasDisponibles_Rol.ReadOnly = true;
            // 
            // dtGdVw_InfoAdicional_Persona
            // 
            this.dtGdVw_InfoAdicional_Persona.AllowUserToAddRows = false;
            this.dtGdVw_InfoAdicional_Persona.AllowUserToDeleteRows = false;
            this.dtGdVw_InfoAdicional_Persona.AllowUserToResizeColumns = false;
            this.dtGdVw_InfoAdicional_Persona.AllowUserToResizeRows = false;
            this.dtGdVw_InfoAdicional_Persona.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtGdVw_InfoAdicional_Persona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_InfoAdicional_Persona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_InfoAdicional_Pasajero_Correo,
            this.Column_InfoAdicional_Pasajero_Clase,
            this.Column_InfoAdicional_Pasajero_Equipaje,
            this.Column_InfoAdicional_Pasajero_Casino,
            this.Column_InfoAdicional_Pasajero_Piscina,
            this.Column_InfoAdicional_Pasajero_Gimnacion,
            this.Column_InfoAdicional_Empleado_Puesto,
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio,
            this.Column_InfoAdicional_Capitan_HorasDeViaje,
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa});
            this.dtGdVw_InfoAdicional_Persona.Location = new System.Drawing.Point(268, 190);
            this.dtGdVw_InfoAdicional_Persona.Name = "dtGdVw_InfoAdicional_Persona";
            this.dtGdVw_InfoAdicional_Persona.RowTemplate.Height = 25;
            this.dtGdVw_InfoAdicional_Persona.Size = new System.Drawing.Size(614, 48);
            this.dtGdVw_InfoAdicional_Persona.TabIndex = 2;
            // 
            // Column_InfoAdicional_Pasajero_Correo
            // 
            this.Column_InfoAdicional_Pasajero_Correo.HeaderText = "Correo";
            this.Column_InfoAdicional_Pasajero_Correo.Name = "Column_InfoAdicional_Pasajero_Correo";
            this.Column_InfoAdicional_Pasajero_Correo.ReadOnly = true;
            // 
            // Column_InfoAdicional_Pasajero_Clase
            // 
            this.Column_InfoAdicional_Pasajero_Clase.HeaderText = "Clase";
            this.Column_InfoAdicional_Pasajero_Clase.Name = "Column_InfoAdicional_Pasajero_Clase";
            this.Column_InfoAdicional_Pasajero_Clase.ReadOnly = true;
            // 
            // Column_InfoAdicional_Pasajero_Equipaje
            // 
            this.Column_InfoAdicional_Pasajero_Equipaje.HeaderText = "Equipaje";
            this.Column_InfoAdicional_Pasajero_Equipaje.Name = "Column_InfoAdicional_Pasajero_Equipaje";
            this.Column_InfoAdicional_Pasajero_Equipaje.ReadOnly = true;
            // 
            // Column_InfoAdicional_Pasajero_Casino
            // 
            this.Column_InfoAdicional_Pasajero_Casino.HeaderText = "Casino";
            this.Column_InfoAdicional_Pasajero_Casino.Name = "Column_InfoAdicional_Pasajero_Casino";
            this.Column_InfoAdicional_Pasajero_Casino.ReadOnly = true;
            // 
            // Column_InfoAdicional_Pasajero_Piscina
            // 
            this.Column_InfoAdicional_Pasajero_Piscina.HeaderText = "Piscina";
            this.Column_InfoAdicional_Pasajero_Piscina.Name = "Column_InfoAdicional_Pasajero_Piscina";
            this.Column_InfoAdicional_Pasajero_Piscina.ReadOnly = true;
            // 
            // Column_InfoAdicional_Pasajero_Gimnacion
            // 
            this.Column_InfoAdicional_Pasajero_Gimnacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InfoAdicional_Pasajero_Gimnacion.HeaderText = "Gimnacio";
            this.Column_InfoAdicional_Pasajero_Gimnacion.Name = "Column_InfoAdicional_Pasajero_Gimnacion";
            this.Column_InfoAdicional_Pasajero_Gimnacion.ReadOnly = true;
            // 
            // Column_InfoAdicional_Empleado_Puesto
            // 
            this.Column_InfoAdicional_Empleado_Puesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InfoAdicional_Empleado_Puesto.HeaderText = "Puesto";
            this.Column_InfoAdicional_Empleado_Puesto.Name = "Column_InfoAdicional_Empleado_Puesto";
            this.Column_InfoAdicional_Empleado_Puesto.ReadOnly = true;
            // 
            // Column_InfoAdicional_Empleado_DiaQueSeUnio
            // 
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.HeaderText = "Fecha en la se unio";
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.Name = "Column_InfoAdicional_Empleado_DiaQueSeUnio";
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.ReadOnly = true;
            // 
            // Column_InfoAdicional_Capitan_HorasDeViaje
            // 
            this.Column_InfoAdicional_Capitan_HorasDeViaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InfoAdicional_Capitan_HorasDeViaje.HeaderText = "Horas de Viaje";
            this.Column_InfoAdicional_Capitan_HorasDeViaje.Name = "Column_InfoAdicional_Capitan_HorasDeViaje";
            this.Column_InfoAdicional_Capitan_HorasDeViaje.ReadOnly = true;
            // 
            // Column_InfoAdicional_Capitan_ViajesConLaEmpresa
            // 
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.HeaderText = "Viajes con la Empresa";
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.Name = "Column_InfoAdicional_Capitan_ViajesConLaEmpresa";
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.ReadOnly = true;
            // 
            // btn_AñadirPersona
            // 
            this.btn_AñadirPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_AñadirPersona.Location = new System.Drawing.Point(12, 242);
            this.btn_AñadirPersona.Name = "btn_AñadirPersona";
            this.btn_AñadirPersona.Size = new System.Drawing.Size(250, 44);
            this.btn_AñadirPersona.TabIndex = 3;
            this.btn_AñadirPersona.Text = "Añadir Persona";
            this.btn_AñadirPersona.UseVisualStyleBackColor = true;
            this.btn_AñadirPersona.Click += new System.EventHandler(this.btn_AñadirPersona_Click);
            // 
            // grpBox_Filtro
            // 
            this.grpBox_Filtro.Controls.Add(this.ckBox_Capitan);
            this.grpBox_Filtro.Controls.Add(this.ckBox_Empleado);
            this.grpBox_Filtro.Controls.Add(this.ckBox_Cliente);
            this.grpBox_Filtro.Location = new System.Drawing.Point(268, 248);
            this.grpBox_Filtro.Name = "grpBox_Filtro";
            this.grpBox_Filtro.Size = new System.Drawing.Size(236, 38);
            this.grpBox_Filtro.TabIndex = 4;
            this.grpBox_Filtro.TabStop = false;
            this.grpBox_Filtro.Text = "Filtros";
            // 
            // ckBox_Capitan
            // 
            this.ckBox_Capitan.AutoSize = true;
            this.ckBox_Capitan.Location = new System.Drawing.Point(161, 13);
            this.ckBox_Capitan.Name = "ckBox_Capitan";
            this.ckBox_Capitan.Size = new System.Drawing.Size(67, 19);
            this.ckBox_Capitan.TabIndex = 2;
            this.ckBox_Capitan.Text = "Capitan";
            this.ckBox_Capitan.UseVisualStyleBackColor = true;
            this.ckBox_Capitan.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Empleado
            // 
            this.ckBox_Empleado.AutoSize = true;
            this.ckBox_Empleado.Location = new System.Drawing.Point(76, 13);
            this.ckBox_Empleado.Name = "ckBox_Empleado";
            this.ckBox_Empleado.Size = new System.Drawing.Size(79, 19);
            this.ckBox_Empleado.TabIndex = 1;
            this.ckBox_Empleado.Text = "Empleado";
            this.ckBox_Empleado.UseVisualStyleBackColor = true;
            this.ckBox_Empleado.Click += new System.EventHandler(this.Validar);
            // 
            // ckBox_Cliente
            // 
            this.ckBox_Cliente.AutoSize = true;
            this.ckBox_Cliente.Location = new System.Drawing.Point(7, 13);
            this.ckBox_Cliente.Name = "ckBox_Cliente";
            this.ckBox_Cliente.Size = new System.Drawing.Size(63, 19);
            this.ckBox_Cliente.TabIndex = 0;
            this.ckBox_Cliente.Text = "Cliente";
            this.ckBox_Cliente.UseVisualStyleBackColor = true;
            this.ckBox_Cliente.Click += new System.EventHandler(this.Validar);
            // 
            // txtBox_Filtro
            // 
            this.txtBox_Filtro.Location = new System.Drawing.Point(530, 261);
            this.txtBox_Filtro.Name = "txtBox_Filtro";
            this.txtBox_Filtro.Size = new System.Drawing.Size(111, 23);
            this.txtBox_Filtro.TabIndex = 5;
            // 
            // lbl_Filtro
            // 
            this.lbl_Filtro.AutoSize = true;
            this.lbl_Filtro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Filtro.Location = new System.Drawing.Point(530, 241);
            this.lbl_Filtro.Name = "lbl_Filtro";
            this.lbl_Filtro.Size = new System.Drawing.Size(111, 15);
            this.lbl_Filtro.TabIndex = 6;
            this.lbl_Filtro.Text = "Filtrar por Nombre";
            // 
            // Frm_AgregarPersonaAlViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 290);
            this.Controls.Add(this.lbl_Filtro);
            this.Controls.Add(this.txtBox_Filtro);
            this.Controls.Add(this.grpBox_Filtro);
            this.Controls.Add(this.btn_AñadirPersona);
            this.Controls.Add(this.dtGdVw_InfoAdicional_Persona);
            this.Controls.Add(this.dtGdVw_PersonasDisponibles);
            this.Controls.Add(this.dtGdVw_InfoDelViaje);
            this.Name = "Frm_AgregarPersonaAlViaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_AgregarPersonaAlViaje";
            this.Load += new System.EventHandler(this.Frm_AgregarPersonaAlViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_InfoDelViaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_PersonasDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_InfoAdicional_Persona)).EndInit();
            this.grpBox_Filtro.ResumeLayout(false);
            this.grpBox_Filtro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGdVw_InfoDelViaje;
        private System.Windows.Forms.DataGridView dtGdVw_PersonasDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_InfoDelViaje_Titulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_InfoDelViaje_Datos;
        private System.Windows.Forms.DataGridView dtGdVw_InfoAdicional_Persona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PersonasDisponibles_Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Equipaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Casino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Piscina;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Pasajero_Gimnacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Empleado_Puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Empleado_DiaQueSeUnio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Capitan_HorasDeViaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_InfoAdicional_Capitan_ViajesConLaEmpresa;
        private System.Windows.Forms.Button btn_AñadirPersona;
        private System.Windows.Forms.GroupBox grpBox_Filtro;
        private System.Windows.Forms.CheckBox ckBox_Capitan;
        private System.Windows.Forms.CheckBox ckBox_Empleado;
        private System.Windows.Forms.CheckBox ckBox_Cliente;
        private System.Windows.Forms.TextBox txtBox_Filtro;
        private System.Windows.Forms.Label lbl_Filtro;
    }
}