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
            Pasajero pasajero = new Pasajero("Gonzalo", "Lemiña", 21, 43593947, Nacionalidades.Argentina, 1134153038, "gonzalonl308@gmail.com",Clases.Turista, new Equipaje(1,1,10), true, true, true);
            Empleado empleado = new Empleado("Martina", "Lemiña", 18, 53222111, Nacionalidades.Belgica, 1100225511, PuestosDeTrabajo.Recepcionista);
            Capitan capitan = new Capitan("Santino", "Gilardi", 55, 18377243, Nacionalidades.Canada, 1101345533, 1230);

            ConexionPasajeros conexionPasajero = new ConexionPasajeros();
            ConexionEmpleados conexionEmpleado = new ConexionEmpleados();
            ConexionCapitan conexionCapitan = new ConexionCapitan();

            conexionPasajero.Insertar(pasajero);
            conexionEmpleado.Insertar(empleado);
            conexionCapitan.Insertar(capitan);
        }


    }
}
