﻿using System;
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
using InterfazGrafica.Formulario_Estadisticas;
using Entidades;
using Entidades.BaseDeDatos;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Personas;
using Entidades.Viajes;
using Entidades.Listas;
using Entidades.Archivos;
using Entidades.Exepciones;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Diagnostics;

namespace InterfazGrafica
{
    public partial class Frm_Principal : Form
    {
        #region Constructores

        public Frm_Principal()
        {
            InitializeComponent();
          
        }

        #endregion

        #region Eventos
        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            Task tareaVerificarViajes = new Task(this.VerificarViajes);
            this.Listar(conexionViajes.Obtener());
            tareaVerificarViajes.Start();




        }   

        private void Btn_AgregarPersona_Click(object sender, EventArgs e)
        {
            Frm_AgregarPersona formAgregarPersona = new Frm_AgregarPersona();
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();
            formAgregarPersona.ShowDialog();
            this.Listar(conexionViajes.Obtener());
        }

        private void Btn_ListarPersonasSistema_Click(object sender, EventArgs e)
        {
            Frm_ListarPersonas formListarPersonas = new Frm_ListarPersonas();

            formListarPersonas.ShowDialog();
        }

        private void Btn_AgregarViaje_Click(object sender, EventArgs e)
        {
            Frm_CrearViaje formCrearViaje = new Frm_CrearViaje();
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            formCrearViaje.ShowDialog();
            this.Listar(conexionViajes.Obtener());
        }

        private void Btn_ModificarViaje_Click(object sender, EventArgs e)
        {
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            if (this.DtGdVw_ListaViajes.SelectedRows.Count == 1 && conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value).Estado != Disponibilidad.Navegando)
            {
                Frm_ViajesModificar formModifciarViaje = new Frm_ViajesModificar(conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value));
                formModifciarViaje.ShowDialog();
                this.Listar(conexionViajes.Obtener());
            }
        }

        private void Btn_EliminarViaje_Click(object sender, EventArgs e)
        {
            if (this.DtGdVw_ListaViajes.SelectedRows.Count == 1)
            {
                ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

                conexionViajes.Eliminar((conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value)));
                this.Listar(conexionViajes.Obtener());
            }
        }

        private void btn_CrudCrucero_Click(object sender, EventArgs e)
        {
            Frm_ListarCruceros formCruceros = new Frm_ListarCruceros();
            

            formCruceros.ShowDialog();
          
        }

        private void btn_AgregarPersona_AlViaje_Click(object sender, EventArgs e)
        {
            if(this.DtGdVw_ListaViajes.SelectedRows.Count == 1)
            {
                try
                {
                    ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

                    ExepcionViaje excep = new ExepcionViaje();

                    excep.AgregarPersona((conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value)));

                    Frm_AgregarPersonaAlViaje formAgregarAlViaje = new Frm_AgregarPersonaAlViaje((conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value)));
                    formAgregarAlViaje.ShowDialog();

                    this.Listar(conexionViajes.Obtener());

                }
                catch(Exception ex)
                { 
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_ListarPersonasDelViaje_Click(object sender, EventArgs e)
        {
            ConexionSQLTripulantes conexion = new ConexionSQLTripulantes();
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            if (this.DtGdVw_ListaViajes.SelectedRows.Count == 1)
            {
                Frm_ListarTripulantes formListarPeronas = new Frm_ListarTripulantes(conexion.Lista(conexionViajes.Obtener_Viaje((int)this.DtGdVw_ListaViajes.Rows[this.DtGdVw_ListaViajes.SelectedRows[0].Index].Cells[0].Value)));
                formListarPeronas.ShowDialog();
            }
        }
        private void Btn_EstadisticasHistoricas_Click(object sender, EventArgs e)
        {
            Frm_EstadisticasHistoricas formEstadisticas = new Frm_EstadisticasHistoricas();
            formEstadisticas.ShowDialog();
        }

        #endregion

        #region Metodos Extras
        private void VerificarViajes()
        {
            ConexionSQLViajes conexionViajes = new ConexionSQLViajes();

            Almacenamiento<Viaje> listaInicial = conexionViajes.Obtener();
            
                while (true)
                {
                    Almacenamiento<Viaje> listaActulizada = conexionViajes.Obtener();
                        if (listaActulizada != listaInicial)
                        {
                            listaInicial = listaActulizada; 
                                       
                                if (InvokeRequired)
                                {
                                    Invoke(new Action(() => this.Listar( listaActulizada) ));
                                    
                                }
                        }
                        Thread.Sleep(1000);
                }

        }


        private void Listar(Almacenamiento<Viaje> lista)
        {
            ConexionSQLTripulantes conexion = new ConexionSQLTripulantes();

            this.DtGdVw_ListaViajes.Rows.Clear();
            for (int i = 0; i < lista.Contar; i++)
            {
                if (lista[i].Estado != Disponibilidad.Terminado)
                {
                    int index = this.DtGdVw_ListaViajes.Rows.Add();

                    this.DtGdVw_ListaViajes.Rows[index].Cells[0].Value = lista[i].ID;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[1].Value = lista[i].Partida;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[2].Value = Destino.Parse(lista[i].Destino);
                    this.DtGdVw_ListaViajes.Rows[index].Cells[3].Value = lista[i].Inicio;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[4].Value = lista[i].Crucero.Nombre;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[5].Value = lista[i].CamarotesPremium;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[6].Value = lista[i].CamarotesTurista;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[7].Value = lista[i].CostoPremium;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[8].Value = lista[i].CostoTurista;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[9].Value = lista[i].Duracion;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[10].Value = lista[i].Llegada;
                    this.DtGdVw_ListaViajes.Rows[index].Cells[11].Value = conexion.Lista(lista[i]).Contar;

                    this.DtGdVw_ListaViajes.Rows[index].DefaultCellStyle.BackColor = Color.Green;
                    if (lista[i].Estado == Disponibilidad.Navegando)
                    {
                        this.DtGdVw_ListaViajes.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (lista[i].Estado == Disponibilidad.Lleno)
                    {
                        this.DtGdVw_ListaViajes.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                    }

                }

            }
        }



        #endregion

    }
}
