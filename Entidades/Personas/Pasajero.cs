using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Pasajero : Persona
    {
        private string correo;
        private Clases clase;
        Equipaje equipaje;

        public Pasajero(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, int celular, string correo,  Clases clase, Equipaje equipaje) : base(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.correo = correo;
            this.clase = clase;
            this.equipaje = equipaje;
        }

        public string Correo { get => this.correo; }
        public Clases Clase { get => this.clase; }
        public Equipaje Equipaje { get => this.equipaje; }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Correo: {this.correo}");
            cadena.AppendLine($"Clase: {this.clase}");
            cadena.AppendLine($"Equipaje {this.equipaje}");

            return cadena.ToString();
        }

    }
}
