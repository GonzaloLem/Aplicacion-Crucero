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
using Entidades.Operaciones;
using Entidades.BaseDeDatos;
using InterfazGrafica.Funciones_Extras;

namespace InterfazGrafica.Formulario_Crud_Personas
{
    public partial class Frm_AgregarPersona : Form
    {
        public Frm_AgregarPersona()
        {
            InitializeComponent();
        }

        private void Frm_AgregarPersona_Load(object sender, EventArgs e)
        {
            this.GrpBox_Pasajero.Visible = false;
            this.GrpBox_DatosCapitan.Visible = false;
            this.Btn_AgregarPersona.Visible = false;

            foreach(Nacionalidades item in Enum.GetValues(typeof(Nacionalidades)))
            {
                this.CbBox_Nacionalidades.Items.Add(item);
            }

            foreach(Roles item in Enum.GetValues(typeof(Roles)))
            {
                this.CbBox_RolPersona.Items.Add(item);       
            }

            foreach(Clases item in Enum.GetValues(typeof(Clases)))
            {
                if (((int)item) != 2)
                {
                    this.CbBox_Pasajero_Clase.Items.Add(item);
                }                 
            }

            foreach(PuestosDeTrabajo item in Enum.GetValues(typeof(PuestosDeTrabajo)))
            {
                this.CbBox_Empleado_Puesto.Items.Add(item);
            }

        }

        private void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            if(this.TxtBox_Nombre.Text.Length > 2 && this.TxtBox_Apellido.Text.Length > 2 && this.TxtBox_Edad.Text != "" 
                && this.TxtBox_Dni.Text.Length == 8 && this.TxtBox_Celular.Text.Length == 10 
                && this.CbBox_Nacionalidades.SelectedItem is not null && this.CbBox_RolPersona.SelectedItem is not null)
            {
                this.ClientSize = new System.Drawing.Size(349, 236);
                this.MinimumSize = new System.Drawing.Size(349, 236);

                this.Btn_AgregarPersona.Visible = false;
                this.GrpBox_Pasajero.Visible = false;
                this.GrpBox_PreferenciasPasajero.Visible = false;
                this.GrpBox_DatosCapitan.Visible = false;
                this.GrpBox_Empleado_Datos.Visible = false;

                if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
                {
                    this.ClientSize = new System.Drawing.Size(848, 255);
                    this.MinimumSize = new System.Drawing.Size(848, 255);
                    this.GrpBox_Pasajero.Visible = true;
                    this.GrpBox_PreferenciasPasajero.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(453, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
                else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
                {
                    this.ClientSize = new System.Drawing.Size(499, 255);
                    this.MinimumSize = new System.Drawing.Size(499, 255);
                    this.GrpBox_DatosCapitan.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
                else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
                {
                    this.ClientSize = new System.Drawing.Size(499, 255);
                    this.MinimumSize = new System.Drawing.Size(499, 255);
                    this.GrpBox_Empleado_Datos.Visible = true;
                    this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
                    this.Btn_AgregarPersona.Visible = true;
                }
            }
        }

        private void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {
            if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
            {
                this.AgregarPasajero();
            }
            else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
            {
                this.AgregarEmpleado();
            }
            else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
            {
                this.AgregarCapitan();
            }

            Extras.Limpiar(this.GrpBox_Contenedor);
            Extras.Limpiar(this.GrpBox_Pasajero);
            Extras.Limpiar(this.GrpBox_PreferenciasPasajero);
            Extras.Limpiar(this.GrpBox_Empleado_Datos);
            Extras.Limpiar(this.GrpBox_DatosCapitan);


        }

        #region Metodos de Agregar Personas
        private void AgregarPasajero()
        {
            if (this.TxtBox_Correo.Text != "" && this.CbBox_Pasajero_Clase.SelectedItem != null && this.TxtBox_Bolsos.Text != "" && this.TxtBox_Maletas.Text != "" && this.TxtBox_PesoMaletas.Text != "")
            {
                Equipaje equipaje = new Equipaje(int.Parse(this.TxtBox_Bolsos.Text), int.Parse(this.TxtBox_Maletas.Text), int.Parse(this.TxtBox_PesoMaletas.Text));

                if (ValidarEquipaje(equipaje))
                {
                    ConexionPasajeros conexion = new ConexionPasajeros();

                    Pasajero pasajero = new Pasajero
                    (
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

                            if (conexion.Obtener() != pasajero)
                            {
                                conexion.Insertar(pasajero);
                            }
                }
            }
        }

        private void AgregarEmpleado()
        {
            if (this.CbBox_Empleado_Puesto.SelectedItem != null)
            {
                ConexionEmpleados conexion = new ConexionEmpleados();

                Empleado empleado = new Empleado
                (
                    this.TxtBox_Nombre.Text,
                    this.TxtBox_Apellido.Text,
                    int.Parse(this.TxtBox_Edad.Text),
                    int.Parse(this.TxtBox_Dni.Text),
                    (Nacionalidades)this.CbBox_Nacionalidades.SelectedItem,
                    double.Parse(this.TxtBox_Celular.Text),
                    (PuestosDeTrabajo)this.CbBox_Empleado_Puesto.SelectedItem
                );


                    if (conexion.Obtener() != empleado)
                    {
                        conexion.Insertar(empleado);
                    }
            }
        }

        private void AgregarCapitan()
        {
            if(this.TxtBox_Capitan_HorasViaje.Text != "")
            {

                ConexionCapitan conexion = new ConexionCapitan();

                Capitan capitan = new Capitan
                (
                    this.TxtBox_Nombre.Text,
                    this.TxtBox_Apellido.Text,
                    int.Parse(this.TxtBox_Edad.Text),
                    int.Parse(this.TxtBox_Dni.Text),
                    (Nacionalidades)this.CbBox_Nacionalidades.SelectedItem,
                    double.Parse(this.TxtBox_Celular.Text),
                    int.Parse(this.TxtBox_Capitan_HorasViaje.Text)
                );

                    if(conexion.Obtener() != capitan)
                    {
                        conexion.Insertar(capitan);
                    }
            }
        }

        #endregion
        private bool ValidarEquipaje(Equipaje equipaje)
        {
            bool retorno = true;

                if((Clases)this.CbBox_Pasajero_Clase.SelectedItem == Clases.Turista && equipaje.Bolsos > 1 && equipaje.Maletas > 1 && equipaje.Peso > 30)
                {
                    retorno = false;
                }
                else if ((Clases)this.CbBox_Pasajero_Clase.SelectedItem == Clases.Premium && equipaje.Bolsos > 1 && equipaje.Maletas > 2 && equipaje.Peso > 50)
                {
                    retorno = false;
                }

            return retorno;
        }

        private void Validar_SoloLetras(object sender, KeyPressEventArgs e)
        {
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || e.KeyChar == 241 || e.KeyChar == 209 || e.KeyChar == 08))
            {
                e.Handled = true;
                return;
            }
        }

        private void Validar_SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if(!((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar == 08)))
            {
                e.Handled = true;
                return;
            }
        }

        private void Validar_LetrasNumerosCaracterEspecial(object sender, KeyPressEventArgs e)
        {
            if(!( (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || (e.KeyChar > 47 && e.KeyChar < 58) || e.KeyChar == 241 || e.KeyChar == 209 || e.KeyChar == 08 || e.KeyChar == 64 || e.KeyChar == 46) )
            {
                e.Handled = true;
                return;
            }
        }


    }
}
