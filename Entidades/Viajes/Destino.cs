using Entidades.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Viajes
{
    public abstract class Destino
    {
        int popularidad;
        public Destino() 
        {
            this.popularidad = 1;
        }

        #region Propiedades
        public int Popularidad 
        { 
            get
            {
                return this.popularidad;
            }

            set
            {
                if(value == 1)
                {
                    this.popularidad += value;
                }
            }

        }
        #endregion

        #region Operadores

        public static bool operator ==(Destino destino1, Destino destino2)
        {
            bool retorno = false;

            if(destino1 is DestinoRegional && destino2 is DestinoRegional)
            {
                retorno = (DestinoRegional)destino1 == (DestinoRegional)destino2;
            }
            else if(destino1 is DestinoExtraRegional && destino2 is DestinoExtraRegional)
            {
                retorno = (DestinoExtraRegional)destino1 == (DestinoExtraRegional)destino2;
            }

            return retorno;
        }

        public static bool operator !=(Destino destino1, Destino destino2)
        {
            return !(destino1==destino2);
        }

        #endregion

        #region Metodos
        public static Destino Parse(int valor)
        {
            Destino destino = null;

                if(valor > -1 && valor < 10)
                {
                    destino = new DestinoRegional((ViajesRegionales)valor);
                }
                else if(valor > 99 && valor < 108)
                {
                    destino = new DestinoExtraRegional((ViajesExtraRegional)valor);
                }

            return destino;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Destino)
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
