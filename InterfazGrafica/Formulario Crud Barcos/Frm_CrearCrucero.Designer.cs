
namespace InterfazGrafica.Formulario_Crud_Barcos
{
    partial class Frm_CrearCrucero
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
            this.grpBox_Datos = new System.Windows.Forms.GroupBox();
            this.lbl_Texto7 = new System.Windows.Forms.Label();
            this.lbl_Texto6 = new System.Windows.Forms.Label();
            this.txtBox_Gimnacios = new System.Windows.Forms.TextBox();
            this.txtBox_Piscinas = new System.Windows.Forms.TextBox();
            this.lbl_Texto5 = new System.Windows.Forms.Label();
            this.txtBox_Casinos = new System.Windows.Forms.TextBox();
            this.lbl_Texto4 = new System.Windows.Forms.Label();
            this.txtBox_Capacidad = new System.Windows.Forms.TextBox();
            this.txtBox_Salones = new System.Windows.Forms.TextBox();
            this.lbl_Texto3 = new System.Windows.Forms.Label();
            this.lbl_Texto2 = new System.Windows.Forms.Label();
            this.txtBox_Camarotes = new System.Windows.Forms.TextBox();
            this.lbl_Texto1 = new System.Windows.Forms.Label();
            this.txtBox_Nombre = new System.Windows.Forms.TextBox();
            this.btn_CrearCrucero = new System.Windows.Forms.Button();
            this.grpBox_Datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_Datos
            // 
            this.grpBox_Datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox_Datos.Controls.Add(this.lbl_Texto7);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto6);
            this.grpBox_Datos.Controls.Add(this.txtBox_Gimnacios);
            this.grpBox_Datos.Controls.Add(this.txtBox_Piscinas);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto5);
            this.grpBox_Datos.Controls.Add(this.txtBox_Casinos);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto4);
            this.grpBox_Datos.Controls.Add(this.txtBox_Capacidad);
            this.grpBox_Datos.Controls.Add(this.txtBox_Salones);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto3);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto2);
            this.grpBox_Datos.Controls.Add(this.txtBox_Camarotes);
            this.grpBox_Datos.Controls.Add(this.lbl_Texto1);
            this.grpBox_Datos.Controls.Add(this.txtBox_Nombre);
            this.grpBox_Datos.Location = new System.Drawing.Point(13, 13);
            this.grpBox_Datos.Name = "grpBox_Datos";
            this.grpBox_Datos.Size = new System.Drawing.Size(350, 159);
            this.grpBox_Datos.TabIndex = 0;
            this.grpBox_Datos.TabStop = false;
            this.grpBox_Datos.Text = "Datos";
            // 
            // lbl_Texto7
            // 
            this.lbl_Texto7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto7.AutoSize = true;
            this.lbl_Texto7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto7.Location = new System.Drawing.Point(239, 72);
            this.lbl_Texto7.Name = "lbl_Texto7";
            this.lbl_Texto7.Size = new System.Drawing.Size(64, 15);
            this.lbl_Texto7.TabIndex = 13;
            this.lbl_Texto7.Text = "Gimnacios";
            // 
            // lbl_Texto6
            // 
            this.lbl_Texto6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto6.AutoSize = true;
            this.lbl_Texto6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto6.Location = new System.Drawing.Point(167, 72);
            this.lbl_Texto6.Name = "lbl_Texto6";
            this.lbl_Texto6.Size = new System.Drawing.Size(49, 15);
            this.lbl_Texto6.TabIndex = 12;
            this.lbl_Texto6.Text = "Piscinas";
            // 
            // txtBox_Gimnacios
            // 
            this.txtBox_Gimnacios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Gimnacios.Location = new System.Drawing.Point(239, 90);
            this.txtBox_Gimnacios.Name = "txtBox_Gimnacios";
            this.txtBox_Gimnacios.Size = new System.Drawing.Size(66, 23);
            this.txtBox_Gimnacios.TabIndex = 11;
            this.txtBox_Gimnacios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // txtBox_Piscinas
            // 
            this.txtBox_Piscinas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Piscinas.Location = new System.Drawing.Point(167, 90);
            this.txtBox_Piscinas.Name = "txtBox_Piscinas";
            this.txtBox_Piscinas.Size = new System.Drawing.Size(66, 23);
            this.txtBox_Piscinas.TabIndex = 10;
            this.txtBox_Piscinas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // lbl_Texto5
            // 
            this.lbl_Texto5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto5.AutoSize = true;
            this.lbl_Texto5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto5.Location = new System.Drawing.Point(273, 19);
            this.lbl_Texto5.Name = "lbl_Texto5";
            this.lbl_Texto5.Size = new System.Drawing.Size(47, 15);
            this.lbl_Texto5.TabIndex = 9;
            this.lbl_Texto5.Text = "Casinos";
            // 
            // txtBox_Casinos
            // 
            this.txtBox_Casinos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Casinos.Location = new System.Drawing.Point(273, 37);
            this.txtBox_Casinos.Name = "txtBox_Casinos";
            this.txtBox_Casinos.Size = new System.Drawing.Size(66, 23);
            this.txtBox_Casinos.TabIndex = 8;
            this.txtBox_Casinos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // lbl_Texto4
            // 
            this.lbl_Texto4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto4.AutoSize = true;
            this.lbl_Texto4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto4.Location = new System.Drawing.Point(6, 72);
            this.lbl_Texto4.Name = "lbl_Texto4";
            this.lbl_Texto4.Size = new System.Drawing.Size(136, 15);
            this.lbl_Texto4.TabIndex = 7;
            this.lbl_Texto4.Text = "Capacidad de la Bodega";
            // 
            // txtBox_Capacidad
            // 
            this.txtBox_Capacidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Capacidad.Location = new System.Drawing.Point(6, 90);
            this.txtBox_Capacidad.Name = "txtBox_Capacidad";
            this.txtBox_Capacidad.Size = new System.Drawing.Size(136, 23);
            this.txtBox_Capacidad.TabIndex = 6;
            this.txtBox_Capacidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // txtBox_Salones
            // 
            this.txtBox_Salones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Salones.Location = new System.Drawing.Point(204, 37);
            this.txtBox_Salones.Name = "txtBox_Salones";
            this.txtBox_Salones.Size = new System.Drawing.Size(63, 23);
            this.txtBox_Salones.TabIndex = 5;
            this.txtBox_Salones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // lbl_Texto3
            // 
            this.lbl_Texto3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto3.AutoSize = true;
            this.lbl_Texto3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto3.Location = new System.Drawing.Point(204, 19);
            this.lbl_Texto3.Name = "lbl_Texto3";
            this.lbl_Texto3.Size = new System.Drawing.Size(49, 15);
            this.lbl_Texto3.TabIndex = 4;
            this.lbl_Texto3.Text = "Salones";
            // 
            // lbl_Texto2
            // 
            this.lbl_Texto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto2.AutoSize = true;
            this.lbl_Texto2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto2.Location = new System.Drawing.Point(132, 19);
            this.lbl_Texto2.Name = "lbl_Texto2";
            this.lbl_Texto2.Size = new System.Drawing.Size(66, 15);
            this.lbl_Texto2.TabIndex = 3;
            this.lbl_Texto2.Text = "Camarotes";
            // 
            // txtBox_Camarotes
            // 
            this.txtBox_Camarotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Camarotes.Location = new System.Drawing.Point(132, 37);
            this.txtBox_Camarotes.Name = "txtBox_Camarotes";
            this.txtBox_Camarotes.Size = new System.Drawing.Size(66, 23);
            this.txtBox_Camarotes.TabIndex = 2;
            this.txtBox_Camarotes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar);
            // 
            // lbl_Texto1
            // 
            this.lbl_Texto1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Texto1.AutoSize = true;
            this.lbl_Texto1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Texto1.Location = new System.Drawing.Point(6, 19);
            this.lbl_Texto1.Name = "lbl_Texto1";
            this.lbl_Texto1.Size = new System.Drawing.Size(120, 15);
            this.lbl_Texto1.TabIndex = 1;
            this.lbl_Texto1.Text = "Nombre del Crucero";
            // 
            // txtBox_Nombre
            // 
            this.txtBox_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox_Nombre.Location = new System.Drawing.Point(6, 37);
            this.txtBox_Nombre.Name = "txtBox_Nombre";
            this.txtBox_Nombre.Size = new System.Drawing.Size(120, 23);
            this.txtBox_Nombre.TabIndex = 0;
            this.txtBox_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Validar_SoloLetras);
            // 
            // btn_CrearCrucero
            // 
            this.btn_CrearCrucero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CrearCrucero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_CrearCrucero.Location = new System.Drawing.Point(118, 179);
            this.btn_CrearCrucero.Name = "btn_CrearCrucero";
            this.btn_CrearCrucero.Size = new System.Drawing.Size(148, 34);
            this.btn_CrearCrucero.TabIndex = 1;
            this.btn_CrearCrucero.Text = "¡Crear Crucero!";
            this.btn_CrearCrucero.UseVisualStyleBackColor = true;
            this.btn_CrearCrucero.Click += new System.EventHandler(this.btn_CrearCrucero_Click);
            // 
            // Frm_CrearCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 225);
            this.Controls.Add(this.btn_CrearCrucero);
            this.Controls.Add(this.grpBox_Datos);
            this.MaximumSize = new System.Drawing.Size(391, 264);
            this.MinimumSize = new System.Drawing.Size(391, 264);
            this.Name = "Frm_CrearCrucero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_CrearViajecs";
            this.grpBox_Datos.ResumeLayout(false);
            this.grpBox_Datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_Datos;
        private System.Windows.Forms.Label lbl_Texto1;
        private System.Windows.Forms.TextBox txtBox_Nombre;
        private System.Windows.Forms.Label lbl_Texto2;
        private System.Windows.Forms.TextBox txtBox_Camarotes;
        private System.Windows.Forms.TextBox txtBox_Salones;
        private System.Windows.Forms.Label lbl_Texto3;
        private System.Windows.Forms.Label lbl_Texto4;
        private System.Windows.Forms.TextBox txtBox_Capacidad;
        private System.Windows.Forms.Label lbl_Texto5;
        private System.Windows.Forms.TextBox txtBox_Casinos;
        private System.Windows.Forms.Label lbl_Texto7;
        private System.Windows.Forms.Label lbl_Texto6;
        private System.Windows.Forms.TextBox txtBox_Gimnacios;
        private System.Windows.Forms.TextBox txtBox_Piscinas;
        private System.Windows.Forms.Button btn_CrearCrucero;
    }
}