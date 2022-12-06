using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Personas;
using Entidades.Interfaces;

namespace Entidades.BaseDeDatos
{
    public abstract class ConexionSQLServer 
    {
        private protected SqlConnection conexion;
        private protected SqlCommand comando;
        private protected SqlDataReader lector;
        private protected SqlDataAdapter adaptador;

        public ConexionSQLServer()
        {
            this.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            this.comando = new SqlCommand();
            this.adaptador = new SqlDataAdapter();
            this.comando.CommandType = CommandType.Text;
            this.comando.Connection = this.conexion;

        }

        #region Probar conexion
        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        public virtual int ObtenerID()
        {
            return -1;
        }

        public virtual int Contar()
        {
            return -1;
        }

    }
}
