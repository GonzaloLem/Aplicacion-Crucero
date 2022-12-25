using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Equipaje
    {
        private int id;
        private int bolsos;
        private int maletas;
        private double pesoMaleta;
    

        public Equipaje() { }

        public Equipaje(int bolsos, int maletas, double peso)
        {
            this.id = -1;
            this.bolsos = bolsos;
            this.maletas = maletas;
            this.pesoMaleta = peso;
        }

        public Equipaje(int id, int bolsos, int maletas, double peso) : this(bolsos, maletas, peso)
        {
            this.id = id;
        }

        public int ID { get => this.id; set => this.id = value; }
        public int Bolsos { get => this.bolsos; set => this.bolsos = value; }
        public int Maletas { get => this.maletas; set => this.maletas = value; }
        public double Peso { get => this.pesoMaleta; set => this.pesoMaleta = value;  }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.Append($"{this.id}");
            cadena.Append($"{this.bolsos}");
            cadena.Append($"{this.maletas}");
            cadena.Append($"{this.pesoMaleta}");

            return cadena.ToString();
        }

    }
}
