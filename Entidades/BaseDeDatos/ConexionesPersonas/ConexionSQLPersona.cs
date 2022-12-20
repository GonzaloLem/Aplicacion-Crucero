using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Listas;
using Entidades.Personas;
using Entidades.Interfaces;
using Entidades.BaseDeDatos.ConexionesPersonas;

namespace Entidades.BaseDeDatos
{
    public static class ConexionSQLPersona 
    {
        private static  SqlConnection conexion;
        private static SqlCommand comando;
        private static SqlDataReader lector;
        private static SqlDataAdapter adaptador;

        static ConexionSQLPersona()
        {
            ConexionSQLPersona.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            ConexionSQLPersona.comando = new SqlCommand();
            ConexionSQLPersona.adaptador = new SqlDataAdapter();
            ConexionSQLPersona.comando.CommandType = CommandType.Text;
            ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

        }

        #region Probar conexion
        private static bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                ConexionSQLPersona.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                {
                    ConexionSQLPersona.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Insertar

        public static void Insertar(Persona persona)
        {
            if(ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = null;

                    if(persona is Pasajero)
                    {
                        ConexionSQLPasajeros conexionPasajero = new ConexionSQLPasajeros();

                        conexionPasajero.Insertar((Pasajero)persona);

                        cadena = "INSERT INTO Persona (Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, ID_Pasajero) VALUES";
                        cadena +=
                            "("
                            + "'" + persona.Nombre + "',"
                            + "'" + persona.Apellido + "',"
                            + persona.Edad + ","
                            + persona.DNI + ","
                            + ((int)persona.Nacionalidad) + ","
                            + persona.Celular + ","
                            + conexionPasajero.Obtener()
                            + ")";
                    }
                    else if(persona is Empleado)
                    {
                        ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();

                        conexionEmpleado.Insertar((Empleado)persona);

                        cadena = "INSERT INTO Persona (Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, ID_Empleado) VALUES";
                        cadena +=
                            "("
                            + "'" + persona.Nombre + "',"
                            + "'" + persona.Apellido + "',"
                            + persona.Edad + ","
                            + persona.DNI + ","
                            + ((int)persona.Nacionalidad) + ","
                            + persona.Celular + ","
                            + conexionEmpleado.Obtener()
                            + ")";
                    }
                    else if (persona is Capitan)
                    {
                        ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();

                        conexionCapitan.Insertar((Capitan)persona);

                        cadena = "INSERT INTO Persona (Nombre, Apellido, Edad, DNI, Nacionalidad, Celular, ID_Capitan) VALUES";
                        cadena +=
                            "("
                            + "'" + persona.Nombre + "',"
                            + "'" + persona.Apellido + "',"
                            + persona.Edad + ","
                            + persona.DNI + ","
                            + ((int)persona.Nacionalidad) + ","
                            + persona.Celular + ","
                            + conexionCapitan.Obtener()
                            + ")";
                    }

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }
        }



        #endregion

        #region Modificar
        public static void Modificar(Persona persona)
        {
            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"update Persona set " +
                    $"Nombre = '{persona.Nombre}', " +
                    $"Apellido = '{persona.Apellido}', " +
                    $"Edad = {persona.Edad}, " +
                    $"DNI = {persona.DNI}, " +
                    $"Nacionalidad = {((int)persona.Nacionalidad)}, " +
                    $"Celular = {persona.Celular}" +
                    $"WHERE ID = {persona.ID}"; 

                    if (persona is Pasajero)
                    {
                        ConexionSQLPasajeros conexionPasajero = new ConexionSQLPasajeros();

                        conexionPasajero.Modificar(ConexionSQLPersona.Obtener(persona), (Pasajero)persona);
                    }
                    else if (persona is Empleado)
                    {
                        ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();

                        conexionEmpleado.Modificar(ConexionSQLPersona.Obtener(persona), (Empleado)persona);
                    }
                    else if (persona is Capitan)
                    {
                        ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();

                        conexionCapitan.Modificar(ConexionSQLPersona.Obtener(persona), (Capitan)persona);

                    }

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }
        }
        #endregion

