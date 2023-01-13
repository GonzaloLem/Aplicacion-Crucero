using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exepciones
{
    public class ExepcionesPersona : Exception
    {

        public ExepcionesPersona() { }
        public ExepcionesPersona(string mensaje) : base(mensaje) { }

        public void Nombre(string nombre)
        {
            if (nombre == "")
            {
                throw new ExepcionesPersona("El campo Nombre esta vacio.");
            }
            else if (nombre.Length < 4)
            {
                throw new ExepcionesPersona("El campo Nombre tiene que tener minimo 3 caracteres.");
            }

        }
        public void Apellido(string apellido)
        {
            if (apellido == "")
            {
                throw new ExepcionesPersona("El campo Apellido esta vacio.");
            }
            else if (apellido.Length < 4)
            {
                throw new ExepcionesPersona("El campo Apellido tiene que tener minimo 3 caracteres.");
            }

        }

        public void Edad(string edad)
        {
            if (edad == "")
            {
                throw new ExepcionesPersona("El campo Edad esta vacio.");
            }
        }

        public void Dni(string dni)
        {
            if (dni == "")
            {
                throw new ExepcionesPersona("El campo DNI esta vacio.");
            }
            else if (dni.Length != 8)
            {   
                throw new ExepcionesPersona("El DNI no es valido");
            }
        }

        public void Celular(string celular) 
        { 
            if(celular == "")
            {
                throw new ExepcionesPersona("El campo Celular esta vacio.");
            }
            else if(celular.Length != 10)
            {
                throw new ExepcionesPersona("El celular no es valido.");
            }
        }
    }
}
