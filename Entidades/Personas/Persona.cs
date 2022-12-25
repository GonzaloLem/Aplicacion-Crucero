using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Listas;


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

        public Persona()
        {

        }

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

        #region Metodos

        public static int Comparar(Almacenamiento<Persona> lista, Persona persona)
        {
            int retorno = -1;

            for (int i = 0; i < lista.Contar; i++)
            {
                if (lista[i] == persona)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
        }

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

            cadena.AppendLine($"{this.nombre}");
            cadena.AppendLine($"{this.apellido}");
            cadena.AppendLine($"{this.edad}");
            cadena.AppendLine($"{this.dni}");
            cadena.AppendLine($"{this.nacionalidad}");
            cadena.AppendLine($"{this.celular}");

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
