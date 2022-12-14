
namespace InterfazGrafica.Formulario_Crud_Viajes
{
    partial class Frm_ViajesModificar
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
            this.dtGdVw_Cruceros = new System.Windows.Forms.DataGridView();
            this.Cruceros_Colum_Especificaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cruceros_Colum_Valores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbBox_Cruceros = new System.Windows.Forms.ComboBox();
            this.cbBox_CiudadPartida = new System.Windows.Forms.ComboBox();
            this.cbBox_Destino = new System.Windows.Forms.ComboBox();
            this.lbl_Texto3 = new System.Windows.Forms.Label();
            this.lbl_Texto1 = new System.Windows.Forms.Label();
            this.lbl_Texto2 = new System.Windows.Forms.Label();
            this.dtTePk_Fecha = new System.Windows.Forms.DateTimePicker();
            this.lbl_Texto4 = new System.Windows.Forms.Label();
            this.btn_ModificarViaje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_Cruceros)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGdVw_Cruceros
            // 
            this.dtGdVw_Cruceros.AllowUserToAddRows = false;
            this.dtGdVw_Cruceros.AllowUserToDeleteRows = false;
            this.dtGdVw_Cruceros.AllowUserToResizeColumns = false;
            this.dtGdVw_Cruceros.AllowUserToResizeRows = false;
            this.dtGdVw_Cruceros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGdVw_Cruceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGdVw_Cruceros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cruceros_Colum_Especificaciones,
            this.Cruceros_Colum_Valores});
            this.dtGdVw_Cruceros.Location = new System.Drawing.Point(12, 8);
            this.dtGdVw_Cruceros.Name = "dtGdVw_Cruceros";
            this.dtGdVw_Cruceros.RowTemplate.Height = 25;
            this.dtGdVw_Cruceros.Size = new System.Drawing.Size(335, 250);
            this.dtGdVw_Cruceros.TabIndex = 7;
            // 
            // Cruceros_Colum_Especificaciones
            // 
            this.Cruceros_Colum_Especificaciones.HeaderText = "Especificaciones";
            this.Cruceros_Colum_Especificaciones.Name = "Cruceros_Colum_Especificaciones";
            this.Cruceros_Colum_Especificaciones.ReadOnly = true;
            this.Cruceros_Colum_Especificaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cruceros_Colum_Especificaciones.Width = 135;
            // 
            // Cruceros_Colum_Valores
            // 
            this.Cruceros_Colum_Valores.HeaderText = "Valores";
            this.Cruceros_Colum_Valores.Name = "Cruceros_Colum_Valores";
            this.Cruceros_Colum_Valores.ReadOnly = true;
            this.Cruceros_Colum_Valores.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Cruceros_Colum_Valores.Width = 155;
            // 
            // cbBox_Cruceros
            // 
            this.cbBox_Cruceros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBox_Cruceros.FormattingEnabled = true;
            this.cbBox_Cruceros.Location = new System.Drawing.Point(353, 31);
            this.cbBox_Cruceros.Name = "cbBox_Cruceros";
            this.cbBox_Cruceros.Size = new System.Drawing.Size(121, 23);
            this.cbBox_Cruceros.TabIndex = 9;
            this.cbBox_Cruceros.SelectedValueChanged += new System.EventHandler(this.MostrarCrucero);
            // 
            // cbBox_CiudadPartida
            // 
            this.cbBox_CiudadPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBox_CiudadPartida.FormattingEnabled = true;
            this.cbBox_CiudadPartida.Location = new System.Drawing.Point(480, 31);
            this.cbBox_CiudadPartida.Name = "cbBox_CiudadPartida";
            this.cbBox_CiudadPartida.Size = new System.Drawing.Size(121, 23);
            this.cbBox_CiudadPartida.TabIndex = 9;
            // 
            // cbBox_Destino
            // 
            this.cbBox_Destino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBox_Destino.FormattingEnabled = true;
            this.cbBox_Destino.Location = new System.Drawing.Point(607, 31);
            this.cbBox_Destino.Name = "cbBox_Destino";
            this.cbBox_Destino.Size = new System.Drawing.Size(121, 23);
            this.cbBox_Destino.TabIndex = 10;
            // 
            // lbl_Texto3
            // 
            this.lbl_Texto3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto3.AutoSize = true;
            this.lbl_Texto3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_Texto3.Location = new System.Drawing.Point(363, 13);
            this.lbl_Texto3.Name = "lbl_Texto3";
            this.lbl_Texto3.Size = new System.Drawing.Size(86, 15);
            this.lbl_Texto3.TabIndex = 11;
            this.lbl_Texto3.Text = "          Cruceros";
            // 
            // lbl_Texto1
            // 
            this.lbl_Texto1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto1.AutoSize = true;
            this.lbl_Texto1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto1.Location = new System.Drawing.Point(480, 13);
            this.lbl_Texto1.Name = "lbl_Texto1";
            this.lbl_Texto1.Size = new System.Drawing.Size(103, 15);
            this.lbl_Texto1.TabIndex = 12;
            this.lbl_Texto1.Text = "Ciudad de Partida";
            // 
            // lbl_Texto2
            // 
            this.lbl_Texto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto2.AutoSize = true;
            this.lbl_Texto2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto2.Location = new System.Drawing.Point(607, 13);
            this.lbl_Texto2.Name = "lbl_Texto2";
            this.lbl_Texto2.Size = new System.Drawing.Size(107, 15);
            this.lbl_Texto2.TabIndex = 13;
            this.lbl_Texto2.Text = "Ciudad de Destino";
            // 
            // dtTePk_Fecha
            // 
            this.dtTePk_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTePk_Fecha.Location = new System.Drawing.Point(421, 108);
            this.dtTePk_Fecha.MaxDate = new System.DateTime(2024, 12, 31, 0, 0, 0, 0);
            this.dtTePk_Fecha.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.dtTePk_Fecha.Name = "dtTePk_Fecha";
            this.dtTePk_Fecha.Size = new System.Drawing.Size(248, 23);
            this.dtTePk_Fecha.TabIndex = 14;
            // 
            // lbl_Texto4
            // 
            this.lbl_Texto4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto4.AutoSize = true;
            this.lbl_Texto4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto4.Location = new System.Drawing.Point(463, 90);
            this.lbl_Texto4.Name = "lbl_Texto4";
            this.lbl_Texto4.Size = new System.Drawing.Size(138, 15);
            this.lbl_Texto4.TabIndex = 15;
            this.lbl_Texto4.Text = "Fecha de inicio del Viaje";
            // 
            // btn_ModificarViaje
            // 
            this.btn_ModificarViaje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_ModificarViaje.Location = new System.Drawing.Point(480, 222);
            this.btn_ModificarViaje.Name = "btn_ModificarViaje";
            this.btn_ModificarViaje.Size = new System.Drawing.Size(121, 36);
            this.btn_ModificarViaje.TabIndex = 16;
            this.btn_ModificarViaje.Text = "¡Modificar Viaje!";
            this.btn_ModificarViaje.UseVisualStyleBackColor = true;
            this.btn_ModificarViaje.Click += new System.EventHandler(this.btn_CrearViaje_Click);
            // 
            // Frm_ViajesModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 270);
            this.Controls.Add(this.btn_ModificarViaje);
            this.Controls.Add(this.lbl_Texto4);
            this.Controls.Add(this.dtTePk_Fecha);
            this.Controls.Add(this.lbl_Texto2);
            this.Controls.Add(this.lbl_Texto1);
            this.Controls.Add(this.lbl_Texto3);
            this.Controls.Add(this.cbBox_Destino);
            this.Controls.Add(this.cbBox_CiudadPartida);
            this.Controls.Add(this.cbBox_Cruceros);
            this.Controls.Add(this.dtGdVw_Cruceros);
            this.Name = "Frm_ViajesModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ViajesModificar";
            this.Load += new System.EventHandler(this.Frm_ViajesModificar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGdVw_Cruceros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView dtGdVw_Cruceros;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Especificaciones;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Cruceros_Colum_Valores;
        protected System.Windows.Forms.ComboBox cbBox_Cruceros;
        protected System.Windows.Forms.ComboBox cbBox_CiudadPartida;
        protected System.Windows.Forms.ComboBox cbBox_Destino;
        protected System.Windows.Forms.Label lbl_Texto3;
        protected System.Windows.Forms.Label lbl_Texto1;
        protected System.Windows.Forms.Label lbl_Texto2;
        protected System.Windows.Forms.DateTimePicker dtTePk_Fecha;
        protected System.Windows.Forms.Label lbl_Texto4;
        protected System.Windows.Forms.Button btn_ModificarViaje;
    }
}