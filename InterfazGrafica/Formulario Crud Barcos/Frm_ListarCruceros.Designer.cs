
namespace InterfazGrafica.Formulario_Crud_Barcos
{
    partial class Frm_ListarCruceros
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
            this.dtGdVw_ListaCruceros = new System.Windows.Forms.DataGridView();
            this.Cruceros_Colum_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Matricula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Camarotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Salones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Casinos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Piscinas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Gimnacios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_CapacidadBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_PesoBodega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Tripulantes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Disponibilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_CrearViaje = new System.Windows.Forms.Button();
            this.btn_ModificarCrucero = new System.Windows.Forms.Button();
            this.btn_EliminarCrucero = new System.Windows.Forms.Button();
            this.btn_ListarTripilantes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_ListaCruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGdVw_ListaCruceros
            // 
            this.dtGdVw_ListaCruceros.AllowUserToAddRows = false;
            this.dtGdVw_ListaCruceros.AllowUserToDeleteRows = false;
            this.dtGdVw_ListaCruceros.AllowUserToResizeColumns = false;
            this.dtGdVw_ListaCruceros.AllowUserToResizeRows = false;
            this.dtGdVw_ListaCruceros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGdVw_ListaCruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_ListaCruceros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cruceros_Colum_ID,
            this.Cruceros_Colum_Matricula,
            this.Cruceros_Colum_Nombre,
            this.Cruceros_Colum_Camarotes,
            this.Cruceros_Colum_Salones,
            this.Cruceros_Colum_Casinos,
            this.Cruceros_Colum_Piscinas,
            this.Cruceros_Colum_Gimnacios,
            this.Cruceros_Colum_CapacidadBodega,
            this.Cruceros_Colum_PesoBodega,
            this.Cruceros_Colum_Tripulantes,
            this.Cruceros_Colum_Disponibilidad});
            this.dtGdVw_ListaCruceros.Location = new System.Drawing.Point(12, 12);
            this.dtGdVw_ListaCruceros.Name = "dtGdVw_ListaCruceros";
            this.dtGdVw_ListaCruceros.RowTemplate.Height = 25;
            this.dtGdVw_ListaCruceros.Size = new System.Drawing.Size(1158, 223);
            this.dtGdVw_ListaCruceros.TabIndex = 0;
            // 
            // Cruceros_Colum_ID
            // 
            this.Cruceros_Colum_ID.HeaderText = "ID";
            this.Cruceros_Colum_ID.Name = "Cruceros_Colum_ID";
            this.Cruceros_Colum_ID.ReadOnly = true;
            this.Cruceros_Colum_ID.Width = 50;
            // 
            // Cruceros_Colum_Matricula
            // 
            this.Cruceros_Colum_Matricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Matricula.HeaderText = "Matricula";
            this.Cruceros_Colum_Matricula.Name = "Cruceros_Colum_Matricula";
            this.Cruceros_Colum_Matricula.ReadOnly = true;
            // 
            // Cruceros_Colum_Nombre
            // 
            this.Cruceros_Colum_Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Nombre.HeaderText = "Nombre";
            this.Cruceros_Colum_Nombre.Name = "Cruceros_Colum_Nombre";
            this.Cruceros_Colum_Nombre.ReadOnly = true;
            // 
            // Cruceros_Colum_Camarotes
            // 
            this.Cruceros_Colum_Camarotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Camarotes.HeaderText = "Camarotes";
            this.Cruceros_Colum_Camarotes.Name = "Cruceros_Colum_Camarotes";
            this.Cruceros_Colum_Camarotes.ReadOnly = true;
            // 
            // Cruceros_Colum_Salones
            // 
            this.Cruceros_Colum_Salones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Salones.HeaderText = "Salones";
            this.Cruceros_Colum_Salones.Name = "Cruceros_Colum_Salones";
            this.Cruceros_Colum_Salones.ReadOnly = true;
            // 
            // Cruceros_Colum_Casinos
            // 
            this.Cruceros_Colum_Casinos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Casinos.HeaderText = "Casinos";
            this.Cruceros_Colum_Casinos.Name = "Cruceros_Colum_Casinos";
            this.Cruceros_Colum_Casinos.ReadOnly = true;
            // 
            // Cruceros_Colum_Piscinas
            // 
            this.Cruceros_Colum_Piscinas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Piscinas.HeaderText = "Piscinas";
            this.Cruceros_Colum_Piscinas.Name = "Cruceros_Colum_Piscinas";
            this.Cruceros_Colum_Piscinas.ReadOnly = true;
            // 
            // Cruceros_Colum_Gimnacios
            // 
            this.Cruceros_Colum_Gimnacios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Gimnacios.HeaderText = "Gimnacios";
            this.Cruceros_Colum_Gimnacios.Name = "Cruceros_Colum_Gimnacios";
            this.Cruceros_Colum_Gimnacios.ReadOnly = true;
            // 
            // Cruceros_Colum_CapacidadBodega
            // 
            this.Cruceros_Colum_CapacidadBodega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_CapacidadBodega.HeaderText = "Capacidad de la Bodega";
            this.Cruceros_Colum_CapacidadBodega.Name = "Cruceros_Colum_CapacidadBodega";
            this.Cruceros_Colum_CapacidadBodega.ReadOnly = true;
            // 
            // Cruceros_Colum_PesoBodega
            // 
            this.Cruceros_Colum_PesoBodega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_PesoBodega.HeaderText = "Peso de la Bodega";
            this.Cruceros_Colum_PesoBodega.Name = "Cruceros_Colum_PesoBodega";
            this.Cruceros_Colum_PesoBodega.ReadOnly = true;
            // 
            // Cruceros_Colum_Tripulantes
            // 
            this.Cruceros_Colum_Tripulantes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cruceros_Colum_Tripulantes.HeaderText = "Tripulantes";
            this.Cruceros_Colum_Tripulantes.Name = "Cruceros_Colum_Tripulantes";
            this.Cruceros_Colum_Tripulantes.ReadOnly = true;
            this.Cruceros_Colum_Tripulantes.Width = 89;
            // 
            // Cruceros_Colum_Disponibilidad
            // 
            this.Cruceros_Colum_Disponibilidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cruceros_Colum_Disponibilidad.HeaderText = "Disponibilidad";
            this.Cruceros_Colum_Disponibilidad.Name = "Cruceros_Colum_Disponibilidad";
            this.Cruceros_Colum_Disponibilidad.ReadOnly = true;
            // 
            // btn_CrearViaje
            // 
            this.btn_CrearViaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CrearViaje.Location = new System.Drawing.Point(287, 241);
            this.btn_CrearViaje.Name = "btn_CrearViaje";
            this.btn_CrearViaje.Size = new System.Drawing.Size(151, 44);
            this.btn_CrearViaje.TabIndex = 1;
            this.btn_CrearViaje.Text = "¡Crear Crucero!";
            this.btn_CrearViaje.UseVisualStyleBackColor = true;
            this.btn_CrearViaje.Click += new System.EventHandler(this.btn_CrearViaje_Click);
            // 
            // btn_ModificarCrucero
            // 
            this.btn_ModificarCrucero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ModificarCrucero.Location = new System.Drawing.Point(444, 241);
            this.btn_ModificarCrucero.Name = "btn_ModificarCrucero";
            this.btn_ModificarCrucero.Size = new System.Drawing.Size(151, 44);
            this.btn_ModificarCrucero.TabIndex = 2;
            this.btn_ModificarCrucero.Text = "Modificar Crucero";
            this.btn_ModificarCrucero.UseVisualStyleBackColor = true;
            this.btn_ModificarCrucero.Click += new System.EventHandler(this.btn_ModificarCrucero_Click);
            // 
            // btn_EliminarCrucero
            // 
            this.btn_EliminarCrucero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EliminarCrucero.Location = new System.Drawing.Point(601, 241);
            this.btn_EliminarCrucero.Name = "btn_EliminarCrucero";
            this.btn_EliminarCrucero.Size = new System.Drawing.Size(151, 44);
            this.btn_EliminarCrucero.TabIndex = 3;
            this.btn_EliminarCrucero.Text = "Eliminar Crucero";
            this.btn_EliminarCrucero.UseVisualStyleBackColor = true;
            this.btn_EliminarCrucero.Click += new System.EventHandler(this.btn_EliminarCrucero_Click);
            // 
            // btn_ListarTripilantes
            // 
            this.btn_ListarTripilantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ListarTripilantes.Location = new System.Drawing.Point(758, 241);
            this.btn_ListarTripilantes.Name = "btn_ListarTripilantes";
            this.btn_ListarTripilantes.Size = new System.Drawing.Size(151, 44);
            this.btn_ListarTripilantes.TabIndex = 4;
            this.btn_ListarTripilantes.Text = "Listar Tripulantes";
            this.btn_ListarTripilantes.UseVisualStyleBackColor = true;
            // 
            // Frm_ListarCruceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 297);
            this.Controls.Add(this.btn_ListarTripilantes);
            this.Controls.Add(this.btn_EliminarCrucero);
            this.Controls.Add(this.btn_ModificarCrucero);
            this.Controls.Add(this.btn_CrearViaje);
            this.Controls.Add(this.dtGdVw_ListaCruceros);
            this.MinimumSize = new System.Drawing.Size(1198, 336);
            this.Name = "Frm_ListarCruceros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListarCruceros";
            this.Load += new System.EventHandler(this.Frm_ListarCruceros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_ListaCruceros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGdVw_ListaCruceros;
        private System.Windows.Forms.Button btn_CrearViaje;
        private System.Windows.Forms.Button btn_ModificarCrucero;
        private System.Windows.Forms.Button btn_EliminarCrucero;
        private System.Windows.Forms.Button btn_ListarTripilantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Matricula;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Camarotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Salones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Casinos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Piscinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Gimnacios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_CapacidadBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_PesoBodega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Tripulantes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Disponibilidad;
    }
}