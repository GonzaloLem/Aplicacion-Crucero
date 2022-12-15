using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Barcos;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;

namespace Entidades.BaseDeDatos
{
    public static class ConexionSQLCrucero
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        private static SqlDataAdapter adaptador;

        static ConexionSQLCrucero()
        {
            ConexionSQLCrucero.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            ConexionSQLCrucero.comando = new SqlCommand();
            ConexionSQLCrucero.adaptador = new SqlDataAdapter();
            ConexionSQLCrucero.comando.CommandType = CommandType.Text;
            ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

        }

        #region Probar conexion
        private static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                ConexionSQLCrucero.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                {
                    ConexionSQLCrucero.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public static void Insertar(Crucero crucero)
        {
            if (ConexionSQLCrucero.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Crucero (Matricula, Nombre, Camarotes, Salones, Casinos, Piscinas, Gimnacios, CapacidadBodega, PesoTotalDeLaBodega, ListaTripulantes) VALUES";
                    cadena +=
                        "("
                            + "'" + crucero.Matricula + "',"
                            + "'" + crucero.Nombre + "',"
                            + crucero.Camarotes + ","
                            + crucero.Salones + ","
                            + crucero.Casinos + ","
                            + crucero.Piscinas + ","
                            + crucero.Gimnacios + ","
                            + crucero.Capacidad + ","
                            + crucero.Peso + ""
                        + ")";

                    ConexionSQLCrucero.comando = new SqlCommand();

                    ConexionSQLCrucero.comando.CommandType = CommandType.Text;
                    ConexionSQLCrucero.comando.CommandText = cadena;
                    ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

                    ConexionSQLCrucero.conexion.Open();

                    ConexionSQLCrucero.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLCrucero.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Modificar

        public static void Modificar(Crucero crucero)
        {
            if (ConexionSQLCrucero.ProbarConexion())
            {
                try
                {
                    string cadena = $"update Crucero set " +
                        $"Matricula = '{crucero.Matricula}', " +
                        $"Nombre = '{crucero.Nombre}', " +
                        $"Camarotes = {crucero.Camarotes}, " +
                        $"Salones = {crucero.Salones}, " +
                        $"Casinos = {crucero.Salones}, " +
                        $"Piscinas = {crucero.Salones}, " +
                        $"Gimnacios = {crucero.Gimnacios}, " +
                        $"CapacidadBodega = {crucero.Capacidad}, " +
                        $"PesoTotalDeLaBodega = {crucero.Peso} " +
                        $"WHERE ID = {crucero.ID}";

                    ConexionSQLCrucero.comando = new SqlCommand();

                    ConexionSQLCrucero.comando.CommandType = CommandType.Text;
                    ConexionSQLCrucero.comando.CommandText = cadena;
                    ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

                    ConexionSQLCrucero.conexion.Open();

                    ConexionSQLCrucero.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLCrucero.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Eliminar

        public static void Elminar(Crucero crucero)
        {
            if (ConexionSQLCrucero.ProbarConexion())
            {
                try
                {
                    string cadena = $"delete FROM Crucero WHERE ID = {crucero.ID}";

                    ConexionSQLCrucero.comando = new SqlCommand();

                    ConexionSQLCrucero.comando.CommandType = CommandType.Text;
                    ConexionSQLCrucero.comando.CommandText = cadena;
                    ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

                    ConexionSQLCrucero.conexion.Open();

                    ConexionSQLCrucero.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLCrucero.conexion.Close();
                    }
                }
            }
        }

        #endregion

        #region Obtener

        public static Embarcadero<Crucero> Obtener()
        {
            Embarcadero<Crucero> lista = new Embarcadero<Crucero>(100000);

            if (ConexionSQLCrucero.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Crucero";

                    ConexionSQLCrucero.comando = new SqlCommand();

                    ConexionSQLCrucero.comando.CommandType = CommandType.Text;
                    ConexionSQLCrucero.comando.CommandText = cadena;
                    ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

                    ConexionSQLCrucero.conexion.Open();

                    ConexionSQLCrucero.lector = ConexionSQLCrucero.comando.ExecuteReader();

                    while (ConexionSQLCrucero.lector.Read())
                    {
                        lista += new Crucero
                            (
                                (int)ConexionSQLCrucero.lector["ID"],
                                ConexionSQLCrucero.lector["Matricula"].ToString(),
                                ConexionSQLCrucero.lector["Nombre"].ToString(),
                                (int)ConexionSQLCrucero.lector["Camarotes"],
                                (int)ConexionSQLCrucero.lector["Salones"],
                                (int)ConexionSQLCrucero.lector["Casinos"],
                                (int)ConexionSQLCrucero.lector["Piscinas"],
                                (int)ConexionSQLCrucero.lector["Gimnacios"],
                                (double)ConexionSQLCrucero.lector["CapacidadBodega"],
                                (double)ConexionSQLCrucero.lector["PesoTotalDeLaBodega"],
                                ConexionSQLTripulantes.Obtener((int)ConexionSQLCrucero.lector["ID"])
                            );
                    }
                    ConexionSQLCrucero.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLCrucero.conexion.Close();
                    }
                }
            }

            return lista;
        }

        public static Crucero Obtener(int id)
        {
            Crucero retorno = null;

            if (ConexionSQLCrucero.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Crucero WHERE ID = {id}";

                    ConexionSQLCrucero.comando = new SqlCommand();
                    ConexionSQLCrucero.comando.CommandType = CommandType.Text;
                    ConexionSQLCrucero.comando.CommandText = cadena;
                    ConexionSQLCrucero.comando.Connection = ConexionSQLCrucero.conexion;

                    ConexionSQLCrucero.conexion.Open();

                    ConexionSQLCrucero.lector = ConexionSQLCrucero.comando.ExecuteReader();

                    while (ConexionSQLCrucero.lector.Read())
                    {
                        retorno = new Crucero
                            (
                                (int)ConexionSQLCrucero.lector["ID"],
                                ConexionSQLCrucero.lector["Matricula"].ToString(),
                                ConexionSQLCrucero.lector["Nombre"].ToString(),
                                (int)ConexionSQLCrucero.lector["Camarotes"],
                                (int)ConexionSQLCrucero.lector["Salones"],
                                (int)ConexionSQLCrucero.lector["Casinos"],
                                (int)ConexionSQLCrucero.lector["Piscinas"],
                                (int)ConexionSQLCrucero.lector["Gimnacios"],
                                (double)ConexionSQLCrucero.lector["CapacidadBodega"],
                                (double)ConexionSQLCrucero.lector["PesoTotalDeLaBodega"],
                                new AlmacenamientoPersonas<Personas.Persona>(1)
                            );
                    }
                    ConexionSQLCrucero.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLCrucero.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLCrucero.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        #endregion

    }

}

