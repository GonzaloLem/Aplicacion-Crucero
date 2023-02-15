using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones
{
    public class ExepcionViaje : Exception
    {

        public ExepcionViaje() : base() { }

        public ExepcionViaje(string mensaje) : base(mensaje) { }

        public void AgregarPersona(Viaje viaje)
        {
            if(viaje.Estado != Disponibilidad.Disponible)
            {
                throw new ExepcionViaje($"No se puede agregar una persona a un viaje {viaje.Estado}");
            }
        }

    }
}
