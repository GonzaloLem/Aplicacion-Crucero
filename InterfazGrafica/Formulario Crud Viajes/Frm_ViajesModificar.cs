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
using Entidades.Viajes;
using Entidades.Personas;
using Entidades.Listas;
using Entidades;


namespace InterfazGrafica.Formulario_Crud_Viajes
{
    public partial class Frm_ViajesModificar : Form
    {
        Viaje viaje;
        private Frm_ViajesModificar()
        {
            InitializeComponent();
        }

        public Frm_ViajesModificar(Viaje viaje) : this()
        {
            this.viaje = viaje;
        }

        private void Frm_ViajesModificar_Load(object sender, EventArgs e)
        {
            ConexionSQLCrucero conexion = new ConexionSQLCrucero();

            Almacenamiento<Crucero> embacadero = conexion.Obtener();

            foreach (CiudadesDePartida item in Enum.GetValues(typeof(CiudadesDePartida)))
            {
                this.cbBox_CiudadPartida.Items.Add(item);
            }

            foreach (ViajesRegionales item in Enum.GetValues(typeof(ViajesRegionales)))
            {
                this.cbBox_Destino.Items.Add(item);
            }

            foreach (ViajesExtraRegional item in Enum.GetValues(typeof(ViajesExtraRegional)))
            {
                this.cbBox_Destino.Items.Add(item);
            }

            foreach (Crucero item in embacadero.Lista)
            {
                if (ConexionSQLViajes.Disponible(item) || item.ID == this.viaje.Crucero.ID)
                {
                    this.cbBox_Cruceros.Items.Add(item);
                }
            }

            this.AsignarFechasDeViaje();
            this.InformacionCrucero();
            this.EstablecerDatos();

        }

        private void btn_CrearViaje_Click(object sender, EventArgs e)
        {
            if (this.cbBox_Cruceros.SelectedItem != null && this.cbBox_Destino.SelectedItem != null && this.cbBox_CiudadPartida.SelectedItem != null)
            {
                Destino destino = null;

                if (this.cbBox_Destino.SelectedItem is ViajesRegionales)
                {
                    destino = new DestinoRegional((ViajesRegionales)this.cbBox_Destino.SelectedItem);
                }
                else if (this.cbBox_Destino.SelectedItem is ViajesExtraRegional)
                {
                    destino = new DestinoExtraRegional((ViajesExtraRegional)this.cbBox_Destino.SelectedItem);
                }

                int duracionDelViaje = Viaje.Calcular(destino);

                Viaje viaje = new Viaje
                (
                    this.viaje.ID,
                    (CiudadesDePartida)this.cbBox_CiudadPartida.SelectedItem,
                    destino,
                    this.dtTePk_Fecha.Value,
                    (Crucero)this.cbBox_Cruceros.SelectedItem,
                    Viaje.Calcular(((Crucero)this.cbBox_Cruceros.SelectedItem).Camarotes, 1),
                    Viaje.Calcular(((Crucero)this.cbBox_Cruceros.SelectedItem).Camarotes, 0),
                    Viaje.Calcular(destino, duracionDelViaje, 1),
                    Viaje.Calcular(destino, duracionDelViaje, 0),
                    duracionDelViaje
                );

                    ConexionSQLViajes.Modificar(viaje);
                    this.Close();
                


            }
        }

        private void MostrarCrucero(object sender, EventArgs e)
        {
            Crucero crucero = (Crucero)((ComboBox)sender).SelectedItem;

            this.dtGdVw_Cruceros.Rows[0].Cells[1].Value = crucero.Matricula;
            this.dtGdVw_Cruceros.Rows[1].Cells[1].Value = crucero.Nombre;
            this.dtGdVw_Cruceros.Rows[2].Cells[1].Value = crucero.Camarotes;
            this.dtGdVw_Cruceros.Rows[3].Cells[1].Value = crucero.Salones;
            this.dtGdVw_Cruceros.Rows[4].Cells[1].Value = crucero.Casinos;
            this.dtGdVw_Cruceros.Rows[5].Cells[1].Value = crucero.Piscinas;
            this.dtGdVw_Cruceros.Rows[6].Cells[1].Value = crucero.Gimnacios;
            this.dtGdVw_Cruceros.Rows[7].Cells[1].Value = crucero.Capacidad;
            this.dtGdVw_Cruceros.Rows[8].Cells[1].Value = crucero.Tripulantes.Contar;
        }


        private void EstablecerDatos()
        {
            this.cbBox_Cruceros.SelectedItem = this.viaje.Crucero;
            this.cbBox_CiudadPartida.SelectedItem = this.viaje.Partida;
            this.dtTePk_Fecha.Value = this.viaje.Inicio;

            if(Destino.Parse(this.viaje.Destino) is DestinoRegional)
            {
                this.cbBox_Destino.SelectedItem = (ViajesRegionales)this.viaje.Destino;
            }  
            else if(Destino.Parse(this.viaje.Destino) is DestinoExtraRegional)
            {
                this.cbBox_Destino.SelectedItem = (ViajesExtraRegional)this.viaje.Destino;
            }

        }

        private void InformacionCrucero()
        {
            this.dtGdVw_Cruceros.Rows.Clear();

            for (int i = 0; i < 9; i++)
            {
                this.dtGdVw_Cruceros.Rows.Add();
            }

            this.dtGdVw_Cruceros.Rows[0].Cells[0].Value = "Matricula";
            this.dtGdVw_Cruceros.Rows[1].Cells[0].Value = "Nombre";
            this.dtGdVw_Cruceros.Rows[2].Cells[0].Value = "Camarotes";
            this.dtGdVw_Cruceros.Rows[3].Cells[0].Value = "Salones";
            this.dtGdVw_Cruceros.Rows[4].Cells[0].Value = "Casinos";
            this.dtGdVw_Cruceros.Rows[5].Cells[0].Value = "Piscinas";
            this.dtGdVw_Cruceros.Rows[6].Cells[0].Value = "Gimnacios";
            this.dtGdVw_Cruceros.Rows[7].Cells[0].Value = "Capacida de la Bodega";
            this.dtGdVw_Cruceros.Rows[8].Cells[0].Value = "Cantidad de Tripulantes";
        }

        private void AsignarFechasDeViaje()
        {
            DateTime fechaMinima = new DateTime();

            TimeSpan tiempo = new TimeSpan(16, 0, 0, 0);

            fechaMinima = DateTime.Now;
            fechaMinima += tiempo;

            DateTime fechaMaxima = new DateTime(fechaMinima.Year + 1, 12, 31);

            this.dtTePk_Fecha.MinDate = this.viaje.Inicio;
            this.dtTePk_Fecha.MaxDate = fechaMaxima;
        }

    }
}
