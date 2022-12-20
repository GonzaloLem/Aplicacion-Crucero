
namespace InterfazGrafica.Formulario_Crud_Barcos
{
    partial class Frm_ListarTripulantes
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
            this.grpBox_Ordenar.SuspendLayout();
            this.SuspendLayout();

            //
            // dtGdVw_ListarPersonas
            //
            this.dtGdVw_ListarPersonas.Size = new System.Drawing.Size(841, 394);
            // 
            // Colum_Personas_Id
            // 
            this.Colum_Personas_Id.Name = "Colum_Personas_Id";
            this.Colum_Personas_Id.Width = 50;
            // 
            // Colum_Personas_Nombre
            // 
            this.Colum_Personas_Nombre.Name = "Colum_Personas_Nombre";
            // 
            // Colum_Personas_Apellido
            // 
            this.Colum_Personas_Apellido.Name = "Colum_Personas_Apellido";
            // 
            // Colum_Personas_Edad
            // 
            this.Colum_Personas_Edad.Name = "Colum_Personas_Edad";
            this.Colum_Personas_Edad.Width = 58;
            // 
            // Colum_Personas_Dni
            // 
            this.Colum_Personas_Dni.Name = "Colum_Personas_Dni";
            // 
            // Colum_Personas_Nacionalidad
            // 
            this.Colum_Personas_Nacionalidad.Name = "Colum_Personas_Nacionalidad";
            // 
            // Colum_Personas_Celular
            // 
            this.Colum_Personas_Celular.Name = "Colum_Personas_Celular";
            // 
            // Colum_Personas_Rol
            // 
            this.Colum_Personas_Rol.Name = "Colum_Personas_Rol";
            // 
            // txtBox_Filtro
            // 
            this.txtBox_Filtro.Location = new System.Drawing.Point(591, 418);
            // 
            // btn_Filtrar
            // 
            this.btn_Filtrar.Location = new System.Drawing.Point(743, 419);
            // 
            // grpBox_Ordenar
            // 
            this.grpBox_Ordenar.Location = new System.Drawing.Point(12, 404);
            // 
            // ckBox_Nombre
            // 
            this.ckBox_Nombre.Location = new System.Drawing.Point(6, 20);
            // 
            // ckBox_Ascendente
            // 
            this.ckBox_Ascendente.Location = new System.Drawing.Point(448, 397);
            // 
            // ckBox_Descendente
            // 
            this.ckBox_Descendente.Location = new System.Drawing.Point(448, 422);
            // 
            // btn_ModificarPersona
            // 
            this.btn_ModificarPersona.Location = new System.Drawing.Point(217, 465);
            this.btn_ModificarPersona.Visible = false;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(445, 465);
            this.btn_Eliminar.Visible = false;
            // 
            // Frm_ListarTripulantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 461);
            this.Name = "Frm_ListarTripulantes";
            this.Text = "Frm_ListarTripulantes";
            this.Load += new System.EventHandler(this.Frm_ListarTripulantes_Load);
            this.grpBox_Ordenar.ResumeLayout(false);
            this.grpBox_Ordenar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}