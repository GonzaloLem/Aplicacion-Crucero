using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Viajes;
using Entidades.Listas;

namespace Entidades.BaseDeDatos
{
    public static class ConexionSQLViajes
    {

        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        private static SqlDataAdapter adaptador;

        static ConexionSQLViajes()
        {
            ConexionSQLViajes.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            ConexionSQLViajes.comando = new SqlCommand();
            ConexionSQLViajes.adaptador = new SqlDataAdapter();
            ConexionSQLViajes.comando.CommandType = CommandType.Text;
            ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

        }

        #region Probar conexion
        private static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                ConexionSQLViajes.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (ConexionSQLViajes.conexion.State == ConnectionState.Open)
                {
                    ConexionSQLViajes.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public static void Insertar(Viaje viaje)
        {
            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Viaje (CiudadDePartida, Destino, FechaDeInicio, ID_Crucero, CamarotesPremium, CamarotesTurista, CostoPremium, CostoTurista, DuracionDelViaje) VALUES";
                    cadena +=
                        "("
                            + ((int)viaje.Partida) + ","
                            + viaje.Destino + ","
                            + "'" + viaje.Inicio.ToString() + "',"
                            + viaje.Crucero.ID + ","
                            + viaje.CamarotesPremium + ","
                            + viaje.CamarotesTurista + ","
                            + viaje.CostoPremium + ","
                            + viaje.CostoTurista + ","
                            + viaje.Duracion
                        + ")";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLViajes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLViajes.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Obtener

        public static AlmecenamientoViajes<Viaje> Obtener()
        {
            AlmecenamientoViajes<Viaje> lista = new AlmecenamientoViajes<Viaje>(100000);

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Viaje";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.lector = ConexionSQLViajes.comando.ExecuteReader();

                    while (ConexionSQLViajes.lector.Read())
                    {
                        lista += new Viaje
                            (
                                (int)ConexionSQLViajes.lector["ID"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["CiudadDePartida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["FechaDeInicio"].ToString()),
                                ConexionSQLCrucero.Obtener((int)ConexionSQLViajes.lector["ID_Crucero"]),
                                (int)ConexionSQLViajes.lector["CamarotesPremium"],
                                (int)ConexionSQLViajes.lector["CamarotesTurista"],
                                (double)ConexionSQLViajes.lector["CostoPremium"],
                                (double)ConexionSQLViajes.lector["CostoTurista"],
                                (int)ConexionSQLViajes.lector["DuracionDelViaje"]
                            );
                    }
                    ConexionSQLViajes.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLViajes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLViajes.conexion.Close();
                    }
                }
            }

            return lista;
        }

        public static Viaje Obtener(int id)
        {
            Viaje retorno = null;

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Viaje WHERE ID = {id}";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.lector = ConexionSQLViajes.comando.ExecuteReader();

                    while (ConexionSQLViajes.lector.Read())
                    {
                        retorno = new Viaje
                            (
                                (int)ConexionSQLViajes.lector["ID"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["CiudadDePartida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["FechaDeInicio"].ToString()),
                                ConexionSQLCrucero.Obtener((int)ConexionSQLViajes.lector["ID_Crucero"]),
                                (int)ConexionSQLViajes.lector["CamarotesPremium"],
                                (int)ConexionSQLViajes.lector["CamarotesTurista"],
                                (double)ConexionSQLViajes.lector["CostoPremium"],
                                (double)ConexionSQLViajes.lector["CostoTurista"],
                                (int)ConexionSQLViajes.lector["DuracionDelViaje"]
                            );
                    }
                    ConexionSQLViajes.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLViajes.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLViajes.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        #endregion

    }
}
