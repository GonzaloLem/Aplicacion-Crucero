using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using Entidades.Listas;
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

        public static void Insertar(Persona persona, Viaje viaje, Crucero crucero)
        {

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Tripulante (ID_Persona, ID_Viaje, ID_Crucero, Estado) VALUES";
                    cadena +=
                    "("
                        + persona.ID + ","
                        + viaje.ID + ","
                        + crucero.ID + ","
                        + 1
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

        public static void Eliminar(Viaje viaje)
        {
            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"delete FROM Tripulante WHERE ID_Viaje = {viaje.ID} ";

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

        public static Almacenamiento<Persona> Obtener(int idCrucero)
        {
            //Func<Almacenamiento<Persona>, Persona, int> comparador = Persona.Comparar;

            Almacenamiento<Persona> lista = new Almacenamiento<Persona>(Persona.Comparar);

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Tripulante where ID_Crucero = {idCrucero}";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.lector = ConexionSQLTripulantes.comando.ExecuteReader();

                    while (ConexionSQLTripulantes.lector.Read())
                    {
                        lista += ConexionSQLPersona.Obtener_Persona((int)ConexionSQLTripulantes.lector["ID_Persona"]);   
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

        public static Almacenamiento<Persona> Obtener(Viaje viaje)
        {
            Almacenamiento<Persona> lista = new Almacenamiento<Persona>(Persona.Comparar);

            if (ConexionSQLTripulantes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Tripulante where ID_Crucero = {viaje.Crucero.ID} and ID_Viaje = {viaje.ID}";

                    ConexionSQLTripulantes.comando = new SqlCommand();

                    ConexionSQLTripulantes.comando.CommandType = CommandType.Text;
                    ConexionSQLTripulantes.comando.CommandText = cadena;
                    ConexionSQLTripulantes.comando.Connection = ConexionSQLTripulantes.conexion;

                    ConexionSQLTripulantes.conexion.Open();

                    ConexionSQLTripulantes.lector = ConexionSQLTripulantes.comando.ExecuteReader();

                    while (ConexionSQLTripulantes.lector.Read())
                    {
                        lista += ConexionSQLPersona.Obtener_Persona((int)ConexionSQLTripulantes.lector["ID_Persona"]);
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


        #endregion

    }
}