        #region Eliminar
        public static void Eliminar(Persona persona)
        {
            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    int id = ConexionSQLPersona.Obtener(persona);
                    string cadena = $"delete FROM Persona WHERE ID = {persona.ID} ";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.comando.ExecuteNonQuery();

                    if (persona is Pasajero)
                    {
                        ConexionSQLPasajeros conexionPasajero = new ConexionSQLPasajeros();

                        conexionPasajero.Eliminar(id, ((Pasajero)persona).Equipaje.ID);
                    }
                    else if (persona is Empleado)
                    {
                        ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();

                        conexionEmpleado.Eliminar(id);
                    }
                    else if (persona is Capitan)
                    {
                        ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();

                        conexionCapitan.Eliminar(id);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }
        }
        #endregion

        #region Obtener

        public static Almacenamiento<Persona> Obtener()
        {
            Almacenamiento<Persona> lista = new Almacenamiento<Persona>(Persona.Comparar);

            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.lector = ConexionSQLPersona.comando.ExecuteReader();

                    while (ConexionSQLPersona.lector.Read())
                    {
                        if (ConexionSQLPersona.lector["ID_Pasajero"].ToString() != "")
                        {
                            ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                            Pasajero pasajero = conexionPasajeros.Obtener((int)ConexionSQLPersona.lector["ID_Pasajero"]);

                            lista += new Pasajero
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    pasajero.Correo,
                                    pasajero.Clase,
                                    pasajero.Equipaje,
                                    pasajero.Casino,
                                    pasajero.Gimnacio,
                                    pasajero.Piscina
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Empleado"].ToString() != "")
                        {
                            ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                            Empleado empleado = conexionEmpleado.Obtener((int)ConexionSQLPersona.lector["ID_Empleado"]);

                            lista += new Empleado
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    empleado.Puesto,
                                    empleado.Fecha
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Capitan"].ToString() != "")
                        {
                            ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();
                            Capitan capitan = conexionCapitan.Obtener((int)ConexionSQLPersona.lector["ID_Capitan"]);

                            lista += new Capitan
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    capitan.Horas,
                                    capitan.Viajes
                                );
                        }

                    }
                    ConexionSQLPersona.lector.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }

            return lista;
        }

