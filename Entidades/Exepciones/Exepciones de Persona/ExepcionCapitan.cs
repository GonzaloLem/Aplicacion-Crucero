using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones.Exepciones_de_Persona
{
    public class ExepcionCapitan : Exception
    {

        public ExepcionCapitan() : base() { }

        public ExepcionCapitan(string mensaje) : base(mensaje) { }

        public void Horas(string horas)
        {
            if(horas == "")
            {
                throw new ExepcionCapitan("El capo Horas de Viaje esta vacio.");
            }
        }


    }
}
