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
using InterfazGrafica.Formulario_Crud_Viajes;
using InterfazGrafica.Formulario_Crud_Barcos;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Personas;
using Entidades.Viajes;
using Entidades.Listas;

namespace InterfazGrafica
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        #region Eventos
        private void Frm_Principal_Load(object sender, EventArgs e)
        {

            this.Listar(ConexionSQLViajes.Obtener());
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

        private void Btn_AgregarViaje_Click(object sender, EventArgs e)
        {
            Frm_CrearViaje formCrearViaje = new Frm_CrearViaje();
            formCrearViaje.ShowDialog();
            this.Listar(ConexionSQLViajes.Obtener());
        }

        private void Btn_ModificarViaje_Click(object sender, EventArgs e)
        {
            if(this.DtGdVw_ListaViajes.SelectedRows.Count == 1)
            {
                Frm_ViajesModificar formModifciarViaje = new Frm_ViajesModificar(ConexionSQLViajes.Obtener((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value));
                formModifciarViaje.ShowDialog();
                this.Listar(ConexionSQLViajes.Obtener());
            }
        }

        private void Btn_EliminarViaje_Click(object sender, EventArgs e)
        {
            if (this.DtGdVw_ListaViajes.SelectedRows.Count == 1)
            {
                ConexionSQLViajes.Eliminar((ConexionSQLViajes.Obtener((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value)));
                this.Listar(ConexionSQLViajes.Obtener());
            }
        }

        private void btn_CrudCrucero_Click(object sender, EventArgs e)
        {
            Frm_ListarCruceros formCruceros = new Frm_ListarCruceros();

            formCruceros.ShowDialog();
        }

        private void Btn_EstadisticasHistoricas_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Metodos Extras
        private void Listar(AlmecenamientoViajes<Viaje> lista)
        {
            this.DtGdVw_ListaViajes.Rows.Clear();
           for(int i=0;i<lista.Total;i++)
           {
                int index = this.DtGdVw_ListaViajes.Rows.Add();

                this.DtGdVw_ListaViajes.Rows[index].Cells[0].Value = lista[i].ID;
                this.DtGdVw_ListaViajes.Rows[index].Cells[1].Value = lista[i].Partida;
                this.DtGdVw_ListaViajes.Rows[index].Cells[2].Value = Destino.Parse(lista[i].Destino);
                this.DtGdVw_ListaViajes.Rows[index].Cells[3].Value = lista[i].Inicio;
                this.DtGdVw_ListaViajes.Rows[index].Cells[4].Value = lista[i].Crucero;
                this.DtGdVw_ListaViajes.Rows[index].Cells[5].Value = lista[i].CamarotesPremium;
                this.DtGdVw_ListaViajes.Rows[index].Cells[6].Value = lista[i].CamarotesTurista;
                this.DtGdVw_ListaViajes.Rows[index].Cells[7].Value = lista[i].CostoPremium;
                this.DtGdVw_ListaViajes.Rows[index].Cells[8].Value = lista[i].CostoTurista;
                this.DtGdVw_ListaViajes.Rows[index].Cells[9].Value = lista[i].Duracion;

            }
        }
        #endregion

    }
}
