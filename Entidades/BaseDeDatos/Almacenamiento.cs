﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.BaseDeDatos
{
    public class Almacenamiento <T> where T : class
    {
        private List<T> lista;
        private int limite;

        private Almacenamiento()
        {
            this.lista = new List<T>();
            this.limite = 0;
        }

        public Almacenamiento(int limite) : base()
        {
            this.limite = limite;
        }

        /// <summary>
        /// Te dice la cantidad de items que hay en la lista
        /// </summary>
        public int Total { get => this.lista.Count; }
        public int Limite { get => this.limite; }

        public List<T> Lista
        {
            get
            {
                List<T> retorno = new List<T>();

                    foreach(T item in this.lista)
                    {
                        retorno.Add(item);
                    }

                return retorno;
            }
        }

        public T this[int index]
        {
            get
            {
                if(index > -1 && index < this.limite)
                {
                    return this.lista[index];
                }
                return null;
            }

            set
            {
                if(index > -1 && index < this.limite)
                {
                    this.lista[index] = value;
                }
            }
        }

        private int ObtenerIndice(T item)
        {
            int retorno = -1;

                for(int i=0;i<this.lista.Count;i++)
                {
                    if(item == this.lista[i])
                    {
                        retorno = i;
                        break;
                    }
                }

            return retorno;
        }

        public static bool operator ==(Almacenamiento<T> almacenamiento, T item)
        {
            bool retorno = false;

            foreach(T itm in almacenamiento.Lista)
            {
                if(itm == item)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Almacenamiento<T> almacenamiento, T item)
        {
            return !(almacenamiento==item);
        }

        public static Almacenamiento<T> operator +(Almacenamiento<T> almacenamiento, T item)
        {

            if(almacenamiento!=item && almacenamiento.Total < almacenamiento.limite)
            {
                almacenamiento.lista.Add(item);
            }

            return almacenamiento;
        }

        public static Almacenamiento<T> operator -(Almacenamiento<T> almacenamiento, T item)
        {
            if (almacenamiento.ObtenerIndice(item) != -1)
            {
                almacenamiento.lista.RemoveAt(almacenamiento.ObtenerIndice(item));
            }

            return almacenamiento;
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is T)
                {
                    retorno = true;
                }

            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

                foreach(T item in this.lista)
                {
                    cadena.AppendLine($"{item}");
                }

            return cadena.ToString();
        }

    }
}
