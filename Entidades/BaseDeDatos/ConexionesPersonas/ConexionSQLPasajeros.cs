using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Personas;
using Entidades.Extensiones;
using Entidades.Listas;

namespace Entidades.BaseDeDatos.ConexionesPersonas
{
    public class ConexionSQLPasajeros : ConexionSQLPersona
    {

        public ConexionSQLPasajeros() : base() { }

        #region Insertar

        public void Insertar(Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    this.Insertar((Persona)pasajero);
               
                    string cadena = "INSERT INTO Pasajeros (id_pasajero, Correo, Clase, Casino, Piscina, Gimnacio) VALUES";
                    cadena +=
                        "("
                        + this.Obtener_ID(pasajero.DNI) + ","
                        + "'" + pasajero.Correo + "',"
                        + ((int)pasajero.Clase) + ","
                        + new byte().Conversor(pasajero.Casino) + ","
                        + new byte().Conversor(pasajero.Piscina) + ","
                        + new byte().Conversor(pasajero.Gimnacio)
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

                    ConexionSQLEquipaje equipaje = new ConexionSQLEquipaje();

                    equipaje.Insertar(this.Obtener_ID(pasajero.DNI), pasajero);
                }
            }
        }

        #endregion

        #region Modificar

        public void Modificar(Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"UPDATE Pasajeros set " +
                        $"Correo = '{pasajero.Correo}', " +
                        $"Clase = {((int)pasajero.Clase)}, " +
                        $"Casino = {new byte().Conversor(pasajero.Casino)}, " +
                        $"Piscina = {new byte().Conversor(pasajero.Piscina)}, " +
                        $"Gimnacio = {new byte().Conversor(pasajero.Gimnacio)} " +
                        $"WHERE id_pasajero = {pasajero.ID}";

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
                    string cadena = $"DELETE FROM Pasajeros WHERE id_pasajero = {id}";

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

        public Pasajero Obtener(int id)
        {
            Pasajero retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona INNER JOIN Pasajeros ON Persona.id_persona = Pasajeros.id_pasajero INNER JOIN Equipajes ON Persona.id_persona = Equipajes.id_equipaje WHERE id_persona = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
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

        public Almacenamiento<Persona> Lista()
        {
            Almacenamiento<Persona> retorno = new Almacenamiento<Persona>(Persona.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Persona INNER JOIN Pasajeros ON Persona.id_persona = Pasajeros.id_pasajero INNER JOIN Equipajes ON Equipajes.id_equipaje = Pasajeros.id_pasajero";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
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
