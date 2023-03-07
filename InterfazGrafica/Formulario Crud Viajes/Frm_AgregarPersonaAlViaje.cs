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
using Entidades.Listas;
using Entidades.BaseDeDatos;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Viajes;
using Entidades.Personas;
using Entidades.Barcos;
using Entidades.Extensiones;

namespace InterfazGrafica.Formulario_Crud_Viajes
{
    public partial class Frm_AgregarPersonaAlViaje : Form
    {
        Viaje viaje;
        private Frm_AgregarPersonaAlViaje()
        {
            InitializeComponent();
        }

        public Frm_AgregarPersonaAlViaje(Viaje viaje) : this()
        {
            this.viaje = viaje;
        }

        #region Eventos
        private void Frm_AgregarPersonaAlViaje_Load(object sender, EventArgs e)
        {
            ConexionSQLPersona conexion = new ConexionSQLPersona();

            this.DatosDelViaje();
            this.ListarPersonas(conexion.Obtener_Lista());
            this.DataGridPorDefecto();
        }

        private void btn_AñadirPersona_Click(object sender, EventArgs e)
        {

            ConexionSQLTripulantes conexionTripulantes = new ConexionSQLTripulantes();

            if (this.dtGdVw_PersonasDisponibles.SelectedRows.Count == 1)
            {

                ConexionSQLPersona conexionSQLPersona = new ConexionSQLPersona();
                ConexionSQLTripulantes conexionTripulante = new ConexionSQLTripulantes();


                Persona persona = conexionSQLPersona.Obtener_Persona((int)this.dtGdVw_PersonasDisponibles.Rows[this.dtGdVw_PersonasDisponibles.SelectedRows[0].Index].Cells[0].Value);
                


                    if(persona is Pasajero)
                    {
                        if(this.viaje.Requisitos((Pasajero)persona))
                        {
                            conexionTripulante.Insertar(this.viaje, persona);
                        }
                        else
                        {
                            MessageBox.Show("El viaje no cumple con los Requisitos del Pasajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    
                    }
                    else
                    {
                        conexionTripulante.Insertar(this.viaje, persona);                           
                    }

                this.ListarPersonas(conexionSQLPersona.Obtener_Lista());

            }
        }

        private void MostrarInfoAdicional(object sender, EventArgs e)
        {
            if (this.dtGdVw_PersonasDisponibles.SelectedRows.Count == 1)
            {
                ConexionSQLPersona conexionSQLPersona = new ConexionSQLPersona();

                this.DataGridPorDefecto();
                Persona persona = conexionSQLPersona.Obtener_Persona((int)this.dtGdVw_PersonasDisponibles.Rows[this.dtGdVw_PersonasDisponibles.SelectedRows[0].Index].Cells[0].Value);
                if (persona is Pasajero)
                {
                    this.MostrarCliente((Pasajero)persona);
                }
                else if(persona is Empleado)
                {
                    this.MostrarEmpleado((Empleado)persona);
                }
                else if (persona is Capitan)
                {
                    this.MostrarCapitan((Capitan)persona);
                }
            }
        }

        #endregion

        #region Metodos
        private void ListarPersonas(Almacenamiento<Persona> lista)
        {

            ConexionSQLTripulantes conexionTripulantes = new ConexionSQLTripulantes();

            this.dtGdVw_PersonasDisponibles.Rows.Clear();
            for(int i=0;i<lista.Contar;i++)
            {
                if (!conexionTripulantes.Buscar(lista[i], this.viaje.Crucero))
                {
                    int index = this.dtGdVw_PersonasDisponibles.Rows.Add();

                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[0].Value = lista[i].ID;
                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[1].Value = lista[i].Nombre;
                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[2].Value = lista[i].Apellido;
                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[3].Value = lista[i].Edad;
                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[4].Value = lista[i].DNI;
                    this.dtGdVw_PersonasDisponibles.Rows[index].Cells[5].Value = lista[i].Tipo;
                }

            }
        }

        private void DatosDelViaje()
        {
            for(int i=0;i<8;i++)
            {
                this.dtGdVw_InfoDelViaje.Rows.Add();
            }

            this.dtGdVw_InfoDelViaje.Rows[0].Cells[0].Value = "ID";
            this.dtGdVw_InfoDelViaje.Rows[1].Cells[0].Value = "Camarotes Premium";
            this.dtGdVw_InfoDelViaje.Rows[2].Cells[0].Value = "Camarotes Turista";
            this.dtGdVw_InfoDelViaje.Rows[3].Cells[0].Value = "Costo Premium";
            this.dtGdVw_InfoDelViaje.Rows[4].Cells[0].Value = "Costo Turista";
            this.dtGdVw_InfoDelViaje.Rows[5].Cells[0].Value = "Casino";
            this.dtGdVw_InfoDelViaje.Rows[6].Cells[0].Value = "Piscina";
            this.dtGdVw_InfoDelViaje.Rows[7].Cells[0].Value = "Gimnacio";

            this.dtGdVw_InfoDelViaje.Rows[0].Cells[1].Value = this.viaje.ID;
            this.dtGdVw_InfoDelViaje.Rows[1].Cells[1].Value = this.viaje.CamarotesPremium;
            this.dtGdVw_InfoDelViaje.Rows[2].Cells[1].Value = this.viaje.CamarotesTurista;
            this.dtGdVw_InfoDelViaje.Rows[3].Cells[1].Value = this.viaje.CostoPremium;
            this.dtGdVw_InfoDelViaje.Rows[4].Cells[1].Value = this.viaje.CostoTurista;
            this.dtGdVw_InfoDelViaje.Rows[5].Cells[1].Value = new bool().Tiene(this.viaje.Crucero.Casinos, 0);
            this.dtGdVw_InfoDelViaje.Rows[6].Cells[1].Value = new bool().Tiene(this.viaje.Crucero.Piscinas, 0);
            this.dtGdVw_InfoDelViaje.Rows[7].Cells[1].Value = new bool().Tiene(this.viaje.Crucero.Gimnacios, 0);

        }
        #endregion

        #region Metodos del valor de las Columnas
        private void DataGridPorDefecto()
        {
            this.dtGdVw_InfoAdicional_Persona.Rows.Clear();

            //Columnas de Pasajero
            this.Column_InfoAdicional_Pasajero_Correo.Visible = false;
            this.Column_InfoAdicional_Pasajero_Clase.Visible = false;
            this.Column_InfoAdicional_Pasajero_Equipaje.Visible = false;
            this.Column_InfoAdicional_Pasajero_Casino.Visible = false;
            this.Column_InfoAdicional_Pasajero_Piscina.Visible = false;
            this.Column_InfoAdicional_Pasajero_Gimnacion.Visible = false;

            //Columnas de Empleado
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.Visible = false;
            this.Column_InfoAdicional_Empleado_Puesto.Visible = false;

            //Columnas de Capitan
            this.Column_InfoAdicional_Capitan_HorasDeViaje.Visible = false;
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.Visible = false;
        }

        private void MostrarCapitan(Capitan capitan)
        {
            this.Column_InfoAdicional_Capitan_HorasDeViaje.Visible = true;
            this.Column_InfoAdicional_Capitan_ViajesConLaEmpresa.Visible = true;

            int i = this.dtGdVw_InfoAdicional_Persona.Rows.Add();

            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[8].Value = capitan.Horas;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[9].Value = capitan.Viajes;
        }

        private void MostrarEmpleado(Empleado empleado)
        {
            this.Column_InfoAdicional_Empleado_DiaQueSeUnio.Visible = true;
            this.Column_InfoAdicional_Empleado_Puesto.Visible = true;

            int i = this.dtGdVw_InfoAdicional_Persona.Rows.Add();
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[6].Value = empleado.Puesto;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[7].Value = empleado.Fecha;

        }

        private void MostrarCliente(Pasajero pasajero)
        {
            this.Column_InfoAdicional_Pasajero_Correo.Visible = true;
            this.Column_InfoAdicional_Pasajero_Clase.Visible = true;
            this.Column_InfoAdicional_Pasajero_Equipaje.Visible = true;
            this.Column_InfoAdicional_Pasajero_Casino.Visible = true;
            this.Column_InfoAdicional_Pasajero_Piscina.Visible = true;
            this.Column_InfoAdicional_Pasajero_Gimnacion.Visible = true;

            int i = this.dtGdVw_InfoAdicional_Persona.Rows.Add();

            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[0].Value = pasajero.Correo;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[1].Value = pasajero.Clase;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[2].Value = pasajero.Equipaje;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[3].Value = pasajero.Casino;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[4].Value = pasajero.Piscina;
            this.dtGdVw_InfoAdicional_Persona.Rows[i].Cells[5].Value = pasajero.Gimnacio;

        }
        #endregion

        #region Filtrar

        private void Validar(object sender, EventArgs e)
        {

            ConexionSQLPersona conexion = new ConexionSQLPersona();

            foreach (Control item in this.grpBox_Filtro.Controls)
            {
                if (item != sender)
                {
                    ((CheckBox)item).Checked = false;
                }

            }

            if (((CheckBox)sender).Name == this.ckBox_Cliente.Name)
            {
                //this.ListarPersonas(ConexionSQLPersona.Obtener(Roles.Cliente));
            }
            else if (((CheckBox)sender).Name == this.ckBox_Empleado.Name)
            {
                //this.ListarPersonas(ConexionSQLPersona.Obtener(Roles.Empleado));
            }
            else if (((CheckBox)sender).Name == this.ckBox_Capitan.Name)
            {
                //this.ListarPersonas(ConexionSQLPersona.Obtener(Roles.Capitan));
            }

            if(this.ckBox_Cliente.Checked == false && this.ckBox_Empleado.Checked == false && this.ckBox_Capitan.Checked == false)
            {
                this.ListarPersonas(conexion.Obtener_Lista());
            }
        }


        #endregion

    }
}
