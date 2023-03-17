using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Personas;
using Entidades.Listas;
using Entidades.Barcos;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    public class ConexionSQLTripulantes : ConexionSQL
    {

        public ConexionSQLTripulantes() : base() { }

        #region Insertar

        public void Insertar(Viaje viaje, Persona persona)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Tripulantes (id_persona, id_crucero, id_viaje) VALUES";
                    cadena +=
                        "("
                        + persona.ID + ","
                        + viaje.Crucero.ID + ","
                        + viaje.ID
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

        #region Eliminar

        public void Eliminar(int id)
        {
            if (this.ProbarConexion())
            {
                try
                {

                    string cadena = $"DELETE FROM Tripulantes WHERE id_persona = {id}";

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

        public void Eliminar(Viaje viaje)
        {
            if (this.ProbarConexion())
            {
                try
                {

                    string cadena = $"DELETE FROM Tripulantes WHERE id_viaje = {viaje.ID}";

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

        /// <summary>
        /// Retorna los Pasajeros del viaje que se le pasa como parametro
        /// </summary>
        /// <param name="viaje"></param>
        /// <returns></returns>
        public Almacenamiento<Persona> Lista(Viaje viaje)
        {
            Almacenamiento<Persona> retorno = new Almacenamiento<Persona>(Persona.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM  Persona LEFT JOIN Tripulantes ON Tripulantes.id_persona = Persona.id_persona LEFT JOIN Pasajeros ON Persona.id_persona = Pasajeros.id_pasajero LEFT JOIN Equipajes ON Equipajes.id_equipaje = Pasajeros.id_pasajero LEFT JOIN Empleados ON Persona.id_persona = Empleados.id_empleado LEFT JOIN Capitanes ON Persona.id_persona = Capitanes.id_capitan WHERE Tripulantes.id_viaje = {viaje.ID}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        if (this.lector["id_pasajero"].ToString() != "")
                        {
                            retorno += new Pasajero
                            (
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                this.lector["Correo"].ToString(),
                                (Clases)this.lector["Clase"],
                                new Equipaje((int)this.lector["id_equipaje"], (int)this.lector["Bolsos"], (int)this.lector["Maletas"], (double)this.lector["Peso_Maletas"]),
                                (bool)this.lector["Casino"],
                                (bool)this.lector["Gimnacio"],
                                (bool)this.lector["Piscina"]
                            );
                        }
                        else if (this.lector["id_empleado"].ToString() != "")
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
                        else if (this.lector["id_capitan"].ToString() != "")
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
                                    (int)this.lector["Hora_Viajes"],
                                    (int)this.lector["Viajes_realizados"]
                                );
                        }

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

        /// <summary>
        /// Te Obtiene todos los Pasajeros que van abordo del crucero que se le pasa como parametro
        /// </summary>
        /// <param name="crucero"></param>
        /// <returns></returns>
        public Almacenamiento<Persona> Lista(int idCrucero)
        {
            Almacenamiento<Persona> retorno = new Almacenamiento<Persona>(Persona.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM  Persona INNER JOIN Tripulantes ON Tripulantes.id_crucero = {idCrucero} AND Persona.id_persona = Tripulantes.id_persona INNER JOIN Pasajeros ON Pasajeros.id_pasajero = Persona.id_persona INNER JOIN Equipajes ON Equipajes.id_equipaje = Persona.id_persona";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        if (this.lector["id_pasajero"].ToString() != "")
                        {
                            retorno += new Pasajero
                            (
                                (int)this.lector["id_persona"],
                                this.lector["Nombre"].ToString(),
                                this.lector["Apellido"].ToString(),
                                (int)this.lector["Edad"],
                                (int)this.lector["DNI"],
                                (Nacionalidades)this.lector["Nacionalidad"],
                                (double)this.lector["Celular"],
                                this.lector["Correo"].ToString(),
                                (Clases)this.lector["Clase"],
                                new Equipaje((int)this.lector["id_equipaje"], (int)this.lector["Bolsos"], (int)this.lector["Maletas"], (double)this.lector["Peso_Maletas"]),
                                (bool)this.lector["Casino"],
                                (bool)this.lector["Gimnacio"],
                                (bool)this.lector["Piscina"]
                            );
                        }
                        else if (this.lector["id_empleado"].ToString() != "")
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
                        else if (this.lector["id_capitan"].ToString() != "")
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
                                    (int)this.lector["Hora_Viajes"],
                                    (int)this.lector["Viajes_realizados"]
                                );
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
            }

            return retorno;
        }

        #endregion

        #region Metodos

        public bool Buscar(Persona persona, Crucero crucero)
        { 
            bool retorno = false;

            try
            {
                string cadena = $"SELECT * FROM Tripulantes WHERE Tripulantes.id_persona = {persona.ID}";

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = cadena;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        if (this.lector["id_persona"].ToString() != "")
                        { 
                            retorno = true;
                        }
                    }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
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

        #endregion


    }
}
