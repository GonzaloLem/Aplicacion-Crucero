using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Personas;

namespace Entidades.BaseDeDatos
{
    public class ConexionEquipaje : ConexionSQLServer
    {
        public ConexionEquipaje() : base() { }

        public void Insertar(Equipaje equipaje)
        {
            if (this.ProbarConexion())
            {
                try
                {
                    string cadenaComando = "INSERT INTO Equipaje (Bolsos, Maletas, PesoTotalMaletas) VALUES";
                    cadenaComando += "("
                        + equipaje.Bolsos + ","
                        + equipaje.Maletas + ","
                        + equipaje.Peso
                        + ")";

                    this.comando = new SqlCommand();

                    this.comando.CommandType = CommandType.Text;
                    this.comando.CommandText = cadenaComando;
                    this.comando.Connection = this.conexion;

                    this.conexion.Open();

                    int filasAfectadas = this.comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                    }

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

        public Equipaje BuscarEquipaje(int id)
        {
            Equipaje equipaje = null;

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM Equipaje";
                this.comando.Connection = this.conexion;

                if (this.conexion.State != ConnectionState.Open)
                {
                    this.conexion.Open();
                }

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if (id == (int)lector["ID"])
                    {
                        equipaje = new Equipaje((int)lector["ID"], (int)lector["Bolsos"], (int)lector["Maletas"], (double)lector["PesoTotalMaletas"]);
                    }
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

            return equipaje;
        }

        /// <summary>
        /// Te retorna el ultimo equipaje de la lista
        /// </summary>
        /// <returns>Objeto de tipo Equipaje</returns>
        public Equipaje ObtenerEquipaje()
        {
            Equipaje equipaje = null;

            try
            {

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT TOP(1) * FROM Equipaje order by ID desc";
                this.comando.Connection = this.conexion;

                this.conexion.Open();   

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    equipaje = new Equipaje((int)lector["ID"], lector.GetInt32(1), lector.GetInt32(2), lector.GetDouble(3));
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

            return equipaje;
        }


    }
}
