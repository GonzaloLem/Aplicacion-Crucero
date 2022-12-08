using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.BaseDeDatos;
using Entidades.Barcos;
using Entidades.Listas;

namespace InterfazGrafica.Formulario_Crud_Barcos
{
    public partial class Frm_ListarCruceros : Form
    {
        public Frm_ListarCruceros()
        {
            InitializeComponent();
        }

        private void Frm_ListarCruceros_Load(object sender, EventArgs e)
        {
            ConexionCrucero conexion = new ConexionCrucero();
            this.Listar(conexion.Obtener());
        }

        private void btn_CrearViaje_Click(object sender, EventArgs e)
        {
            Frm_CrearCrucero formCrearViaje = new Frm_CrearCrucero();
            ConexionCrucero conexion = new ConexionCrucero();

            formCrearViaje.ShowDialog();
            this.Listar(conexion.Obtener());
        }

        private void Listar(Embarcadero<Crucero> embarcadero)
        {
            this.dtGdVw_ListaCruceros.Rows.Clear();

            for(int i=0;i<embarcadero.Total;i++)
            {
                int index = this.dtGdVw_ListaCruceros.Rows.Add();

                this.dtGdVw_ListaCruceros.Rows[index].Cells[0].Value = embarcadero[i].ID;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[1].Value = embarcadero[i].Matricula;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[2].Value = embarcadero[i].Nombre;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[3].Value = embarcadero[i].Camarotes;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[4].Value = embarcadero[i].Salones;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[5].Value = embarcadero[i].Casinos;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[6].Value = embarcadero[i].Piscinas;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[7].Value = embarcadero[i].Gimnacios;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[8].Value = embarcadero[i].Capacidad;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[9].Value = embarcadero[i].Peso;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[10].Value = embarcadero[i].Tripulantes.Total;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[11].Value = "X";

            }

        }

    }
}
