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
using Entidades.Extensiones;
using Entidades.BaseDeDatos;
using Entidades.Barcos;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Viajes;
using InterfazGrafica.Formulario_Crud_Personas;

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
            ConexionSQLCrucero conexion = new ConexionSQLCrucero();

            this.Listar(conexion.Obtener());
        }

        private void btn_CrearViaje_Click(object sender, EventArgs e)
        {
            Frm_CrearCrucero formCrearViaje = new Frm_CrearCrucero();

            ConexionSQLCrucero conexion = new ConexionSQLCrucero();

            formCrearViaje.ShowDialog();
            this.Listar(conexion.Obtener());
        }

        private void Listar(Almacenamiento<Crucero> embarcadero)
        {
            ConexionSQLViajes conexion = new ConexionSQLViajes();

            this.dtGdVw_ListaCruceros.Rows.Clear();

            for(int i=0;i<embarcadero.Contar;i++)
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
                this.dtGdVw_ListaCruceros.Rows[index].Cells[10].Value = embarcadero[i].Tripulantes.Contar;
                this.dtGdVw_ListaCruceros.Rows[index].Cells[11].Value = new bool().Traductor(conexion.Disponible(embarcadero[i]));

            }

        }

        private void btn_ModificarCrucero_Click(object sender, EventArgs e)
        {
            if(this.dtGdVw_ListaCruceros.SelectedRows.Count == 1)
            {
                ConexionSQLCrucero conexion = new ConexionSQLCrucero();
                Frm_ModificarCrucero formModificarCrucero = new Frm_ModificarCrucero(conexion.Obtener_Crucero((int)this.dtGdVw_ListaCruceros.Rows[this.dtGdVw_ListaCruceros.SelectedRows[0].Index].Cells[0].Value));
               
                formModificarCrucero.ShowDialog();
                this.Listar(conexion.Obtener());
            }
        }

        private void btn_EliminarCrucero_Click(object sender, EventArgs e)
        {
            if (this.dtGdVw_ListaCruceros.SelectedRows.Count == 1)
            {
                ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                conexion.Elminar(conexion.Obtener_Crucero((int)this.dtGdVw_ListaCruceros.Rows[this.dtGdVw_ListaCruceros.SelectedRows[0].Index].Cells[0].Value));
                this.Listar(conexion.Obtener());
            }
        }


        private void btn_ListarTripilantes_Click(object sender, EventArgs e)
        {
            ConexionSQLTripulantes conexion = new ConexionSQLTripulantes();


            if (this.dtGdVw_ListaCruceros.SelectedRows.Count == 1 && conexion.Lista((int)this.dtGdVw_ListaCruceros.Rows[this.dtGdVw_ListaCruceros.SelectedRows[0].Index].Cells[0].Value).Contar > 0)
            {
                Frm_ListarTripulantes formListarPersonas = new Frm_ListarTripulantes(conexion.Lista((int)this.dtGdVw_ListaCruceros.Rows[this.dtGdVw_ListaCruceros.SelectedRows[0].Index].Cells[0].Value));
                formListarPersonas.ShowDialog();  
            }
        }
    }
}
