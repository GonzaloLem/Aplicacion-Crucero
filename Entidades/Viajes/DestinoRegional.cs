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

        public override string ToString()
        {
            return this.viajeRegional.ToString();
        }

    }
}
