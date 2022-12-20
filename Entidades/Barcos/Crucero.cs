using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.BaseDeDatos;
using Entidades.Personas;
using Entidades.Listas;

namespace Entidades.Barcos
{
    public class Crucero
    {

        int id;
        private string matricula;
        private string nombre;
        private int camarotes;
        private int salones;
        private int casinos;
        private int piscinas;
        private int gimnacios;
        private double bodegaCapacidad;
        private double bodegaPeso;
        private Almacenamiento<Persona> listaTripulantes;

        #region Constructores
        public Crucero()
        {
            this.id = 0;
            this.matricula = null;
            this.nombre = null;
            this.camarotes = 0;
            this.salones = 0;
            this.casinos = 0;
            this.piscinas = 0;
            this.gimnacios = 0;
            this.bodegaCapacidad = 0;
            this.bodegaPeso = 0;
            this.listaTripulantes = null;
        }
        private Crucero(int camarotes)
        {
            this.id = 0;
            this.listaTripulantes = new Almacenamiento<Persona>(Persona.Comparar, this.CapacidadPersonas(camarotes));
            this.bodegaPeso = 0;
        }
        public Crucero(string matricula, string nombre, int camarotes, int salones, int casinos, int piscinas, int gimnacios, double capacidadBodega) : this(camarotes)
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

        public Crucero(int id, string matricula, string nombre, int camarotes, int salones, int casinos, int piscinas, int gimnacios, double capacidadBodega, double pesoTotalBodega, Almacenamiento<Persona> tripulantes) : this(matricula, nombre, camarotes, salones, casinos, piscinas, gimnacios, capacidadBodega)
        {
            this.id = id;
            this.bodegaPeso = pesoTotalBodega;
            this.listaTripulantes = tripulantes;
        }
        #endregion

        #region Propiedades
        public int ID { get => this.id; }
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
        public double Capacidad { get => this.bodegaCapacidad; }
        /// <summary>
        /// Peso de la bodega
        /// </summary>
        public double Peso { get => this.bodegaPeso; }

        public Almacenamiento<Persona> Tripulantes { get => this.listaTripulantes; }

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

        /// <summary>
        /// Te dice si se pueden agregar mas tripulantes o no
        /// </summary>
        public bool Estado
        {
            get
            {
                bool retorno = false;

                if (this.listaTripulantes.Contar < this.CapacidadPersonas(this.camarotes))
                {
                    retorno = true;
                }

                return retorno;
            }

        }

        #endregion

        #region Metodos

        public static int Comparar(Almacenamiento<Crucero> lista, Crucero crucero)
        {
            int retorno = -1;

            for (int i = 0; i < lista.Contar; i++)
            {
                if (lista[i] == crucero)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
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

        public static string GenerarMatricula()
        {
            string retorno = null;
            char caracter = '_';
                Random rd = new Random();

                    for(int i=0;i<3;i++)
                    {
                        caracter = (char)(rd.Next(65, 91));
                        retorno += caracter.ToString();
                    }

                    retorno += '-';

                    for(int i=0;i<4;i++)
                    { 
                        caracter = (char)(rd.Next(48, 58));
                        retorno += caracter.ToString();
                    }

            return retorno;
        }

        public string ObtenerIdsTripulantes()
        {
            string retorno = null;

            for (int i = 0; i < this.listaTripulantes.Contar; i++)
            {
                if (i != this.listaTripulantes.Contar - 1)
                {
                    retorno += this.listaTripulantes[i].ID + ",";
                }
                else
                {
                    retorno += this.listaTripulantes[i].ID;
                }

            }

            return retorno;
        }

        #endregion

        #region Operadores
        public static bool operator ==(Crucero crucero1, Crucero crucero2)
        {
            return (crucero1.matricula == crucero2.matricula);
        }

        public static bool operator !=(Crucero crucero1, Crucero crucero2)
        {
            return !(crucero1==crucero2);
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"{this.nombre}");

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
        #endregion



    }
}
