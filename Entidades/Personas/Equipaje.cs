using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Equipaje
    {

        private int bolsos;
        private int maletas;
        private float pesoMaleta;

        public Equipaje(int bolsos, int maletas, float peso)
        {
            this.bolsos = bolsos;
            this.maletas = maletas;
            this.pesoMaleta = peso;
        }

        public int Bolsos { get => this.bolsos; }
        public int Maletas { get => this.maletas; }
        public float Peso { get => this.pesoMaleta; }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Bolsos: {this.bolsos}");
            cadena.AppendLine($"Maletas: {this.maletas}");
            cadena.AppendLine($"Peso de la/s Maletas: {this.pesoMaleta}");

            return cadena.ToString();
        }

    }
}
