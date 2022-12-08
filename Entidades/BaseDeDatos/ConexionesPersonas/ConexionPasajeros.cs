using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Personas;
using Entidades.Operaciones;


namespace Entidades.BaseDeDatos
{
    public class ConexionPasajeros : ConexionSQLServer
    {

        public ConexionPasajeros() : base() { }

        #region Insertar
           public void Insertar(Pasajero pasajero) 
           {
               if (this.ProbarConexion())
               {
                   try
                   {
                       ConexionEquipaje conexionEquipaje = new ConexionEquipaje();
                           conexionEquipaje.Insertar(pasajero.Equipaje);
                           Equipaje equipaje = conexionEquipaje.ObtenerEquipaje();

                           string cadenaComando = "INSERT INTO Pasajero (ID, Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, Correo, Clase, ID_Equipaje, Casino, Gimnacio, Piscina) VALUES";
                           cadenaComando += "(" 
                               + Operacion.InsertarID() + ",'"
                               + pasajero.Nombre + "','"
                               + pasajero.Apellido + "',"
                               + pasajero.Edad + ","
                               + pasajero.DNI + ","
                               + ((int)pasajero.Nacionalidad) + ","
                               + pasajero.Celular + ",'"
                               + pasajero.Correo + "',"
                               + ((int)pasajero.Clase) + ","
                               + equipaje.ID + ","
                               + this.Conversor(pasajero.Casino) + ","
                               + this.Conversor(pasajero.Gimnacio) + ","
                               + this.Conversor(pasajero.Piscina)
                               + ")";

                           this.comando = new SqlCommand();

                           this.comando.CommandType = CommandType.Text;
                           this.comando.CommandText = cadenaComando;
                           this.comando.Connection = this.conexion;

                           this.conexion.Open();

                           this.comando.ExecuteNonQuery();

                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine(ex.ToString());
                   }
                   finally
                   {
                       if (this.conexion.State == ConnectionState.Open)
                       {
                           this.conexion.Close();
                       }
                   }
               }
           }
        #endregion

        #region Obtener

        /// <summary>
        /// Busca la ID mas grande de la base de Pasajeros
        /// </summary>
        /// <returns>int</returns>
        public override int ObtenerID()
        {
            int retorno = -1;

                if (this.ProbarConexion())
                {
                    try
                    {

                        this.comando = new SqlCommand();

                        this.comando.CommandType = CommandType.Text;
                        this.comando.CommandText = "SELECT MAX(ID) as 'id' FROM Pasajero";
                        this.comando.Connection = this.conexion;

                        this.conexion.Open();

                        this.lector = this.comando.ExecuteReader();

                        while (lector.Read())
                        {
                            if (this.lector["id"].ToString() != "")
                            {
                                retorno = (int)this.lector["id"];
                            }

                        }

                        lector.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        if (this.conexion.State == ConnectionState.Open)
                        {
                            this.conexion.Close();
                        }
                    }
                }
            return retorno;
        }


        public AlmacenamientoPersonas<Persona> Obtener()
        {
            AlmacenamientoPersonas<Persona> listaPasajeros = new AlmacenamientoPersonas<Persona>(1000);

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Pasajero";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    ConexionEquipaje conexionEquipaje = new ConexionEquipaje();
                    Equipaje equipaje = conexionEquipaje.BuscarEquipaje((int)lector["ID_Equipaje"]);
                    
                    Pasajero pasajero = new Pasajero(
                    (int)this.lector["ID"], 
                    this.lector["Nombre"].ToString(),
                    this.lector["Apellido"].ToString(),
                    (int)this.lector["Edad"],
                    (int)this.lector["DNI"],
                    (Nacionalidades)this.lector["Nacionalidad"],
                    (double)this.lector["Celular"],
                    this.lector["Correo"].ToString(),
                    (Clases)this.lector["Clase"], 
                    equipaje,
                    (bool)this.lector["Casino"],
                    (bool)this.lector["Gimnacio"],
                    (bool)this.lector["Piscina"]);

                    listaPasajeros += pasajero;
                }
                lector.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaPasajeros;
        }

        #endregion



        #region Metodos extra

        public override int Contar()
        {
            int retorno = -1;

            if (this.ProbarConexion())
            {
                try
                {

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = "SELECT COUNT(ID) as 'contador' FROM Pasajero";
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (lector.Read())
                    {
                        retorno = (int)this.lector["contador"];
                    }

                    lector.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (this.conexion.State == ConnectionState.Open)
                    {
                        this.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        private byte Conversor(bool booleano)
        {
            byte retorno = 0;

                if(booleano == true)
                {
                    retorno = 1;
                }

            return retorno;
        }

        private bool ConversorABooleano(byte numero)
        {
            bool retorno = false;

                if(numero == 1)
                {
                    retorno = true;
                }

            return retorno;
        }
        #endregion

    }
}
