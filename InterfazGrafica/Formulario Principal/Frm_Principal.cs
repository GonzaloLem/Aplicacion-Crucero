using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGrafica.Formulario_Crud_Personas;
using Entidades.Personas;
using Entidades.BaseDeDatos;

namespace InterfazGrafica
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
        }

        private void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {
            Frm_AgregarPersona formAgregarPersona = new Frm_AgregarPersona();

            formAgregarPersona.ShowDialog();

        }

        private void Btn_ListarPersonasSistema_Click(object sender, EventArgs e)
        {
            Frm_ListarPersonas formListarPersonas = new Frm_ListarPersonas();

            formListarPersonas.ShowDialog();
        }

        private void Btn_EstadisticasHistoricas_Click(object sender, EventArgs e)
        {  

        }


    }
}
