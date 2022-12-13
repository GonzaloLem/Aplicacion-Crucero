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

        private bool casino;
        private bool piscina;
        private bool gimnacio;

        public Pasajero(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, string correo,  Clases clase, Equipaje equipaje, bool casino, bool gimnacio, bool piscina) : base(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.correo = correo;
            this.clase = clase;
            this.equipaje = equipaje;
            this.casino = casino;
            this.piscina = piscina;
            this.gimnacio = gimnacio;
        }

        public Pasajero(int id, string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, string correo, Clases clase, Equipaje equipaje, bool casino, bool gimnacio, bool piscina) : base(id, nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.correo = correo;
            this.clase = clase;
            this.equipaje = equipaje;
            this.casino = casino;
            this.piscina = piscina;
            this.gimnacio = gimnacio;
        }

        public Pasajero(string correo, Clases clase, Equipaje equipaje, bool casino, bool piscina, bool gimnacio) : base(null, null, -1, -1, 0, -1)
        {
            this.correo = correo;
            this.clase = clase;
            this.equipaje = equipaje;
            this.casino = casino;
            this.piscina = piscina;
            this.gimnacio = gimnacio;
        }

        public Pasajero(int id, string correo, Clases clase, Equipaje equipaje, bool casino, bool piscina, bool gimnacio) : this(correo, clase, equipaje, casino, piscina, gimnacio)
        {
            this.id = id;
        }

        public string Correo { get => this.correo; }
        public Clases Clase { get => this.clase; }
        public Equipaje Equipaje { get => this.equipaje; }

        public bool Casino { get => this.casino; }
        public bool Piscina { get => this.piscina; }
        public bool Gimnacio { get => this.gimnacio; }
        public override string Tipo { get => "Pasajero"; }
        public override Roles Rol { get => Roles.Cliente; }
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Correo: {this.correo}");
            cadena.AppendLine($"Clase: {this.clase}");
            cadena.AppendLine($"Equipaje {this.equipaje}");
            cadena.AppendLine($"Casino: {this.casino}");
            cadena.AppendLine($"Piscina: {this.piscina}");
            cadena.AppendLine($"Gimnacio: {this.gimnacio}");

            return cadena.ToString();
        }



    }
}
