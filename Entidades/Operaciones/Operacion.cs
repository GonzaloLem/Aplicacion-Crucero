using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.BaseDeDatos;
using Entidades.Personas;

namespace Entidades.Operaciones
{
    public class Operacion
    {

        public static bool Validar(string cadena)
        {
            bool retorno = false;

                if(cadena is not null)
                {
                    retorno = true;
                }

            return retorno;
        }

        public static int InsertarID()
        {
            int retorno = 0;

            List<ConexionSQLServer> conexiones = new List<ConexionSQLServer>();

            conexiones.Add(new ConexionPasajeros());
            conexiones.Add(new ConexionEmpleados());
            conexiones.Add(new ConexionCapitan());

            foreach(ConexionSQLServer item in conexiones)
            {
                if(item.ObtenerID() > retorno)
                {
                    retorno = item.ObtenerID();
                }
            }

            return ++retorno;
        }

    }
}
