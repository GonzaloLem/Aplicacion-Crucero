
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
            GrpBox_Contenedor.SuspendLayout();
            GrpBox_Pasajero.SuspendLayout();
            GrpBox_PreferenciasPasajero.SuspendLayout();
            grpBox_Capitan_Datos.SuspendLayout();
            grpBox_Empleado_Datos.SuspendLayout();
            SuspendLayout();
            // 
            // CbBox_Nacionalidades
            // 
            CbBox_Nacionalidades.Items.AddRange(new object[] { Nacionalidades.Alemania, Nacionalidades.Argentina, Nacionalidades.Australia, Nacionalidades.Belgica, Nacionalidades.Bolivia, Nacionalidades.Brasil, Nacionalidades.Canada, Nacionalidades.Colombia, Nacionalidades.Ecuador, Nacionalidades.España, Nacionalidades.Mexico, Nacionalidades.Uruguay, Nacionalidades.Chile, Nacionalidades.Venezuela, Nacionalidades.CostaRica, Nacionalidades.Cuba, Nacionalidades.Panama, Nacionalidades.Paraguay, Nacionalidades.Peru, Nacionalidades.RepublicaDominicana, Nacionalidades.Belice, Nacionalidades.Alemania, Nacionalidades.Argentina, Nacionalidades.Australia, Nacionalidades.Belgica, Nacionalidades.Bolivia, Nacionalidades.Brasil, Nacionalidades.Canada, Nacionalidades.Colombia, Nacionalidades.Ecuador, Nacionalidades.España, Nacionalidades.Mexico, Nacionalidades.Uruguay, Nacionalidades.Chile, Nacionalidades.Venezuela, Nacionalidades.CostaRica, Nacionalidades.Cuba, Nacionalidades.Panama, Nacionalidades.Paraguay, Nacionalidades.Peru, Nacionalidades.RepublicaDominicana, Nacionalidades.Belice });
            // 
            // CbBox_RolPersona
            // 
            CbBox_RolPersona.Items.AddRange(new object[] { Roles.Admin, Roles.Capitan, Roles.Empleado, Roles.Vendedor, Roles.Cliente, Roles.Admin, Roles.Capitan, Roles.Empleado, Roles.Vendedor, Roles.Cliente });
            // 
            // Btn_Confirmar
            // 
            Btn_Confirmar.Click += Btn_Confirmar_Click_1;
            // 
            // CbBox_Pasajero_Clase
            // 
            CbBox_Pasajero_Clase.Items.AddRange(new object[] { Clases.Turista, Clases.Premium, Clases.Turista, Clases.Premium });
            // 
            // Btn_AgregarPersona
            // 
            Btn_AgregarPersona.Text = "¡Modificar Persona!";
            // 
            // CbBox_Empleado_Puesto
            // 
            CbBox_Empleado_Puesto.Items.AddRange(new object[] { PuestosDeTrabajo.Mozo, PuestosDeTrabajo.Recepcionista, PuestosDeTrabajo.Limpieza, PuestosDeTrabajo.Medico, PuestosDeTrabajo.Seguridad, PuestosDeTrabajo.Cocinero, PuestosDeTrabajo.Mozo, PuestosDeTrabajo.Recepcionista, PuestosDeTrabajo.Limpieza, PuestosDeTrabajo.Medico, PuestosDeTrabajo.Seguridad, PuestosDeTrabajo.Cocinero });
            // 
            // Frm_ModificarPersona
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(351, 249);
            MaximumSize = new System.Drawing.Size(367, 288);
            MinimumSize = new System.Drawing.Size(367, 288);
            Name = "Frm_ModificarPersona";
            Text = "Frm_ModificarPersonacs";
            Load += Frm_ModificarPersonacs_Load;
            GrpBox_Contenedor.ResumeLayout(false);
            GrpBox_Contenedor.PerformLayout();
            GrpBox_Pasajero.ResumeLayout(false);
            GrpBox_Pasajero.PerformLayout();
            GrpBox_PreferenciasPasajero.ResumeLayout(false);
            GrpBox_PreferenciasPasajero.PerformLayout();
            grpBox_Capitan_Datos.ResumeLayout(false);
            grpBox_Capitan_Datos.PerformLayout();
            grpBox_Empleado_Datos.ResumeLayout(false);
            grpBox_Empleado_Datos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}