using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Personas;
using Entidades.Listas;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    class ConexionSQLCapitan
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter adaptador;

        public ConexionSQLCapitan()
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

        public void Insertar(Capitan capitan)
        {
            if (this.ProbarConexion())
            {
                try
                {

                    string cadena = "INSERT INTO Capitan (HorasDeViaje, ViajesRealizadosConLaEmpresa) VALUES";
                    cadena +=
                        "("
                           + capitan.Horas + ","
                           + capitan.Viajes
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

        /// <summary>
        /// Busca la id mas alta de la Tabla Empleados
        /// </summary>
        public int Obtener()
        {
            int retorno = -1;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT MAX(ID) as ID_Maximo FROM Capitan";

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

        public Capitan Obtener(int id)
        {
            Capitan retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Capitan WHERE ID = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = new Capitan
                            (
                                (int)this.lector["HorasDeViaje"],
                                (int)this.lector["ViajesRealizadosConLaEmpresa"]
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

    }
}
