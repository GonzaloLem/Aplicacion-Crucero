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
    public class ConexionSQLEquipaje : ConexionSQL
    {

        public ConexionSQLEquipaje() : base() { }

        #region Insertar

        public void Insertar(int id, Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Equipajes (id_equipaje, Bolsos, Maletas, Peso_maletas) VALUES";
                    cadena +=
                        "("
                        + id + ","
                        + pasajero.Equipaje.Bolsos + ","
                        + pasajero.Equipaje.Maletas + ","
                        + pasajero.Equipaje.Peso
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
        public void Modificar(Pasajero pasajero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"update Equipajes set " +
                        $"Bolsos = {pasajero.Equipaje.Bolsos}, " +
                        $"Maletas = {pasajero.Equipaje.Maletas}, " +
                        $"Peso_maletas = {pasajero.Equipaje.Peso} " +
                        $"WHERE id_equipaje = {pasajero.ID}";

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
                    string cadena = $"DELETE FROM Equipajes WHERE id_equipaje = {id}";

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


        public Equipaje Obtener(Pasajero pasajero)
        {
            Equipaje retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Equipajes where id_equipaje = {pasajero.ID}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read()) 
                    {
                        retorno = new Equipaje
                            (
                                (int)this.lector["Id_equipaje"],
                                (int)this.lector["Bolsos"],
                                (int)this.lector["Maletas"],
                                (double)this.lector["Peso_maletas"]
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

        public Almacenamiento<Equipaje> Lista()
        {
            Almacenamiento<Equipaje> retorno = new Almacenamiento<Equipaje>(100000);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Equipajes";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno += new Equipaje
                            (
                                (int)this.lector["Id_equipaje"],
                                (int)this.lector["Bolsos"],
                                (int)this.lector["Maletas"],
                                (double)this.lector["Peso_maletas"]
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
