using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Listas
{
    public class Almacenamiento<T> where T : class
    {

        private delegate int DelegadoComparador(Almacenamiento<T> lista, T item);
        private delegate bool DelegadoRestriccion(object objecto);

        private List<T> lista;
        private int limite;

        private DelegadoComparador comparar;
        private DelegadoRestriccion restringir;

        #region Constructores
        private Almacenamiento()
        {
            this.lista = new List<T>();
            this.limite = 2147483647;
            this.comparar = this.Comparar;
            this.restringir = this.Equals;
        }

        public Almacenamiento(int limite) : this()
        {
            this.limite = limite;
        }

        public Almacenamiento(Func<Almacenamiento<T>, T, int> comparacion) : this()
        {
            this.comparar = comparacion.Invoke;
        }

        public Almacenamiento(Func<Almacenamiento<T>, T, int> comparacion, int limite) : this(limite)
        {
            this.comparar = comparacion.Invoke;
        }

        public Almacenamiento(Func<Almacenamiento<T>, T, int> comparacion, Func<object, bool> restriccion) : this(comparacion, 2147483647)
        {
            this.restringir = restriccion.Invoke;
        }

        public Almacenamiento(Func<Almacenamiento<T>, T, int> comparacion, Func<object, bool> restriccion, int limite) : this(comparacion, restriccion)
        {
            this.limite = limite;
        }

        #endregion

        #region Propiedades

        public int Contar { get => this.lista.Count; }
        public int Limite { get => this.limite; }
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

        #endregion

        #region Indexador

        public T this[int index]
        {
            get
            {
                if (index > -1 && index < this.limite)
                {
                    return this.lista[index];
                }
                return null;
            }

        }

        #endregion

        #region Metodos

        private int Comparar(Almacenamiento<T> lista, T item)
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

        #endregion

        #region Operadores

        public static implicit operator Almacenamiento<T>(List<T> lista)
        {
            Almacenamiento<T> retorno = new Almacenamiento<T>();

                foreach(T item in lista)
                {
                    retorno += item;
                }

            return retorno;
        }

        public static bool operator ==(Almacenamiento<T> almacenamiento1, Almacenamiento<T> almacenamiento2)
        {
            bool retorno = true;

                for (int i = 0; i < almacenamiento1.Contar; i++)
                {
                    if (almacenamiento1.comparar.Invoke(almacenamiento2, almacenamiento1[i]) == -1)
                    { 
                        retorno = false;
                        break;
                    }
                }

            return retorno;
        }

        public static bool operator !=(Almacenamiento<T> almacenamiento1, Almacenamiento<T> almacenamiento2)
        {
            return !(almacenamiento1==almacenamiento2);
        }

        public static bool operator ==(Almacenamiento<T> almacenamiento, T item)
        {
            return (almacenamiento.comparar.Invoke(almacenamiento, item) != -1);
        }

        public static bool operator !=(Almacenamiento<T> almacenamiento, T item)
        {
            return !(almacenamiento == item);
        }

        public static Almacenamiento<T> operator +(Almacenamiento<T> almacenamiento, T item)
        {

            if (almacenamiento.restringir.Invoke(item) && almacenamiento != item && almacenamiento.Contar < almacenamiento.limite)
            {
                almacenamiento.lista.Add(item);
            }

            return almacenamiento;
        }

        public static Almacenamiento<T> operator -(Almacenamiento<T> almacenamiento, T item)
        {
            if (almacenamiento == item)
            {
                almacenamiento.lista.RemoveAt(almacenamiento.comparar.Invoke(almacenamiento, item));
            }

            return almacenamiento;
        }

        public static Almacenamiento<T> operator +(Almacenamiento<T> almacenamiento1, Almacenamiento<T> almacenamiento2)
        {

                for(int i=0;i<almacenamiento2.Contar;i++)
                {
                    almacenamiento1 += almacenamiento2[i];
                }

            return almacenamiento1;
        }

        public static Almacenamiento<T> operator -(Almacenamiento<T> almacenamiento1, Almacenamiento<T> almacenamiento2)
        {

            for (int i = 0; i < almacenamiento2.Contar; i++)
            {
                almacenamiento1 -= almacenamiento2[i];
            }

            return almacenamiento1;
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is T)
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

            foreach (T item in this.lista)
            {
                cadena.AppendLine($"{item}");
            }

            return cadena.ToString();
        }

        #endregion

    }
}
