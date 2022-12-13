
namespace InterfazGrafica.Formulario_Crud_Barcos
{
    partial class Frm_ModificarCrucero
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
            this.grpBox_Datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CrearCrucero
            // 
            this.btn_CrearCrucero.Text = "¡Modificar Crucero!";
            // 
            // Frm_ModificarCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 225);
            this.Name = "Frm_ModificarCrucero";
            this.Text = "Frm_ModificarCrucero";
            this.Load += new System.EventHandler(this.Frm_ModificarCrucero_Load);
            this.grpBox_Datos.ResumeLayout(false);
            this.grpBox_Datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}