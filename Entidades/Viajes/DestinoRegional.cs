using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Viajes
{
    public class DestinoRegional : Destino
    {
        private ViajesRegionales viajeRegional;

        public DestinoRegional(ViajesRegionales viajeRegional) : base()
        {
            this.viajeRegional = viajeRegional;
        }

        public ViajesRegionales Regional { get => this.viajeRegional; }

        public static bool operator ==(DestinoRegional destino1, DestinoRegional destino2)
        {
            return (destino1.viajeRegional == destino2.viajeRegional);
        }

        public static bool operator !=(DestinoRegional destino1, DestinoRegional destino2)
        {
            return !(destino1==destino2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is DestinoRegional)
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
            return this.viajeRegional.ToString();
        }

    }
}