        /*
        public static AlmacenamientoPersonas<Persona> Obtener()
        {
            AlmacenamientoPersonas<Persona> lista = new AlmacenamientoPersonas<Persona>(1000000);

            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.lector = ConexionSQLPersona.comando.ExecuteReader();

                    while (ConexionSQLPersona.lector.Read())
                    {
                        if (ConexionSQLPersona.lector["ID_Pasajero"].ToString() != "")
                        {
                            ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                            Pasajero pasajero = conexionPasajeros.Obtener((int)ConexionSQLPersona.lector["ID_Pasajero"]);

                            lista += new Pasajero
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    pasajero.Correo,
                                    pasajero.Clase,
                                    pasajero.Equipaje,
                                    pasajero.Casino,
                                    pasajero.Gimnacio,
                                    pasajero.Piscina
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Empleado"].ToString() != "")
                        {
                            ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                            Empleado empleado = conexionEmpleado.Obtener((int)ConexionSQLPersona.lector["ID_Empleado"]);

                            lista += new Empleado
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    empleado.Puesto,
                                    empleado.Fecha
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Capitan"].ToString() != "")
                        {
                            ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();
                            Capitan capitan = conexionCapitan.Obtener((int)ConexionSQLPersona.lector["ID_Capitan"]);

                            lista += new Capitan
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    capitan.Horas,
                                    capitan.Viajes
                                );
                        }

                    }
                    ConexionSQLPersona.lector.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }

            return lista;
        }
        */
        public static Almacenamiento<Persona> Obtener(Roles tipo)
        {
            Func<Almacenamiento<Persona>, Persona, int> comparador = Persona.Comparar;

            Almacenamiento<Persona> lista = new Almacenamiento<Persona>(comparador);

            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.lector = ConexionSQLPersona.comando.ExecuteReader();

                    while (ConexionSQLPersona.lector.Read())
                    {
                        if (Roles.Cliente == tipo && ConexionSQLPersona.lector["ID_Pasajero"].ToString() != "")
                        {
                            ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                            Pasajero pasajero = conexionPasajeros.Obtener((int)ConexionSQLPersona.lector["ID_Pasajero"]);

                            lista += new Pasajero
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    pasajero.Correo,
                                    pasajero.Clase,
                                    pasajero.Equipaje,
                                    pasajero.Casino,
                                    pasajero.Gimnacio,
                                    pasajero.Piscina
                                );
                        }
                        else if (Roles.Empleado == tipo && ConexionSQLPersona.lector["ID_Empleado"].ToString() != "")
                        {
                            ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                            Empleado empleado = conexionEmpleado.Obtener((int)ConexionSQLPersona.lector["ID_Empleado"]);

                            lista += new Empleado
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    empleado.Puesto,
                                    empleado.Fecha
                                );
                        }
                        else if (Roles.Capitan == tipo && ConexionSQLPersona.lector["ID_Capitan"].ToString() != "")
                        {
                            ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();
                            Capitan capitan = conexionCapitan.Obtener((int)ConexionSQLPersona.lector["ID_Capitan"]);

                            lista += new Capitan
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    capitan.Horas,
                                    capitan.Viajes
                                );
                        }

                    }
                    ConexionSQLPersona.lector.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }

            return lista;
        }

        public static Persona Obtener(int id)
        {
            Persona retorno = null;

            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona WHERE ID = {id}";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.lector = ConexionSQLPersona.comando.ExecuteReader();

                    while (ConexionSQLPersona.lector.Read())
                    {
                        if (ConexionSQLPersona.lector["ID_Pasajero"].ToString() != "")
                        {
                            ConexionSQLPasajeros conexionPasajeros = new ConexionSQLPasajeros();
                            Pasajero pasajero = conexionPasajeros.Obtener((int)ConexionSQLPersona.lector["ID_Pasajero"]);

                            retorno = new Pasajero
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    pasajero.Correo,
                                    pasajero.Clase,
                                    pasajero.Equipaje,
                                    pasajero.Casino,
                                    pasajero.Gimnacio,
                                    pasajero.Piscina
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Empleado"].ToString() != "")
                        {
                            ConexionSQLEmpleado conexionEmpleado = new ConexionSQLEmpleado();
                            Empleado empleado = conexionEmpleado.Obtener((int)ConexionSQLPersona.lector["ID_Empleado"]);

                            retorno = new Empleado
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    empleado.Puesto,
                                    empleado.Fecha
                                );
                        }
                        else if (ConexionSQLPersona.lector["ID_Capitan"].ToString() != "")
                        {
                            ConexionSQLCapitan conexionCapitan = new ConexionSQLCapitan();
                            Capitan capitan = conexionCapitan.Obtener((int)ConexionSQLPersona.lector["ID_Capitan"]);

                            retorno = new Capitan
                                (
                                    (int)ConexionSQLPersona.lector["ID"],
                                    ConexionSQLPersona.lector["Nombre"].ToString(),
                                    ConexionSQLPersona.lector["Apellido"].ToString(),
                                    (int)ConexionSQLPersona.lector["Edad"],
                                    (int)ConexionSQLPersona.lector["DNI"],
                                    (Nacionalidades)ConexionSQLPersona.lector["Nacionalidad"],
                                    (double)ConexionSQLPersona.lector["Celular"],
                                    capitan.Horas,
                                    capitan.Viajes
                                );
                        }
                        

                    }
                    ConexionSQLPersona.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Te retorna el id de la tabla a la cual esta enlazada
        /// </summary>
        public static int Obtener(Persona persona)
        {
            int retorno = -1;

            if (ConexionSQLPersona.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona WHERE ID = {persona.ID}";

                    ConexionSQLPersona.comando = new SqlCommand();

                    ConexionSQLPersona.comando.CommandType = CommandType.Text;
                    ConexionSQLPersona.comando.CommandText = cadena;
                    ConexionSQLPersona.comando.Connection = ConexionSQLPersona.conexion;

                    ConexionSQLPersona.conexion.Open();

                    ConexionSQLPersona.lector = ConexionSQLPersona.comando.ExecuteReader();

                    while (ConexionSQLPersona.lector.Read())
                    {
        
                        if(persona is Pasajero)
                        {
                            retorno = (int)ConexionSQLPersona.lector["ID_Pasajero"];
                        }
                        else if (persona is Empleado)
                        {
                            retorno = (int)ConexionSQLPersona.lector["ID_Empleado"];
                        }
                        else if (persona is Capitan)
                        {
                            retorno = (int)ConexionSQLPersona.lector["ID_Capitan"];
                        }

                    }
                    ConexionSQLPersona.lector.Close();

                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ConexionSQLPersona.conexion.State == ConnectionState.Open)
                    {
                        ConexionSQLPersona.conexion.Close();
                    }
                }
            }

            return retorno;
        }

        #endregion

    }
}
