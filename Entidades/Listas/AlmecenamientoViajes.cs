using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Barcos;

namespace Entidades.Listas
{
    public class AlmecenamientoViajes<T> where T : Viaje
    {

        private List<T> lista;
        private int limite;


        private AlmecenamientoViajes()
        {
            this.lista = new List<T>();
        }

        public AlmecenamientoViajes(int limite) : this()
        {
            this.limite = limite;
        }

        public int Total { get => this.lista.Count; }

        public T this[int index]
        {
            get
            {
                if(index > -1 && index < this.lista.Count)
                {
                    return this.lista[index];
                }
                return default(T);

            }
        }

        private int ObtenerIndice(T item)
        {
            int retorno = -1;

            for (int i = 0; i < this.lista.Count; i++)
            {
                if (this.lista[i] == item)
                {
                    retorno = i;
                    break;
                }
            }

            return retorno;
        }
        public static bool operator ==(AlmecenamientoViajes<T> almecenamiento, T item)
        {
            bool retorno = false;

                for(int i=0;i<almecenamiento.lista.Count;i++)
                {
                    if(almecenamiento[i] == item)
                    {
                        retorno = true;
                        break;
                    }
                }

            return retorno;
        }

        public static bool operator !=(AlmecenamientoViajes<T> almecenamiento, T item)
        {
            return !(almecenamiento==item);
        }

        public static AlmecenamientoViajes<T> operator +(AlmecenamientoViajes<T> almecenamiento, T item)
        {
                if(almecenamiento!=item)
                {
                    almecenamiento.lista.Add(item);
                }

            return almecenamiento;
        }

        public static AlmecenamientoViajes<T> operator -(AlmecenamientoViajes<T> almecenamiento, T item)
        {
            if (almecenamiento.ObtenerIndice(item) > -1)
            {
                almecenamiento.lista.RemoveAt(almecenamiento.ObtenerIndice(item));
            }

            return almecenamiento;
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

    }
}
