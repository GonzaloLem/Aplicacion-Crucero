using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Viajes;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;
using Entidades.Barcos;

namespace Entidades.BaseDeDatos
{
    public class ConexionSQLViajes : ConexionSQL
    {


        public ConexionSQLViajes() : base() { }

        #region Insertar

        public void Insertar(Viaje viaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = "INSERT INTO Viajes (Ciudad_Partida, Destino, Fecha_inicio, Id_tipo_crucero, Camarotes_premium, Camarotes_turista, Costo_premium, Costo_turista, Duracion_viaje) VALUES";
                    cadena +=
                        "("
                            + ((int)viaje.Partida) + ","
                            + viaje.Destino + ","
                            + "'" + viaje.Inicio.ToString() + "',"
                            + viaje.Crucero.ID + ","
                            + viaje.CamarotesPremium + ","
                            + viaje.CamarotesTurista + ","
                            + viaje.CostoPremium + ","
                            + viaje.CostoTurista + ","
                            + viaje.Duracion
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

        public void Modificar(Viaje viaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"UPDATE Viajes set " +
                        $"Ciudad_partida = {((int)viaje.Partida)}, " +
                        $"Destino = {((uint)viaje.Destino)}, " +
                        $"Fecha_inicio = '{viaje.Inicio.ToString()}', " +
                        $"id_tipo_crucero = {viaje.Crucero.ID}, " +
                        $"Camarotes_premium = {viaje.CamarotesPremium}, " +
                        $"Camarotes_turista = {viaje.CamarotesTurista}, " +
                        $"Costo_premium = {viaje.CostoPremium}, " +
                        $"Costo_turista = {viaje.CostoTurista}, " +
                        $"Duracion_viaje = {viaje.Duracion} " +
                        $"WHERE id_viaje = {viaje.ID}";

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

        public void Eliminar(Viaje viaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    //ConexionSQLTripulantes.Eliminar(viaje);

                    string cadena = $"DELETE FROM Viajes WHERE id_viaje = {viaje.ID} ";

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

        public Almacenamiento<Viaje> Obtener()
        {
           Almacenamiento<Viaje> lista = new Almacenamiento<Viaje>(Viaje.Comparar, new Viaje().Equals);

            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero(); 

                    string cadena = $"SELECT * From Viajes";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        lista += new Viaje
                            (
                                (int)this.lector["id_viaje"],
                                (CiudadesDePartida)this.lector["Ciudad_partida"],
                                Destino.Parse((int)this.lector["Destino"]),
                                DateTime.Parse(this.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)this.lector["id_tipo_crucero"]),
                                (int)this.lector["Camarotes_premium"],
                                (int)this.lector["Camarotes_turista"],
                                (double)this.lector["Costo_premium"],
                                (double)this.lector["Costo_turista"],
                                (int)this.lector["Duracion_viaje"]
                            );
                    }   
                    this.lector.Close();

                }
                catch (Exception es)
                {
                    Console.WriteLine(es.ToString());
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

        public Almacenamiento<Viaje> Obtener(Disponibilidad disponibilidad)
        {
            Almacenamiento<Viaje> lista = new Almacenamiento<Viaje>(Viaje.Comparar);

            if (this.ProbarConexion())
            {
                try
                {

                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * From Viajes";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        Viaje viaje = new Viaje
                            (
                                (int)this.lector["id_viaje"],
                                (CiudadesDePartida)this.lector["Ciudad_partida"],
                                Destino.Parse((int)this.lector["Destino"]),
                                DateTime.Parse(this.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)this.lector["id_tipo_crucero"]),
                                (int)this.lector["Camarotes_premium"],
                                (int)this.lector["Camarotes_turista"],
                                (double)this.lector["Costo_premium"],
                                (double)this.lector["Costo_turista"],
                                (int)this.lector["Duracion_viaje"]
                            );

                        if (viaje.Estado == disponibilidad)
                        {
                            lista += viaje;
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

            return lista;
        }

        public Viaje Obtener_Viaje(int id)
        {
            Viaje retorno = null;

            if (this.ProbarConexion())
            {
                try
                {
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * FROM Viajes WHERE id_viaje = {id}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        retorno = new Viaje
                            (
                                (int)this.lector["id_viaje"],
                                (CiudadesDePartida)this.lector["Ciudad_partida"],
                                Destino.Parse((int)this.lector["Destino"]),
                                DateTime.Parse(this.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)this.lector["id_tipo_crucero"]),
                                (int)this.lector["Camarotes_premium"],
                                (int)this.lector["Camarotes_turista"],
                                (double)this.lector["Costo_premium"],
                                (double)this.lector["Costo_turista"],
                                (int)this.lector["Duracion_viaje"]
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

        public Almacenamiento<Destino> Destinos()
        {
            Almacenamiento<Destino> lista = new Almacenamiento<Destino>(10000);

            if (this.ProbarConexion())
            {
                try
                {
                    string cadena = $"SELECT * FROM Viaje";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        lista += Destino.Parse((int)this.lector["Destino"]);
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

        public bool Disponible(Crucero crucero)
        {
            bool retorno = true;

            if (this.ProbarConexion())
            {
                try
                {
                    
                    ConexionSQLCrucero conexion = new ConexionSQLCrucero();

                    string cadena = $"SELECT * From Viajes WHERE id_tipo_crucero = {crucero.ID}";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadena;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    this.lector = this.comando.ExecuteReader();

                    while (this.lector.Read())
                    {
                        Viaje viaje = new Viaje
                            (
                                (int)this.lector["id_viaje"],
                                (CiudadesDePartida)this.lector["Ciudad_partida"],
                                Destino.Parse((int)this.lector["Destino"]),
                                DateTime.Parse(this.lector["Fecha_inicio"].ToString()),
                                conexion.Obtener_Crucero((int)this.lector["id_tipo_crucero"]),
                                (int)this.lector["Camarotes_premium"],
                                (int)this.lector["Camarotes_turista"],
                                (double)this.lector["Costo_premium"],
                                (double)this.lector["Costo_turista"],
                                (int)this.lector["Duracion_viaje"]
                            );

                                if(viaje.Estado != Disponibilidad.Disponible && viaje.Estado != Disponibilidad.Terminado)
                                {
                                    retorno = false;
                                    break;
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

        #endregion

    }
}
