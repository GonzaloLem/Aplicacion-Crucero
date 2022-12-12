using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Personas;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    internal static class ConexionSQLEquipaje
    {

        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        private static SqlDataAdapter adaptador;

        static ConexionSQLEquipaje()
        {
            ConexionSQLEquipaje.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            ConexionSQLEquipaje.comando = new SqlCommand();
            ConexionSQLEquipaje.adaptador = new SqlDataAdapter();
            ConexionSQLEquipaje.comando.CommandType = CommandType.Text;
            ConexionSQLEquipaje.comando.Connection = ConexionSQLEquipaje.conexion;

        }

        #region Probar conexion
        private static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                ConexionSQLEquipaje.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (ConexionSQLEquipaje.conexion.State == ConnectionState.Open)
                {
                    ConexionSQLEquipaje.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public static void Insertar(Equipaje equipaje)
        {
            if (ConexionSQLEquipaje.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Equipaje (Bolsos, Maletas, PesoTotalMaletas) VALUES";
                    cadena +=
                        "("
                        + equipaje.Bolsos + ","
                        + equipaje.Maletas + ","
                        + equipaje.Peso
                        + ")";

                    ConexionSQLEquipaje.comando = new SqlCommand();

                    ConexionSQLEquipaje.comando.CommandType = CommandType.Text;
                    ConexionSQLEquipaje.comando.CommandText = cadena;
                    ConexionSQLEquipaje.comando.Connection = ConexionSQLEquipaje.conexion;

                    ConexionSQLEquipaje.conexion.Open();

                    ConexionSQLEquipaje.comando.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLEquipaje.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLEquipaje.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Obtener

        public static int Obtener()
        {
            int retorno = -1;

            if (ConexionSQLEquipaje.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT MAX(ID) as ID_Maximo FROM Equipaje";

                    ConexionSQLEquipaje.comando = new SqlCommand();

                    ConexionSQLEquipaje.comando.CommandType = CommandType.Text;
                    ConexionSQLEquipaje.comando.CommandText = cadena;
                    ConexionSQLEquipaje.comando.Connection = ConexionSQLEquipaje.conexion;

                    ConexionSQLEquipaje.conexion.Open();

                    ConexionSQLEquipaje.lector = ConexionSQLEquipaje.comando.ExecuteReader();

                    while (ConexionSQLEquipaje.lector.Read())
                    {
                        retorno = (int)ConexionSQLEquipaje.lector["ID_Maximo"];
                    }
                    ConexionSQLEquipaje.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLEquipaje.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLEquipaje.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        public static Equipaje Obtener(int id)
        {
            Equipaje retorno = null;

            if (ConexionSQLEquipaje.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Crucero WHERE ID = {id}";

                    ConexionSQLEquipaje.comando = new SqlCommand();

                    ConexionSQLEquipaje.comando.CommandType = CommandType.Text;
                    ConexionSQLEquipaje.comando.CommandText = cadena;
                    ConexionSQLEquipaje.comando.Connection = ConexionSQLEquipaje.conexion;

                    ConexionSQLEquipaje.conexion.Open();

                    ConexionSQLEquipaje.lector = ConexionSQLEquipaje.comando.ExecuteReader();

                    while(ConexionSQLEquipaje.lector.Read())
                    {
                        retorno = new Equipaje
                            (
                                (int)ConexionSQLEquipaje.lector["ID"],
                                (int)ConexionSQLEquipaje.lector["Bolsos"],
                                (int)ConexionSQLEquipaje.lector["Maletas"],
                                (double)ConexionSQLEquipaje.lector["PesoTotalMaletas"]
                            );
                    }
                    ConexionSQLEquipaje.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLEquipaje.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLEquipaje.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        #endregion

    }
}
