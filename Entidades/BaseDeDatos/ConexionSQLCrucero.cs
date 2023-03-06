using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Barcos;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Viajes;
using System.Collections;

namespace Entidades.BaseDeDatos
{
    public class ConexionSQLCrucero : ConexionSQL
    {


        public ConexionSQLCrucero() : base() { }

        #region Insertar

        public void Insertar(Crucero crucero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Cruceros (Matricula, Nombre, Camarotes, Salones, Casinos, Piscinas, Gimnacios, Capacidad_bodega, Peso_total_bodega) VALUES";
                    cadena +=
                        "("
                            + "'" + crucero.Matricula + "',"
                            + "'" + crucero.Nombre + "',"
                            + crucero.Camarotes + ","
                            + crucero.Salones + ","
                            + crucero.Casinos + ","
                            + crucero.Piscinas + ","
                            + crucero.Gimnacios + ","
                            + crucero.Capacidad + ","
                            + crucero.Peso + ""
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

        public void Modificar(Crucero crucero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"UPDATE Cruceros set " +
                        $"Matricula = '{crucero.Matricula}', " +
                        $"Nombre = '{crucero.Nombre}', " +
                        $"Camarotes = {crucero.Camarotes}, " +
                        $"Salones = {crucero.Salones}, " +
                        $"Casinos = {crucero.Salones}, " +
                        $"Piscinas = {crucero.Salones}, " +
                        $"Gimnacios = {crucero.Gimnacios}, " +
                        $"Capacidad_bodega = {crucero.Capacidad}, " +
                        $"Peso_total_bodega = {crucero.Peso} " +
                        $"WHERE id_crucero = {crucero.ID}";

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

        public void Elminar(Crucero crucero)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"DELETE FROM Cruceros WHERE id_crucero = {crucero.ID}";

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

        public Almacenamiento<Crucero> Obtener()
        {
            Almacenamiento<Crucero> lista = new Almacenamiento<Crucero>(Crucero.Comparar);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * From Cruceros";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        lista += new Crucero
                            (
                                (int)this.lector["id_crucero"],
                                this.lector["Matricula"].ToString(),
                                this.lector["Nombre"].ToString(),
                                (int)this.lector["Camarotes"],
                                (int)this.lector["Salones"],
                                (int)this.lector["Casinos"],
                                (int)this.lector["Piscinas"],
                                (int)this.lector["Gimnacios"],
                                (double)this.lector["Capacidad_bodega"],
                                (double)this.lector["Peso_total_bodega"]
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

            return lista;
        }

        public Crucero Obtener_Crucero(int id)
        {
            Crucero retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Cruceros WHERE id_crucero = {id}";

                    this.comando = new SqlCommand();
                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = new Crucero
                            (
                                (int)this.lector["id_crucero"],
                                this.lector["Matricula"].ToString(),
                                this.lector["Nombre"].ToString(),
                                (int)this.lector["Camarotes"],
                                (int)this.lector["Salones"],
                                (int)this.lector["Casinos"],
                                (int)this.lector["Piscinas"],
                                (int)this.lector["Gimnacios"],
                                (double)this.lector["Capacidad_bodega"],
                                (double)this.lector["Peso_total_bodega"]
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

        #region Metodos

        public int Horas(Crucero crucero)
        { 
            int retorno = 0;

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT Duracion_viaje FROM Viajes WHERE id_tipo_crucero = {crucero.ID}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno += (int)this.lector["Duracion_viaje"];
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

