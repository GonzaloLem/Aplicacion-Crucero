using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.BaseDeDatos;
using Entidades.Personas;

namespace Entidades.Barcos
{
    public class Crucero
    {

        private string matricula;
        private string nombre;
        private int camarotes;
        private sbyte salones;
        private sbyte casinos;
        private sbyte piscinas;
        private sbyte gimnacios;
        private float bodegaCapacidad;
        private float bodegaPeso;
        private AlmacenamientoPersonas<Persona> listaTripulantes;
        
        private Crucero(int camarotes)
        {
            this.listaTripulantes = new AlmacenamientoPersonas<Persona>(this.CapacidadPersonas(camarotes));
            this.bodegaPeso = 0;
        }
        public Crucero(string matricula, string nombre, int camarotes, sbyte salones, sbyte casinos, sbyte piscinas, sbyte gimnacios, float capacidadBodega) : this(camarotes)
        {
            this.matricula = matricula;
            this.nombre = nombre;
            this.camarotes = camarotes;
            this.salones = salones;
            this.casinos = casinos;
            this.piscinas = piscinas;
            this.gimnacios = gimnacios;
            this.bodegaCapacidad = capacidadBodega;
        }

        public string Matricula { get => this.matricula; }
        public string Nombre { get => this.nombre; }
        public int Camarotes { get => this.camarotes; }
        public int Salones { get => this.salones; }
        public int Casinos { get => this.casinos; }
        public int Piscinas { get => this.piscinas; }
        public int Gimnacios { get => this.gimnacios; }
        /// <summary>
        /// Capacidad maxima de la bodega
        /// </summary>
        public float Capacidad { get => this.bodegaCapacidad; }

        /// <summary>
        /// Retorna el total de clientes a bordo que tiene el crucero
        /// </summary>
        public int Clientes 
        { 
            get
            {
                int retorno = 0;

                    foreach(Persona item in this.listaTripulantes.Lista)
                    {
                        if(item is  Pasajero)
                        {
                            retorno++;
                        }
                    }

                return retorno;

            }
        }

        private int CapacidadPersonas(int camarotes)
        {
            return camarotes * 4;
        }

        private bool VerificarCapacidadDeLaBodega(Equipaje equipaje)
        {
            bool retorno = false;

                if(this.bodegaPeso+equipaje.Peso < this.bodegaCapacidad)
                {
                    retorno = true;
                }

            return retorno;
        }

        public void AgregarPersona(Persona persona)
        {
            if(persona is Pasajero && this.VerificarCapacidadDeLaBodega(((Pasajero)persona).Equipaje))
            {
                this.bodegaPeso += (float)((Pasajero)persona).Equipaje.Peso;
                this.listaTripulantes += persona;
            }
            else
            {
                this.listaTripulantes += persona; 
            }
        }

        public void EliminarPersona(Persona persona)
        {
            if (persona is Pasajero)
            {
                this.bodegaPeso -= (float)((Pasajero)persona).Equipaje.Peso;
                this.listaTripulantes -= persona;
            }
            else
            {
                this.listaTripulantes -= persona;
            }
        }

        public static bool operator ==(Crucero crucero1, Crucero crucero2)
        {
            return (crucero1.matricula == crucero2.matricula);
        }

        public static bool operator !=(Crucero crucero1, Crucero crucero2)
        {
            return !(crucero1==crucero2);
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Matricula: {this.matricula}");
            cadena.AppendLine($"Nombre: {this.nombre}");
            cadena.AppendLine($"Camarotes: {this.camarotes}");
            cadena.AppendLine($"Salones: {this.salones}");
            cadena.AppendLine($"Casinos: {this.casinos}");
            cadena.AppendLine($"Piscinas: {this.piscinas}");
            cadena.AppendLine($"Gimnacios: {this.gimnacios}");
            cadena.AppendLine($"Capacidad de la Bodega: {this.bodegaCapacidad}KG");
            cadena.AppendLine($"Tripulantes: {this.listaTripulantes}");

            return cadena.ToString();
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is Crucero)
                {
                    retorno = true;
                }

            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



    }
}
