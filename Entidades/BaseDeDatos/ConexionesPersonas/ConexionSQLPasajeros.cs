using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Personas;
using Entidades.Extensiones;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    internal class ConexionSQLPasajeros
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter adaptador;

        public ConexionSQLPasajeros()
        {
            this.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            this.comando = new SqlCommand();
            this.adaptador = new SqlDataAdapter();
            this.comando.CommandType = CommandType.Text;
            this.comando.Connection = this.conexion;

        }

        #region Probar conexion
        private bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public void Insertar(Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLEquipaje.Insertar(pasajero.Equipaje);

                    

                    string cadena = "INSERT INTO Pasajero (Correo, Clase, ID_Equipaje, Casino, Piscina, Gimnacio) VALUES";
                    cadena +=
                        "("
                        + "'" + pasajero.Correo + "',"
                        + ((int)pasajero.Clase) + ","
                        + ConexionSQLEquipaje.Obtener() + ","
                        + new byte().Conversor(pasajero.Casino) + ","
                        + new byte().Conversor(pasajero.Piscina) + ","
                        + new byte().Conversor(pasajero.Gimnacio)
                        + ")";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
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

        #region Modificar

        public void Modificar(int id, Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLEquipaje.Modificar(pasajero.Equipaje);

                    string cadena = $"update Pasajero set " +
                        $"Correo = '{pasajero.Correo}', " +
                        $"Clase = {((int)pasajero.Clase)}, " +
                        $"Casino = {new byte().Conversor(pasajero.Casino)}, " +
                        $"Piscina = {new byte().Conversor(pasajero.Piscina)}, " +
                        $"Gimnacio = {new byte().Conversor(pasajero.Gimnacio)} " +
                        $"WHERE ID = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
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

        #region Eliminar

        public void Eliminar(int idPasajero, int idEquipaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"delete FROM Pasajero WHERE ID = {idPasajero} ";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.comando.ExecuteNonQuery();

                    ConexionSQLEquipaje.Eliminar(idEquipaje);


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
        /// Busca la id mas alta de la Tabla Pasajeros
        /// </summary>
        public int Obtener()
        {
            int retorno = -1;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT MAX(ID) as ID_Maximo FROM Pasajero";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = (int)this.lector["ID_Maximo"];
                    }
                    this.lector.Close();
                }
                catch (Exception)
                {

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

        public Pasajero Obtener_Pasajero(int id)
        {
            Pasajero retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Pasajero WHERE ID = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = new Pasajero
                            (           
                                this.lector["Correo"].ToString(),
                                (Clases)this.lector["Clase"],
                                ConexionSQLEquipaje.Obtener_Equipaje((int)this.lector["ID_Equipaje"]),
                                (bool)this.lector["Casino"],
                                (bool)this.lector["Piscina"],
                                (bool)this.lector["Gimnacio"]
                            );
                    }
                    this.lector.Close();

                }
                catch (Exception)
                {

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

        #endregion

    }
}
