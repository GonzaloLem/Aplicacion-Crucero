using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Viajes
{
    public class DestinoExtraRegional : Destino
    {
        private ViajesExtraRegional viajeExtraRegional;

        public DestinoExtraRegional(ViajesExtraRegional viajeExtraRegional) : base()
        {
            this.viajeExtraRegional = viajeExtraRegional;
        }

        public ViajesExtraRegional ExtraRegional { get => this.viajeExtraRegional; }

        public static bool operator ==(DestinoExtraRegional destino1, DestinoExtraRegional destino2)
        {
            return (destino1.viajeExtraRegional == destino2.viajeExtraRegional);
        }

        public static bool operator !=(DestinoExtraRegional destino1, DestinoExtraRegional destino2)
        {
            return !(destino1 == destino2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is DestinoExtraRegional)
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
            return this.viajeExtraRegional.ToString();
        }
    }
}
