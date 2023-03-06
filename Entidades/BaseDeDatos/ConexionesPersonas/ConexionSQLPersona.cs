using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Listas;
using Entidades.Personas;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Extensiones;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Entidades.BaseDeDatos
{
    public class ConexionSQLPersona : ConexionSQL
    {       
        public ConexionSQLPersona() : base() { }
       
        #region Insertar

        public void Insertar(Persona persona)
        {
            if(this.ProbarConexion())
            {
                try
                {
                        string cadena = "INSERT INTO Persona (Nombre, Apellido, Edad, DNI, Celular, Nacionalidad) VALUES";
                        cadena +=
                            "("
                            + "'" + persona.Nombre + "',"
                            + "'" + persona.Apellido + "',"
                            + persona.Edad + ","
                            + persona.DNI + ","
                            + persona.Celular + ","
                            + ((int)persona.Nacionalidad) 
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

        #region Obtener

        public int Obtener_ID(int DNI)
        {
            int retorno = -1;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona WHERE DNI = {DNI}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = (int)this.lector["id_persona"];
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

        public Persona Obtener_Persona(int id)//Comprobado!!!!
        {
            Persona retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM  Persona LEFT JOIN Pasajeros ON Persona.id_persona = Pasajeros.id_pasajero LEFT JOIN Equipajes ON Equipajes.id_equipaje = Pasajeros.id_pasajero LEFT JOIN Empleados ON Persona.id_persona = Empleados.id_empleado LEFT JOIN Capitanes ON Persona.id_persona = Capitanes.id_capitan WHERE id_pasajero = {id} OR id_empleado = {id} OR id_capitan = {id}";

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
                            retorno = new Pasajero
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
                        else if (this.lector["id_capitan"].ToString() != "")
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

        public Almacenamiento<Persona> Obtener_Lista()
        {
            Almacenamiento<Persona> retorno = new Almacenamiento<Persona>(Persona.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM  Persona LEFT JOIN Pasajeros ON Persona.id_persona = Pasajeros.id_pasajero LEFT JOIN Equipajes ON Equipajes.id_equipaje = Pasajeros.id_pasajero LEFT JOIN Empleados ON Persona.id_persona = Empleados.id_empleado LEFT JOIN Capitanes ON Persona.id_persona = Capitanes.id_capitan";

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
                                new Equipaje((int)this.lector["id_equipaje"], (int)this.lector["Bolsos"], (int)this.lector["Maletas"], (double)this.lector["Peso_maletas"]),
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

        #region Modificar
        public void Modificar(Persona persona)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                    ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                    ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();

                    if (conexionPasajeros.Obtener(persona.ID) is not null)
                    {
                        ConexionSQLEquipaje conexionEquipaje = new ConexionSQLEquipaje();
                        conexionEquipaje.Modificar((Pasajero)persona);
                        conexionPasajeros.Modificar((Pasajero)persona);
                    }
                    else if (conexionEmpleado.Obtener(persona.ID) is not null)
                    {
                        conexionEmpleado.Modificar((Empleado)persona);
                    }
                    else if (conexionCapitan.Obtener(persona.ID) is not null)
                    {
                        conexionCapitan.Modificar((Capitan)persona);
                    }

                    string cadena = $"UPDATE Persona set " +
                        $"Nombre = '{persona.Nombre}', " +
                        $"Apellido = '{persona.Apellido}', " +
                        $"Edad = {persona.Edad}, " +
                        $"DNI = {persona.DNI}, " +
                        $"Celular = {persona.Celular}, " +
                        $"Nacionalidad = {(int)persona.Nacionalidad} " +
                        $"WHERE id_persona = {persona.ID}";

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

        public virtual void Eliminar(int id)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                    ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                    ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();
                    ConexionSQLTripulantes conexionTripulantes = new ConexionSQLTripulantes();

                        if (conexionPasajeros.Obtener(id) is not null)
                        {
                            ConexionSQLEquipaje conexionEquipaje = new ConexionSQLEquipaje();
                                conexionEquipaje.Eliminar(id);
                                conexionPasajeros.Eliminar(id);
                        }
                        else if (conexionEmpleado.Obtener(id) is not null)
                        {
                            conexionEmpleado.Eliminar(id);
                        }
                        else if (conexionCapitan.Obtener(id) is not null)
                        {
                            conexionCapitan.Eliminar(id);
                        }

                    conexionTripulantes.Eliminar(id);

                    string cadena = $"DELETE FROM Persona WHERE id_persona = {id}";

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

    }
}
