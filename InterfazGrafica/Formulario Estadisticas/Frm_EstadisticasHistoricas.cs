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
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Barcos;
using Entidades.Personas;
using Entidades.Viajes;
using Entidades.Listas;

namespace InterfazGrafica.Formulario_Estadisticas
{
    public partial class Frm_EstadisticasHistoricas : Form
    {
        public Frm_EstadisticasHistoricas()
        {
            InitializeComponent();
        }

        private void Frm_EstadisticasHistoricas_Load(object sender, EventArgs e)
        {
            this.ListarViajes(ConexionSQLViajes.Obtener());
        } 

        private void ListarDestinos()
        {
            this.dtGdVw_DestinosPopulares.Rows.Clear();

        }

        private void ListarViajes(Almacenamiento<Viaje> lista)
        {
            this.dtGdVw_EstadasticasDeLosViajes.Rows.Clear();

            for (int i = 0; i < lista.Contar; i++)
            {
                int index = this.dtGdVw_EstadasticasDeLosViajes.Rows.Add();

                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[0].Value = lista[i].ID;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[1].Value = lista[i].Partida;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[2].Value = lista[i].Destino;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[3].Value = lista[i].CostoPremium;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[4].Value = lista[i].CostoTurista;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[5].Value = lista[i].Crucero;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[6].Value = ConexionSQLTripulantes.Obtener(lista[i].Crucero.ID).Contar;


            }
        }


    }
}
