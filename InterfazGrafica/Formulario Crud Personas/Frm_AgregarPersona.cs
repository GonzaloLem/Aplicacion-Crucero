using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Personas;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_AgregarPersona : Form
    {
        public Frm_AgregarPersona()
        {
            InitializeComponent();
        }

        private void Frm_AgregarPersona_Load(object sender, EventArgs e)
        {
            this.GrpBox_Pasajero.Visible = false;
            this.GrpBox_DatosCapitan.Visible = false;
            this.Btn_AgregarPersona.Visible = false;

            foreach(Nacionalidades item in Enum.GetValues(typeof(Nacionalidades)))
            {
                this.CbBox_Nacionalidades.Items.Add(item);
            }

            foreach(Roles item in Enum.GetValues(typeof(Roles)))
            {
                this.CbBox_RolPersona.Items.Add(item);
            }

        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            if(this.TxtBox_Nombre.Text.Length > 2 && this.TxtBox_Apellido.Text.Length > 2 && this.TxtBox_Edad.Text != "" 
                && this.TxtBox_Dni.Text.Length == 8 && this.TxtBox_Celular.Text.Length == 10 
                && this.CbBox_Nacionalidades.SelectedItem is not null && this.CbBox_RolPersona.SelectedItem is not null)
            {
                this.ClientSize = new System.Drawing.Size(349, 236);
                this.MinimumSize = new System.Drawing.Size(349, 236);

                this.Btn_AgregarPersona.Visible = false;
                this.GrpBox_Pasajero.Visible = false;
                this.GrpBox_PreferenciasPasajero.Visible = false;
                this.GrpBox_DatosCapitan.Visible = false;
                this.GrpBox_Empleado_Datos.Visible = false;

                if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
                {
                    this.ClientSize = new System.Drawing.Size(848, 255);
                    this.MinimumSize = new System.Drawing.Size(848, 255);
                    this.GrpBox_Pasajero.Visible = true;
                    this.GrpBox_PreferenciasPasajero.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(453, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
                else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
                {
                    this.ClientSize = new System.Drawing.Size(499, 255);
                    this.MinimumSize = new System.Drawing.Size(499, 255);
                    this.GrpBox_DatosCapitan.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
                else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
                {
                    this.ClientSize = new System.Drawing.Size(499, 255);
                    this.MinimumSize = new System.Drawing.Size(499, 255);
                    this.GrpBox_Empleado_Datos.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
            }
        }

        private void Validar_SoloLetras(object sender, KeyPressEventArgs e)
        {
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || e.KeyChar == 241 || e.KeyChar == 209 || e.KeyChar == 08))
            {
                e.Handled = true;
                return;
            }
        }

        private void Validar_SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if(!((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 08)))
            {
                e.Handled = true;
                return;
            }
        }

        private void Validar_LetrasNumerosCaracterEspecial(object sender, KeyPressEventArgs e)
        {
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 241 || e.KeyChar == 209 || e.KeyChar == 08 || e.KeyChar == 64) )
            {
                e.Handled = true;
                return;
            }
        }
    }
}
