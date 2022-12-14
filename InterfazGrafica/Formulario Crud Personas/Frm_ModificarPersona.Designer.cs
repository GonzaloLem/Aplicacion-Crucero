
namespace InterfazGrafica.Formulario_Crud_Personas
{
    partial class Frm_ModificarPersona
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
            this.GrpBox_Contenedor.SuspendLayout();
            this.GrpBox_Pasajero.SuspendLayout();
            this.GrpBox_PreferenciasPasajero.SuspendLayout();
            this.grpBox_Capitan_Datos.SuspendLayout();
            this.grpBox_Empleado_Datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbBox_Nacionalidades
            // 
            this.CbBox_Nacionalidades.Items.AddRange(new object[] {
            Nacionalidades.Alemania,
            Nacionalidades.Argentina,
            Nacionalidades.Australia,
            Nacionalidades.Belgica,
            Nacionalidades.Bolivia,
            Nacionalidades.Brasil,
            Nacionalidades.Canada,
            Nacionalidades.Colombia,
            Nacionalidades.Ecuador,
            Nacionalidades.España,
            Nacionalidades.Mexico,
            Nacionalidades.Uruguay,
            Nacionalidades.Chile,
            Nacionalidades.Venezuela,
            Nacionalidades.CostaRica,
            Nacionalidades.Cuba,
            Nacionalidades.Panama,
            Nacionalidades.Paraguay,
            Nacionalidades.Peru,
            Nacionalidades.RepublicaDominicana,
            Nacionalidades.Belice});
            // 
            // CbBox_RolPersona
            // 
            this.CbBox_RolPersona.Items.AddRange(new object[] {
            Roles.Admin,
            Roles.Capitan,
            Roles.Empleado,
            Roles.Vendedor,
            Roles.Cliente});
            // 
            // Btn_Confirmar
            // 
            // 
            // CbBox_Pasajero_Clase
            // 
            this.CbBox_Pasajero_Clase.Items.AddRange(new object[] {
            Clases.Turista,
            Clases.Premium});
            // 
            // Btn_AgregarPersona
            // 
            this.Btn_AgregarPersona.Text = "¡Modificar Persona!";
            // 
            // CbBox_Empleado_Puesto
            // 
            this.CbBox_Empleado_Puesto.Items.AddRange(new object[] {
            PuestosDeTrabajo.Mozo,
            PuestosDeTrabajo.Recepcionista,
            PuestosDeTrabajo.Limpieza,
            PuestosDeTrabajo.Medico,
            PuestosDeTrabajo.Seguridad,
            PuestosDeTrabajo.Cocinero});
            // 
            // Frm_ModificarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 249);
            this.MaximumSize = new System.Drawing.Size(367, 288);
            this.MinimumSize = new System.Drawing.Size(367, 288);
            this.Name = "Frm_ModificarPersona";
            this.Text = "Frm_ModificarPersonacs";
            this.Load += new System.EventHandler(this.Frm_ModificarPersonacs_Load);
            this.GrpBox_Contenedor.ResumeLayout(false);
            this.GrpBox_Contenedor.PerformLayout();
            this.GrpBox_Pasajero.ResumeLayout(false);
            this.GrpBox_Pasajero.PerformLayout();
            this.GrpBox_PreferenciasPasajero.ResumeLayout(false);
            this.GrpBox_PreferenciasPasajero.PerformLayout();
            this.grpBox_Capitan_Datos.ResumeLayout(false);
            this.grpBox_Capitan_Datos.PerformLayout();
            this.grpBox_Empleado_Datos.ResumeLayout(false);
            this.grpBox_Empleado_Datos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}