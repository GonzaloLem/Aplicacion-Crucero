using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Personas;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_ModificarPersona : Frm_AgregarPersona
    {
        private Persona persona;
        private Frm_ModificarPersona()
        {
            InitializeComponent();
        }

        public Frm_ModificarPersona(Persona persona) : this()
        {
            this.persona = persona;
        }

        private void Frm_ModificarPersonacs_Load(object sender, EventArgs e)
        {
            this.AsignarDatosPrincipales();
        }

        private protected override void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {

        }

        private void AsignarDatosPrincipales()
        {
            this.TxtBox_Nombre.Text = this.persona.Nombre;
            this.TxtBox_Apellido.Text = this.persona.Apellido;
            this.TxtBox_Edad.Text = this.persona.Edad.ToString();
            this.TxtBox_Dni.Text = this.persona.DNI.ToString();
            this.TxtBox_Celular.Text = this.persona.Celular.ToString();
            this.CbBox_Nacionalidades.SelectedItem = this.persona.Nacionalidad;
            this.CbBox_RolPersona.SelectedItem = this.persona.Rol;
            this.Btn_Confirmar_Click(this.Btn_Confirmar, new EventArgs());

        }
    }
}
