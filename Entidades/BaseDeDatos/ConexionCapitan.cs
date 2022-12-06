using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Personas;
using Entidades.Operaciones;

namespace Entidades.BaseDeDatos
{
    public class ConexionCapitan : ConexionSQLServer
    {

        public ConexionCapitan() : base() { }

        #region Insertar

        public void Insertar(Capitan capitan)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadenaComando = "INSERT INTO Capitan (ID, Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, HorasDeViaje, ViajesRealizadosConLaEmpresa) VALUES";
                    cadenaComando += "(" 
                        + Operacion.InsertarID() + ",'"
                        + capitan.Nombre + "','"
                        + capitan.Apellido + "',"
                        + capitan.Edad + ","
                        + capitan.DNI + ","
                        + ((int)capitan.Nacionalidad) + ","
                        + capitan.Celular + ","
                        + capitan.Horas + ","
                        + capitan.Viajes
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

        public override int ObtenerID()
        {
            int retorno = -1;

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT MAX(ID) as 'id' FROM Capitan";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (this.lector.Read())
                {
                    if (this.lector["id"].ToString() != "")
                    {
                        retorno = (int)this.lector["id"];
                    }

                }
                this.lector.Close();

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
            return retorno;
        }

        public AlmacenamientoPersonas<Persona> Obtener()
        {
            AlmacenamientoPersonas<Persona> lista = new AlmacenamientoPersonas<Persona>(1000);

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Capitan";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Capitan capitan = new Capitan
                    (
                        (int)this.lector["ID"],
                        this.lector["Nombre"].ToString(),
                        this.lector["Apellido"].ToString(),
                        (int)this.lector["Edad"],
                        (int)this.lector["DNI"],
                        (Nacionalidades)this.lector["Nacionalidad"],
                        (double)this.lector["Celular"],
                        (int)this.lector["HorasDeViaje"],
                        (int)this.lector["ViajesRealizadosConLaEmpresa"]
                    );

                    lista += capitan;
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

            return lista;
        }

        #endregion

    }
}
