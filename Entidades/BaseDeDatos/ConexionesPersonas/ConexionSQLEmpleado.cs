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
    public class ConexionSQLEmpleado : ConexionSQLPersona
    {


        public ConexionSQLEmpleado() : base() { }

        #region Insertar

        public void Insertar(Empleado empleado)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    this.Insertar((Persona)empleado);

                    string cadena = "INSERT INTO Empleados (id_empleado, Puesto, Fecha_ingreso) VALUES";
                    cadena +=
                        "("
                        + this.Obtener_ID(empleado.DNI) + ","
                        + ((int)empleado.Puesto) + ","
                        + "'" + empleado.Fecha + "'"
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
        public void Modificar(Empleado empleado)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"UPDATE Empleado set " +
                        $"Puesto = {((int)empleado.Puesto)}, " +
                        $"FechaDeIngreso = '{empleado.Fecha}' " +
                        $"WHERE id_empleado = {empleado.ID}";

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
        public override void Eliminar(int id)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"DELETE FROM Empleados WHERE id_empleado = {id}";

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

        #region Obtener

        public Empleado Obtener(int id)
        {
            Empleado retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona INNER JOIN Empleados ON Empleados.id_empleado = Persona.id_persona WHERE id_persona = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = new Empleado
                            (
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                (PuestosDeTrabajo)this.lector["Puesto"],
                                (DateTime)this.lector["Fecha_ingreso"]
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

        public Almacenamiento<Persona> Lista()
        {
            Almacenamiento<Persona> retorno = new Almacenamiento<Persona>(Persona.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona INNER JOIN Empleados ON Persona.id_persona = Empleados.id_pasajero";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno += new Empleado
                            (
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                (PuestosDeTrabajo)this.lector["Puesto"],
                                (DateTime)this.lector["Fecha_ingreso"]
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
