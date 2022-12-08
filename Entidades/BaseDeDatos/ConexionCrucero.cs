using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Barcos;
using Entidades.Personas;
using Entidades.Listas;
using Entidades.Extensiones;

namespace Entidades.BaseDeDatos
{
    public class ConexionCrucero : ConexionSQLServer
    {

        public ConexionCrucero() : base() { }

        #region Insertar

        public void Insertar(Crucero crucero)
        {
            
                if (this.ProbarConexion())
                {
                    try
                    {
                        string cadenaComando = "INSERT INTO Crucero (Matricula, Nombre, Camarotes, Salones, Casinos, Piscinas, Gimnacios, CapacidadBodega, PesoTotalDeLaBodega, ListaTripulantes) VALUES";
                        cadenaComando += "(" + "'"
                            + crucero.Matricula + "','"
                            + crucero.Nombre + "',"
                            + crucero.Camarotes + ","
                            + crucero.Salones + ","
                            + crucero.Casinos + ","
                            + crucero.Piscinas + ","
                            + crucero.Gimnacios + ","
                            + crucero.Capacidad + ","
                            + crucero.Peso + ",'"
                            + crucero.ObtenerIdsTripulantes() + "'"
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

        #region Obtener

        public string ObtenerIDsTripulantes()
        {
            string retorno = null;

            

            return retorno;
        }

        public Embarcadero<Crucero> Obtener()
        {
            Embarcadero<Crucero> lista = new Embarcadero<Crucero>(1000);

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Crucero";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Crucero crucero = new Crucero
                    (
                        (int)this.lector["ID"],
                        this.lector["Matricula"].ToString(),
                        this.lector["Nombre"].ToString(),
                        (int)this.lector["Camarotes"],
                        (int)this.lector["Salones"],
                        (int)this.lector["Casinos"],
                        (int)this.lector["Piscinas"],
                        (int)this.lector["Gimnacios"],
                        (double)this.lector["CapacidadBodega"],
                        (double)this.lector["PesoTotalDeLaBodega"],
                        this.ObtenerTripulantes(this.lector["ListaTripulantes"].ToString())
                    );

                    lista += crucero;
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

        private AlmacenamientoPersonas<Persona> ObtenerTripulantes(string ids)
        {

            for(int i=0;i<ids.Length;i++)
            {
                string id = ids.Hasta(',');
                ids = ids.Rehacer(ids.Contar(ids, ','));
            }


            return new AlmacenamientoPersonas<Persona>(1);
        }

        public Crucero Obtener(int id)
        {
            Crucero retorno = null;

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = $"SELECT * FROM Crucero WHERE ID = {id}";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Crucero crucero = new Crucero
                    (
                        (int)this.lector["ID"],
                        this.lector["Matricula"].ToString(),
                        this.lector["Nombre"].ToString(),
                        (int)this.lector["Camarotes"],
                        (int)this.lector["Salones"],
                        (int)this.lector["Casinos"],
                        (int)this.lector["Piscinas"],
                        (int)this.lector["Gimnacios"],
                        (double)this.lector["CapacidadBodega"],
                        (double)this.lector["PesoTotalDeLaBodega"],
                        this.ObtenerTripulantes(this.lector["ListaTripulantes"].ToString())
                    );

                    retorno = crucero;
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

            return retorno;
        }

        #endregion

    }
}
