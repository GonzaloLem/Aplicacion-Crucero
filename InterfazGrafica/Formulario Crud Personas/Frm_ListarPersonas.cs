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
using Entidades.BaseDeDatos;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_ListarPersonas : Form
    {
        public Frm_ListarPersonas()
        {
            InitializeComponent();
        }

        private void Frm_ListarPersonas_Load(object sender, EventArgs e)
        {
            ConexionPasajeros conexionPasajeros = new ConexionPasajeros();
            ConexionEmpleados conexionEmpleado = new ConexionEmpleados();
            ConexionCapitan conexionCapitan = new ConexionCapitan();

            this.ListarPersonas(conexionPasajeros.Obtener());
            this.ListarPersonas(conexionEmpleado.Obtener());
            this.ListarPersonas(conexionCapitan.Obtener());

        }

        private void ListarPersonas(AlmacenamientoPersonas<Persona> lista)
        {
            
            //this.DtGdVw_ListarPersonas.Rows.Clear();

            for(int i=0;i<lista.Total;i++)
            {
                int index = this.DtGdVw_ListarPersonas.Rows.Add();

                this.DtGdVw_ListarPersonas.Rows[index].Cells[0].Value = lista[i].ID;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[1].Value = lista[i].Nombre;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[2].Value = lista[i].Apellido;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[3].Value = lista[i].Edad;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[4].Value = lista[i].DNI;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[5].Value = lista[i].Nacionalidad;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[6].Value = lista[i].Celular;
                this.DtGdVw_ListarPersonas.Rows[index].Cells[7].Value = lista[i].Tipo;

            }

        }

    }
}
