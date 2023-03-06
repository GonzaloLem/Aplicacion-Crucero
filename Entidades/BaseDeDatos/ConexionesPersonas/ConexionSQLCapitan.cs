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
    public class ConexionSQLCapitan : ConexionSQLPersona
    {


        public ConexionSQLCapitan() : base() { }

        #region Insertar

        public void Insertar(Capitan capitan)
        {
            if (this.ProbarConexion())
            {
                try
                {

                    this.Insertar((Persona)capitan);

                    string cadena = "INSERT INTO Capitanes (id_capitan, Hora_Viajes, Viajes_realizados) VALUES";
                    cadena +=
                        "("
                           + this.Obtener_ID(capitan.DNI) + ","
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

        #region Modificar

        public void Modificar(Capitan capitan)
        {
            if (this.ProbarConexion())
            {
                try
                {

                    string cadena = $"UPDATE Capitanes set " +
                        $"Hora_Viajes = {capitan.Horas}, " +
                        $"Viajes_realizados = {capitan.Viajes} " +
                        $"WHERE id_capitan = {capitan.ID}";

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
                    string cadena = $"DELETE FROM Capitanes WHERE id_capitan = {id}";

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

        public Capitan Obtener(int id)
        {
            Capitan retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona INNER JOIN Capitanes ON Capitanes.id_capitan = Persona.id_persona WHERE id_persona = {id}";

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
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                (int)this.lector["Hora_Viajes"],
                                (int)this.lector["Viajes_realizados"]
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
                    string cadena = $"SELECT * FROM Persona INNER JOIN Capitanes ON Persona.id_persona = Capitanes.id_capitan";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno += new Capitan
                            (
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                (int)this.lector["Hora_Viaje"],
                                (int)this.lector["Viajes_realizados"]
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
