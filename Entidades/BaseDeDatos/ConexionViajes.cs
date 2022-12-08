using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Viajes;
using Entidades.Listas;

namespace Entidades.BaseDeDatos
{
    public class ConexionViajes : ConexionSQLServer
    {
        public ConexionViajes() : base() { }

        #region Insertar

        public void Insertar(Viaje viaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadenaComando = "INSERT INTO Viaje (CiudadDePartida, Destino, FechaDeInicio, ID_Crucero, CamarotesPremium, CamarotesTurista, CostoPremium, CostoTurista, DuracionDelViaje) VALUES";
                    cadenaComando += "("
                        + (int)viaje.Partida + ","
                        + viaje.Destino + ","
                        + "'" + viaje.Inicio.ToString()+ "',"
                        + viaje.Crucero.ID + ","
                        + viaje.CamarotesPremium + ","
                        + viaje.CamarotesTurista + ","
                        + viaje.CostoPremium + ","
                        + viaje.CostoTurista + ","
                        + viaje.Duracion
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

        public AlmecenamientoViajes<Viaje> Obtener()
        {
            AlmecenamientoViajes<Viaje> lista = new AlmecenamientoViajes<Viaje>(1000);
            try
            {
                ConexionCrucero conexionCrucero = new ConexionCrucero();
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Viaje";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Viaje viaje = new Viaje
                    (
                        (int)this.lector["ID"],
                        (CiudadesDePartida)this.lector["CiudadDePartida"],
                        Destino.Parse((int)this.lector["Destino"]),
                        DateTime.Parse(this.lector["FechaDeInicio"].ToString()),
                        conexionCrucero.Obtener((int)this.lector["ID_Crucero"]),
                        (int)this.lector["CamarotesPremium"],
                        (int)this.lector["CamarotesTurista"],
                        (double)this.lector["CostoPremium"],
                        (double)this.lector["CostoTurista"],
                        (int)this.lector["DuracionDelViaje"]
                    );
                    lista += viaje;
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

    }
}
