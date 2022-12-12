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

        public Empleado(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, PuestosDeTrabajo puesto) : base(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.puesto = puesto;
            this.diaQueSeUnio = DateTime.Now;
        }

        public Empleado(int id, string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, PuestosDeTrabajo puesto, DateTime fechaIngreso) : base(id, nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.puesto = puesto;
            this.diaQueSeUnio = fechaIngreso;
        }

        public Empleado(PuestosDeTrabajo puesto, DateTime fechaDeIngreso) : base(null, null, -1, -1, Nacionalidades.Alemania, -1)
        {
            this.puesto = puesto;
            this.diaQueSeUnio = fechaDeIngreso;
        }

        public PuestosDeTrabajo Puesto { get => this.puesto; }

        /// <summary>
        /// Fecha y hora en la que se unio el empleado a la empresa
        /// </summary>
        public DateTime Fecha { get => this.diaQueSeUnio; }
        public override string Tipo { get => "Empleado"; }
        public override Roles Rol { get => Roles.Empleado; }

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
