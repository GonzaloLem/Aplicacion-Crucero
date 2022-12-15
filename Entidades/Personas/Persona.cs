using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades.Personas
{
    public abstract class Persona
    {
        private protected int id;
        private protected string nombre;
        private protected string apellido;
        private protected int edad;
        private protected int dni;
        private protected Nacionalidades nacionalidad;
        private protected double celular;

        #region Constructores
        public Persona(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular)
        {
            this.id = -1;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
            this.nacionalidad = nacionalidad;
            this.celular = celular;
        }

        public Persona(int id, string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular) : this(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.id = id;
        }

        #endregion

        #region Propiedades
        public int ID { get => this.id; }
        public string Nombre { get => this.nombre; }
        public string Apellido { get => this.apellido; }
        public int Edad { get => this.edad; }
        public int DNI { get => this.dni; }
        public Nacionalidades Nacionalidad { get => this.nacionalidad; }
        public double Celular { get => this.celular; }
        public virtual string Tipo { get => "Persona"; }
        public virtual Roles Rol { get => Roles.Admin; }

        #endregion

        #region Comparadores
        public static bool operator ==(Persona persona1, Persona persona2)
        {
            return (persona1.dni == persona2.dni);
        }

        public static bool operator !=(Persona persona1, Persona persona2)
        {
            return !(persona1==persona2);
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Nombre: {this.nombre}");
            cadena.AppendLine($"Apellido: {this.apellido}");
            cadena.AppendLine($"Edad: {this.edad}");
            cadena.AppendLine($"DNI: {this.dni}");
            cadena.AppendLine($"Nacionalidada: {this.nacionalidad}");
            cadena.AppendLine($"Celular: {this.celular}");

            return cadena.ToString();
        }



        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is Persona)
                {
                    retorno = true;
                }

            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

    }
}
