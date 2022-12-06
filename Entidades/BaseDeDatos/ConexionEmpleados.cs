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
    public class ConexionEmpleados : ConexionSQLServer
    {

        public ConexionEmpleados() : base() { }

        #region Insertar

        public void Insertar(Empleado empleado)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadenaComando = "INSERT INTO Empleado (ID, Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, Puesto, FechaDeIngreso) VALUES";
                    cadenaComando += "(" 
                        + Operacion.InsertarID() + ",'"
                        + empleado.Nombre + "','"
                        + empleado.Apellido + "',"
                        + empleado.Edad + ","
                        + empleado.DNI + ","
                        + ((int)empleado.Nacionalidad) + ","
                        + empleado.Celular + ","
                        + (int)empleado.Puesto + ",'"
                        + empleado.Comienzo+ "'"
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
                this.comando.CommandText = "SELECT MAX(ID) as 'id' FROM Empleado";
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
            AlmacenamientoPersonas<Persona> lista = new AlmacenamientoPersonas<Persona>(100000);

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Empleado";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Empleado empleado = new Empleado
                    (
                        (int)this.lector["ID"],
                        this.lector["Nombre"].ToString(),
                        this.lector["Apellido"].ToString(),
                        (int)this.lector["Edad"],
                        (int)this.lector["DNI"],
                        (Nacionalidades)this.lector["Nacionalidad"],
                        (double)this.lector["Celular"],
                        (PuestosDeTrabajo)this.lector["Puesto"],
                        (DateTime)this.lector["FechaIngreso"]
                    );

                    lista += empleado;
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
