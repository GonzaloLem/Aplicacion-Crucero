using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones.Exepciones_de_Persona
{
    public class ExepcionPasajero : Exception
    {

        public ExepcionPasajero() : base() { }

        public ExepcionPasajero(string mensaje) : base(mensaje) { }

        public void Correo(string correo)
        {
            if(correo == "")
            {
                throw new ExepcionPasajero("El campo correo esta vacio.");
            }
            
        }

        public void Bolsos(string bolsos)
        {
            if(bolsos == "")
            {
                throw new ExepcionPasajero("El campo Bolso esta vacio.");
            }
        }

        public void Maletas(string maletas)
        {
            if (maletas == "")
            {
                throw new ExepcionPasajero("El campo Maletas esta vacio.");
            }
        }

        public void Peso(string peso)
        {
            if (peso == "")
            {
                throw new ExepcionPasajero("El campo Peso de las Maletas esta vacio.");
            }
        }

    }
}
