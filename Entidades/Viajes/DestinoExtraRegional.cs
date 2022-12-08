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

        public override string ToString()
        {
            return this.viajeExtraRegional.ToString();
        }
    }
}
