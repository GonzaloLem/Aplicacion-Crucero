using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Barcos;

namespace Entidades.Listas
{
    public class Embarcadero<T> where T : Crucero
    {

        private List<T> lista;
        private int capacidad;

        private Embarcadero()
        {
            this.lista = new List<T>();
        }
        public Embarcadero(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public int Total { get => this.lista.Count; }

        public List<T> Lista
        {
            get
            {
                List<T> retorno = new List<T>();

                foreach (T item in this.lista)
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
                if(index > -1 && index < this.capacidad)
                {
                    return this.lista[index];
                }
                return null;
            }
        }

       private int ObtenerIndice(T item)
       {
            int retorno = -1;

            for(int i=0;i<this.lista.Count;i++)
            {
                if(this.lista[i]==item)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
       }

        public static bool operator ==(Embarcadero<T> embarcadero, T item)
        {
            bool retorno = false;

                for(int i=0;i<embarcadero.lista.Count;i++)
                {
                    if(embarcadero[i]==item)
                    {
                        retorno = true;
                        break;
                    }
                }

            return retorno;
        }

        public static bool operator !=(Embarcadero<T> embarcadero, T item)
        {
            return !(embarcadero==item);
        }

        public static Embarcadero<T> operator +(Embarcadero<T> embarcadero, T item)
        {
                if(embarcadero!=item && embarcadero.lista.Count < embarcadero.capacidad)
                {
                    embarcadero.lista.Add(item);
                }

            return embarcadero;
        }

        public static Embarcadero<T> operator -(Embarcadero<T> embarcadero, T item)
        {
            if (embarcadero.ObtenerIndice(item) > -1)
            {
                embarcadero.lista.RemoveAt(embarcadero.ObtenerIndice(item));
            }

            return embarcadero;
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
