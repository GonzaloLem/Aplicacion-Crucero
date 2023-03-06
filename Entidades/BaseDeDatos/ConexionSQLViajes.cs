using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Viajes;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Barcos;

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

        #region Modificar

        public static void Modificar(Viaje viaje)
        {
            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    string cadena = $"update Viaje set " +
                        $"CiudadDePartida = {((int)viaje.Partida)}, " +
                        $"Destino = {((uint)viaje.Destino)}, " +
                        $"FechaDeInicio = '{viaje.Inicio.ToString()}', " +
                        $"ID_Crucero = {viaje.Crucero.ID}, " +
                        $"CamarotesPremium = {viaje.CamarotesPremium}, " +
                        $"CamarotesTurista = {viaje.CamarotesTurista}, " +
                        $"CostoPremium = {viaje.CostoPremium}, " +
                        $"CostoTurista = {viaje.CostoTurista}, " +
                        $"DuracionDelViaje = {viaje.Duracion} " +
                        $"WHERE ID = {viaje.ID}";

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

        #region Eliminar

        public static void Eliminar(Viaje viaje)
        {
            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    //ConexionSQLTripulantes.Eliminar(viaje);

                    string cadena = $"delete FROM Viaje WHERE ID = {viaje.ID} ";

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

        public static Almacenamiento<Viaje> Obtener()
        {
           Almacenamiento<Viaje> lista = new Almacenamiento<Viaje>(Viaje.Comparar, new Viaje().Equals);

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero(); 

                    string cadena = $"SELECT * From Viajes";

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
                                (int)ConexionSQLViajes.lector["id_viaje"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["Ciudad_partida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)ConexionSQLViajes.lector["id_tipo_crucero"]),
                                (int)ConexionSQLViajes.lector["Camarotes_premium"],
                                (int)ConexionSQLViajes.lector["Camarotes_turista"],
                                (double)ConexionSQLViajes.lector["Costo_premium"],
                                (double)ConexionSQLViajes.lector["Costo_turista"],
                                (int)ConexionSQLViajes.lector["Duracion_viaje"]
                            );
                    }
                    ConexionSQLViajes.lector.Close();

                }
                catch (Exception es)
                {
                    Console.WriteLine(es.ToString());
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

        public static Almacenamiento<Viaje> Obtener(Disponibilidad disponibilidad)
        {
            Almacenamiento<Viaje> lista = new Almacenamiento<Viaje>(Viaje.Comparar);

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {

                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * From Viajes";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.lector = ConexionSQLViajes.comando.ExecuteReader();

                    while (ConexionSQLViajes.lector.Read())
                    {
                        Viaje viaje = new Viaje
                            (
                                (int)ConexionSQLViajes.lector["id_viaje"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["Ciudad_partida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)ConexionSQLViajes.lector["id_tipo_crucero"]),
                                (int)ConexionSQLViajes.lector["Camarotes_premium"],
                                (int)ConexionSQLViajes.lector["Camarotes_turista"],
                                (double)ConexionSQLViajes.lector["Costo_premium"],
                                (double)ConexionSQLViajes.lector["Costo_turista"],
                                (int)ConexionSQLViajes.lector["Duracion_viaje"]
                            );

                        if (viaje.Estado == disponibilidad)
                        {
                            lista += viaje;
                        }

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

        public static Viaje Obtener_Viaje(int id)
        {
            Viaje retorno = null;

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * FROM Viajes WHERE id_viaje = {id}";

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
                                (int)ConexionSQLViajes.lector["id_viaje"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["Ciudad_partida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)ConexionSQLViajes.lector["id_tipo_crucero"]),
                                (int)ConexionSQLViajes.lector["Camarotes_premium"],
                                (int)ConexionSQLViajes.lector["Camarotes_turista"],
                                (double)ConexionSQLViajes.lector["Costo_premium"],
                                (double)ConexionSQLViajes.lector["Costo_turista"],
                                (int)ConexionSQLViajes.lector["Duracion_viaje"]
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

        public static Almacenamiento<Destino> Destinos()
        {
            Almacenamiento<Destino> lista = new Almacenamiento<Destino>(10000);

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Viaje";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.lector = ConexionSQLViajes.comando.ExecuteReader();

                    while (ConexionSQLViajes.lector.Read())
                    {
                        lista += Destino.Parse((int)ConexionSQLViajes.lector["Destino"]);
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

        public static bool Disponible(Crucero crucero)
        {
            bool retorno = true;

            if (ConexionSQLViajes.ProbarConexion())
            {
                try
                {
                    
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * From Viajes WHERE id_tipo_crucero = {crucero.ID}";

                    ConexionSQLViajes.comando = new SqlCommand();

                    ConexionSQLViajes.comando.CommandType = CommandType.Text;
                    ConexionSQLViajes.comando.CommandText = cadena;
                    ConexionSQLViajes.comando.Connection = ConexionSQLViajes.conexion;

                    ConexionSQLViajes.conexion.Open();

                    ConexionSQLViajes.lector = ConexionSQLViajes.comando.ExecuteReader();

                    while (ConexionSQLViajes.lector.Read())
                    {
                        Viaje viaje = new Viaje
                            (
                                (int)ConexionSQLViajes.lector["id_viaje"],
                                (CiudadesDePartida)ConexionSQLViajes.lector["Ciudad_partida"],
                                Destino.Parse((int)ConexionSQLViajes.lector["Destino"]),
                                DateTime.Parse(ConexionSQLViajes.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)ConexionSQLViajes.lector["id_tipo_crucero"]),
                                (int)ConexionSQLViajes.lector["Camarotes_premium"],
                                (int)ConexionSQLViajes.lector["Camarotes_turista"],
                                (double)ConexionSQLViajes.lector["Costo_premium"],
                                (double)ConexionSQLViajes.lector["Costo_turista"],
                                (int)ConexionSQLViajes.lector["Duracion_viaje"]
                            );

                                if(viaje.Estado != Disponibilidad.Disponible && viaje.Estado != Disponibilidad.Terminado)
                                {
                                    retorno = false;
                                    break;
                                }
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
