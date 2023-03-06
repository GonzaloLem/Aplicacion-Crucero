using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGrafica.Funciones_Extras;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.Personas;
using Entidades.BaseDeDatos.ConexionesPersonas;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_ModificarPersona : Frm_AgregarPersona
    {
        private Persona persona;

        private Frm_ModificarPersona()
        {
            InitializeComponent();
        }

        public Frm_ModificarPersona(Persona persona) : this()
        {
            this.persona = persona;
        }

        private void Frm_ModificarPersonacs_Load(object sender, EventArgs e)
        {
            this.AsignarDatosPrincipales();
        }

        private protected override void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {
            ConexionSQLPersona conexionPersonas = new ConexionSQLPersona();

            if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
            {

                Pasajero pasajero = this.ValidarPasajero();

                if (pasajero is not null && conexionPersonas.Obtener_Persona(this.persona.ID) is not null)
                {
                    conexionPersonas.Modificar(pasajero);
                }
            }
            else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
            {
                Empleado empleado = this.ValidarEmpleado();

                if (empleado is not null && conexionPersonas.Obtener_Persona(this.persona.ID) is not null)
                {
                    conexionPersonas.Modificar(empleado);
                }
            }
            else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
            {
                Capitan capitan = this.ValidarCapitan();

                if (capitan is not null && conexionPersonas.Obtener_Persona(this.persona.ID) is not null)
                {
                    conexionPersonas.Modificar(capitan);
                }   
            }

            Extras.Limpiar(this.GrpBox_Contenedor);
            Extras.Limpiar(this.GrpBox_Pasajero);
            Extras.Limpiar(this.GrpBox_PreferenciasPasajero);
            Extras.Limpiar(this.grpBox_Capitan_Datos);
            Extras.Limpiar(this.grpBox_Empleado_Datos);
        }

        #region Asignar Datos
        private void AsignarDatosPrincipales()
        {
            this.TxtBox_Nombre.Text = this.persona.Nombre;
            this.TxtBox_Apellido.Text = this.persona.Apellido;
            this.TxtBox_Edad.Text = this.persona.Edad.ToString();
            this.TxtBox_Dni.Text = this.persona.DNI.ToString();
            this.TxtBox_Celular.Text = this.persona.Celular.ToString();
            this.CbBox_Nacionalidades.SelectedItem = this.persona.Nacionalidad;
            this.CbBox_RolPersona.SelectedItem = this.persona.Rol;
            this.Btn_Confirmar_Click(this.Btn_Confirmar, new EventArgs());
            this.AsignarDatosPersona();

        }

        private void AsignarDatosPersona()
        {
            if(persona is Pasajero)
            {
                this.AsignarDatosPasajero();
            }
            else if(persona is Empleado)
            {
                this.AsignarDatosEmpleado();
            }
            else if(persona is Capitan)
            {
                this.AsignarDatosCapitan();
            }
        }

        private void AsignarDatosPasajero()
        {
            this.TxtBox_Correo.Text = ((Pasajero)persona).Correo;
            this.CbBox_Pasajero_Clase.SelectedItem = ((Pasajero)persona).Clase;
            this.TxtBox_Bolsos.Text = ((Pasajero)persona).Equipaje.Bolsos.ToString();
            this.TxtBox_Maletas.Text = ((Pasajero)persona).Equipaje.Maletas.ToString();
            this.TxtBox_PesoMaletas.Text = ((Pasajero)persona).Equipaje.Peso.ToString();
            this.CkBox_Casino.Checked = ((Pasajero)persona).Casino;
            this.CkBox_Gimnacio.Checked = ((Pasajero)persona).Gimnacio;
            this.CkBox_Piscina.Checked = ((Pasajero)persona).Piscina;
        }

        private void AsignarDatosEmpleado()
        {
            this.CbBox_Empleado_Puesto.SelectedItem = ((Empleado)persona).Puesto;
        }

        private void AsignarDatosCapitan()
        {
            this.TxtBox_Capitan_HorasViaje.Text = ((Capitan)persona).Horas.ToString();
        }

        #endregion

        #region Metodos de Agregar Personas
        private protected override Pasajero ValidarPasajero()
        {
            Pasajero retorno = null;

            if (this.TxtBox_Correo.Text != "" && this.CbBox_Pasajero_Clase.SelectedItem != null && this.TxtBox_Bolsos.Text != "" && this.TxtBox_Maletas.Text != "" && this.TxtBox_PesoMaletas.Text != "")
            {
                Equipaje equipaje = new Equipaje(((Pasajero)this.persona).Equipaje.ID ,int.Parse(this.TxtBox_Bolsos.Text), int.Parse(this.TxtBox_Maletas.Text), int.Parse(this.TxtBox_PesoMaletas.Text));

                if (this.ValidarEquipaje(equipaje))
                {
                    Pasajero pasajero = new Pasajero
                    (
                        this.persona.ID,
                        this.TxtBox_Nombre.Text,
                        this.TxtBox_Apellido.Text,
                        int.Parse(this.TxtBox_Edad.Text),
                        int.Parse(this.TxtBox_Dni.Text),
                        (Nacionalidades)this.CbBox_Nacionalidades.SelectedItem,
                        double.Parse(this.TxtBox_Celular.Text),
                        this.TxtBox_Correo.Text,
                        (Clases)this.CbBox_Pasajero_Clase.SelectedItem,
                        equipaje,
                        this.CkBox_Casino.Checked,
                        this.CkBox_Gimnacio.Checked,
                        this.CkBox_Piscina.Checked
                    );

                    retorno = pasajero;
                }
            }
            return retorno;
        }

        private protected override Empleado ValidarEmpleado()
        {
            Empleado retorno = null;

            if (this.CbBox_Empleado_Puesto.SelectedItem != null)
            {
                Empleado empleado = new Empleado
                (
                    this.persona.ID,
                    this.TxtBox_Nombre.Text,
                    this.TxtBox_Apellido.Text,
                    int.Parse(this.TxtBox_Edad.Text),
                    int.Parse(this.TxtBox_Dni.Text),
                    (Nacionalidades)this.CbBox_Nacionalidades.SelectedItem,
                    double.Parse(this.TxtBox_Celular.Text),
                    (PuestosDeTrabajo)this.CbBox_Empleado_Puesto.SelectedItem,
                    ((Empleado)this.persona).Fecha
                );

                retorno = empleado;
            }
            return retorno;
        }

        private protected override Capitan ValidarCapitan()
        {
            Capitan retorno = null;

            if (this.TxtBox_Capitan_HorasViaje.Text != "")
            {
                Capitan capitan = new Capitan
                (
                    persona.ID,
                    this.TxtBox_Nombre.Text,
                    this.TxtBox_Apellido.Text,
                    int.Parse(this.TxtBox_Edad.Text),
                    int.Parse(this.TxtBox_Dni.Text),
                    (Nacionalidades)this.CbBox_Nacionalidades.SelectedItem,
                    double.Parse(this.TxtBox_Celular.Text),
                    int.Parse(this.TxtBox_Capitan_HorasViaje.Text),
                    ((Capitan)this.persona).Viajes
                );

                retorno = capitan;
            }
            return retorno;
        }

        #endregion


    }
}
