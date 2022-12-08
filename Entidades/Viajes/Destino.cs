using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Viajes
{
    public abstract class Destino
    {
        public Destino() { }


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
    }
}
