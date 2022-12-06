
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
            this.DtGdVw_ListarPersonas = new System.Windows.Forms.DataGridView();
            this.Colum_Personas_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colum_Personas_Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DtGdVw_ListarPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // DtGdVw_ListarPersonas
            // 
            this.DtGdVw_ListarPersonas.AllowUserToAddRows = false;
            this.DtGdVw_ListarPersonas.AllowUserToDeleteRows = false;
            this.DtGdVw_ListarPersonas.AllowUserToResizeColumns = false;
            this.DtGdVw_ListarPersonas.AllowUserToResizeRows = false;
            this.DtGdVw_ListarPersonas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtGdVw_ListarPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtGdVw_ListarPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Colum_Personas_Id,
            this.Colum_Personas_Nombre,
            this.Colum_Personas_Apellido,
            this.Colum_Personas_Edad,
            this.Colum_Personas_Dni,
            this.Colum_Personas_Nacionalidad,
            this.Colum_Personas_Celular,
            this.Colum_Personas_Rol});
            this.DtGdVw_ListarPersonas.Location = new System.Drawing.Point(13, 13);
            this.DtGdVw_ListarPersonas.Name = "DtGdVw_ListarPersonas";
            this.DtGdVw_ListarPersonas.RowTemplate.Height = 25;
            this.DtGdVw_ListarPersonas.Size = new System.Drawing.Size(841, 184);
            this.DtGdVw_ListarPersonas.TabIndex = 0;
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
            // Frm_ListarPersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 274);
            this.Controls.Add(this.DtGdVw_ListarPersonas);
            this.Name = "Frm_ListarPersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ListarPersonas";
            this.Load += new System.EventHandler(this.Frm_ListarPersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtGdVw_ListarPersonas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtGdVw_ListarPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colum_Personas_Rol;
    }
}