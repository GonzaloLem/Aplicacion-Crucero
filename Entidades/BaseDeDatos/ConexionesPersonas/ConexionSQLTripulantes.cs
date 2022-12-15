using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Entidades.Personas;
using Entidades.Barcos;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    public static class ConexionSQLTripulantes
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        private static SqlDataAdapter adaptador;

        static ConexionSQLTripulantes()
        {
            ConexionSQLTripulantes.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            ConexionSQLTripulantes.comando = new SqlCommand();
            ConexionSQLTripulantes.adaptador = new SqlDataAdapter();
            ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
            ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

        }

        #region Probar conexion
        private static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                ConexionSQLTripulantes.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                {
                    ConexionSQLTripulantes.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public static void Insertar(Persona persona, Crucero crucero)
        {

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Tripulante (ID_Persona, ID_Crucero) VALUES";
                    cadena +=
                    "("
                        + persona.ID + ","
                        + crucero.ID
                    + ")";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Modificar

        public static void Modificar(int id)
        {
            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"update Triputante sett";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Eliminar

        public static void Eliminar(Persona persona)
        {
            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"delete FROM Triputante WHERE ID_Persona = {persona.ID} ";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Buscar

        public static bool Buscar(Persona persona)
        {
            bool retorno = false;

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Tripulante WHERE ID_Persona = {persona.ID} ";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.lector = ConexionSQLTripulantes.comando.ExecuteReader();

                    while (ConexionSQLTripulantes.lector.Read())
                    {   

                            retorno = true;
                        
                    }
                    ConexionSQLTripulantes.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        #endregion

        #region Obtener

        public static AlmacenamientoPersonas<Persona> Obtener(int idCrucero)
        {
            AlmacenamientoPersonas<Persona> lista = new AlmacenamientoPersonas<Persona>(100000);

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Tripulante";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.lector = ConexionSQLTripulantes.comando.ExecuteReader();

                    while (ConexionSQLTripulantes.lector.Read())
                    {
                        if((int)ConexionSQLTripulantes.lector["ID_Crucero"] == idCrucero)
                        {
                            lista += ConexionSQLPersona.Obtener((int)ConexionSQLTripulantes.lector["ID_Persona"]);
                        }
                        
                    }
                    ConexionSQLTripulantes.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }

            return lista;
        }

        /*
        public static Persona Obtener(int id)
        {
            Persona retorno = null;

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Tripulante WHERE ID = {id}";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.lector = ConexionSQLTripulantes.comando.ExecuteReader();

                    while (ConexionSQLTripulantes.lector.Read())
                    {
                        //retorno =
                    }
                    ConexionSQLTripulantes.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLTripulantes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLTripulantes.conexion.Close();
                    }
                }
            }

            return retorno;
        }*/

        #endregion

    }
}
