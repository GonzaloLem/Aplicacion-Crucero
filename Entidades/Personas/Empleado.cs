using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Empleado : Persona
    {
        PuestosDeTrabajo puesto;
        DateTime diaQueSeUnio;

        public Empleado(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, int celular, PuestosDeTrabajo puesto) : base(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.puesto = puesto;
            this.diaQueSeUnio = DateTime.Today;
        }

        public PuestosDeTrabajo Puesto { get => this.puesto; }

        /// <summary>
        /// Fecha en la que arranco a trabajar para la empresa
        /// </summary>
        public DateTime Comienzo { get => this.diaQueSeUnio; }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Puesto de Trabajo: {this.puesto}");
            cadena.AppendLine($"Dia que arranco a Trabajar para la Empresa: {this.diaQueSeUnio}");

            return cadena.ToString();
        }

    }
}
