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
            ConexionSQLCrucero conexionCrucero = new ConexionSQLCrucero();
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            this.Listar(conexionViajes.Obtener());
            this.DestinosPopulares(conexionViajes.Destinos());
            this.Listar(conexionCrucero.Obtener());
        } 

        private void ListarDestinos()
        {
            this.dtGdVw_DestinosPopulares.Rows.Clear();

        }

        private void Listar(Almacenamiento<Crucero> lista)
        {
            this.dtGdVw_ListarCruceros.Rows.Clear();

             ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                for(int i=0;i<lista.Contar;i++)
                {
                    int index = this.dtGdVw_ListarCruceros.Rows.Add();

                    this.dtGdVw_ListarCruceros.Rows[index].Cells[0].Value = lista[i].ID;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[1].Value = lista[i].Matricula;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[2].Value = lista[i].Nombre;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[3].Value = lista[i].Camarotes;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[4].Value = lista[i].Salones;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[5].Value = lista[i].Casinos;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[6].Value = lista[i].Piscinas;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[7].Value = lista[i].Gimnacios;
                    this.dtGdVw_ListarCruceros.Rows[index].Cells[8].Value = conexion.Horas(lista[i]);

                }

            this.dtGdVw_ListarCruceros.Sort(this.Colum_ListarCruceros_Horas, ListSortDirection.Descending);
        }

        private void Listar(Almacenamiento<Destino> lista)
        {
            this.dtGdVw_DestinosPopulares.Rows.Clear();

            for(int i=0;i<lista.Contar;i++)
            {
                int index = this.dtGdVw_DestinosPopulares.Rows.Add();

                this.dtGdVw_DestinosPopulares.Rows[index].Cells[0].Value = lista[i];
                this.dtGdVw_DestinosPopulares.Rows[index].Cells[1].Value = lista[i].Popularidad;
            }

            this.dtGdVw_DestinosPopulares.Sort(this.Colum_DestinosPopulares_Total, ListSortDirection.Descending);

        }

        private void Listar(Almacenamiento<Viaje> lista)
        {

            ConexionSQLTripulantes conexion = new ConexionSQLTripulantes();

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
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[6].Value = conexion.Lista(lista[i]).Contar;
                this.dtGdVw_EstadasticasDeLosViajes.Rows[index].Cells[7].Value = lista[i].Ganancias();

            }

            this.dtGdVw_EstadasticasDeLosViajes.Sort(this.Colum_EstadasticasDeLosViajes_Ganancias, ListSortDirection.Descending);

        }
        private void DestinosPopulares(Almacenamiento<Destino> lista)
        {
            for (int i = 0; i < lista.Contar; i++)
            {
                for (int j = i + 1; j < lista.Contar; j++)
                {
                    if (lista[i] == lista[j])
                    {
                        lista[i].Popularidad = 1;
                        lista -= lista[j];
                    }
                }
            }
            this.Listar(lista);
        }

    }
}
