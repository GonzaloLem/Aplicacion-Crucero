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


    }
}
