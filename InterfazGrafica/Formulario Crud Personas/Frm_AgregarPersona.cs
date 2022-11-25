using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Btn_AgregarPersona.Visible = false;
            //this.ClientSize = new System.Drawing.Size(648, 255); Size de group box Pasajero
        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            if(this.TxtBox_Nombre.Text.Length > 2 && this.TxtBox_Apellido.Text.Length > 2 && this.TxtBox_Edad.Text != "" 
                && this.TxtBox_Dni.Text.Length == 8 && this.TxtBox_Celular.Text.Length == 10 
                && this.CbBox_Nacionalidades.SelectedItem is not null && this.CbBox_RolPersona.SelectedItem is not null)
            {
                
            }
        }

        private void Validar_SoloLetras(object sender, KeyPressEventArgs e)
        {
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || e.KeyChar == 08))
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
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 08 || e.KeyChar == 64) )
            {
                e.Handled = true;
                return;
            }
        }
    }
}
