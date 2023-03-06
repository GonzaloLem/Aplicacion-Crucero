using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BaseDeDatos
{
    public abstract class ConexionSQL
    {

        private protected SqlConnection conexion;
        private protected SqlCommand comando;
        private protected SqlDataReader lector;
        private protected SqlDataAdapter adaptador;

        #region Constructor
        public ConexionSQL()
        {
            this.conexion = new SqlConnection(@"Data Source=.;
                                            Database=AplicacionCrucero;
                                            Trusted_Connection=True;");

            this.comando = new SqlCommand();
            this.adaptador = new SqlDataAdapter();
            this.comando.CommandType = CommandType.Text;
            this.comando.Connection = this.conexion;

        }
        #endregion

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

    }
}
