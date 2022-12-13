﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        #region Eventos
        private void Frm_AgregarPersona_Load(object sender, EventArgs e)
        {

            this.VentanaDefault();

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
        private protected void Btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (this.TxtBox_Nombre.Text.Length > 2 && this.TxtBox_Apellido.Text.Length > 2 && this.TxtBox_Edad.Text != ""
                && this.TxtBox_Dni.Text.Length == 8 && this.TxtBox_Celular.Text.Length == 10
                && this.CbBox_Nacionalidades.SelectedItem is not null && this.CbBox_RolPersona.SelectedItem is not null)
            {
                this.VentanaDefault();

                if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
                {
                    this.VentanaPasajero();
                }
                else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
                {
                    this.VentanaCapitan();
                }
                else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
                {
                    this.VentanaEmpleado();
                }

            }
        }

        private protected virtual void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {
            if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Cliente)
            {

                Pasajero pasajero = this.ValidarPasajero();

                if (pasajero is not null && ConexionSQLPersona.Obtener() != pasajero)
                {
                    ConexionSQLPersona.Insertar(pasajero);   
                }
            }
            else if ((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Empleado)
            {
                Empleado empleado = this.ValidarEmpleado();

                if (empleado is not null && ConexionSQLPersona.Obtener() != empleado)
                {
                    ConexionSQLPersona.Insertar(empleado);   
                }
            }
            else if((Roles)this.CbBox_RolPersona.SelectedItem == Roles.Capitan)
            {
                Capitan capitan = this.ValidarCapitan();

                if (capitan is not null && ConexionSQLPersona.Obtener() != capitan)
                {
                    ConexionSQLPersona.Insertar(capitan);   
                }
            }

            Extras.Limpiar(this.GrpBox_Contenedor);
            Extras.Limpiar(this.GrpBox_Pasajero);
            Extras.Limpiar(this.GrpBox_PreferenciasPasajero);
            Extras.Limpiar(this.grpBox_Capitan_Datos);
            Extras.Limpiar(this.grpBox_Empleado_Datos);


        }
        #endregion

        #region Metodos de Agregar Personas
        private protected virtual Pasajero ValidarPasajero()
        {
            Pasajero retorno = null;

            if (this.TxtBox_Correo.Text != "" && this.CbBox_Pasajero_Clase.SelectedItem != null && this.TxtBox_Bolsos.Text != "" && this.TxtBox_Maletas.Text != "" && this.TxtBox_PesoMaletas.Text != "")
            {
                Equipaje equipaje = new Equipaje(int.Parse(this.TxtBox_Bolsos.Text), int.Parse(this.TxtBox_Maletas.Text), int.Parse(this.TxtBox_PesoMaletas.Text));

                if (this.ValidarEquipaje(equipaje))
                {
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

                    retorno = pasajero;
                }
            }
            return retorno;
        }

        private protected virtual Empleado ValidarEmpleado()
        {
            Empleado retorno = null;

            if (this.CbBox_Empleado_Puesto.SelectedItem != null)
            {         
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

                retorno = empleado;
            }
            return retorno;
        }

        private protected virtual Capitan ValidarCapitan()
        {
            Capitan retorno = null;

            if(this.TxtBox_Capitan_HorasViaje.Text != "")
            {
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

                retorno = capitan;
            }
            return retorno;
        }

        #endregion

        #region Ventanas
        private void VentanaPasajero()
        {
            this.ClientSize = new System.Drawing.Size(848, 288);
            this.MinimumSize = new System.Drawing.Size(848, 288);
            this.MaximumSize = new Size(848, 288);
            this.Btn_AgregarPersona.Location = new System.Drawing.Point(453, 205);
            this.GrpBox_Pasajero.Visible = true;
            this.GrpBox_PreferenciasPasajero.Visible = true;

            this.Btn_AgregarPersona.Visible = true;
        }

        private void VentanaEmpleado()
        {
            this.ClientSize = new System.Drawing.Size(499, 288);
            this.MinimumSize = new System.Drawing.Size(499, 288);
            this.MaximumSize = new Size(499, 288);
            this.grpBox_Empleado_Datos.Location = new Point();

            this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
            this.Btn_AgregarPersona.Visible = true;
            this.grpBox_Empleado_Datos.Location = new System.Drawing.Point(350, 51);
            this.grpBox_Empleado_Datos.Visible = true;
        }

        private void VentanaCapitan()
        {
            this.ClientSize = new System.Drawing.Size(499, 288);
            this.MinimumSize = new System.Drawing.Size(499, 288);
            this.MaximumSize = new Size(499, 288);
            this.Btn_AgregarPersona.Location = new System.Drawing.Point(350, 205);
            this.Btn_AgregarPersona.Visible = true;
            this.grpBox_Capitan_Datos.Location = new System.Drawing.Point(350, 51);
            this.grpBox_Capitan_Datos.Visible = true;
        }

        private void VentanaDefault()
        {
            this.Size = new Size(367, 288);
            this.ClientSize = new System.Drawing.Size(349, 236);
            this.MaximumSize = new Size(367, 288);
            this.MinimumSize = new System.Drawing.Size(367, 288);


            this.Btn_AgregarPersona.Visible = false;
            this.GrpBox_Pasajero.Visible = false;
            this.GrpBox_PreferenciasPasajero.Visible = false;
            this.grpBox_Empleado_Datos.Visible = false;
            this.grpBox_Capitan_Datos.Visible = false;
        }
        #endregion

        #region Validaciones

        private protected bool ValidarEquipaje(Equipaje equipaje)
        {
            bool retorno = true;

            if ((Clases)this.CbBox_Pasajero_Clase.SelectedItem == Clases.Turista && equipaje.Bolsos > 1 && equipaje.Maletas > 1 && equipaje.Peso > 30)
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

        #endregion

    }
}
