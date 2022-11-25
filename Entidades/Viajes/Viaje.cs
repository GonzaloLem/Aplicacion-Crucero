using System;
using Entidades.Viajes;
using Entidades.Barcos;
using System.Text;

namespace Entidades
{
    public class Viaje
    {
        private CiudadesDePartida partida;
        private Destino destino;
        private DateTime fechaInicio;
        private Crucero crucero;
        private int camarotesPremium;
        private int camarotesTurista;
        private double costoPremium;
        private double costoTurista;
        private int duracionDelViaje;


        public Viaje(CiudadesDePartida partida, Destino destino, DateTime fechaInicio, Crucero crucero, int camarotesPremium, int camarotesTurista, double costoPremium, double costoTurista, int duracionViaje)
        {
            this.partida = partida;
            this.destino = destino;
            this.fechaInicio = fechaInicio;
            this.crucero = crucero;
            this.camarotesPremium = camarotesPremium;
            this.camarotesTurista = camarotesTurista;
            this.costoPremium = costoPremium;
            this.costoTurista = costoTurista;
            this.duracionDelViaje = duracionViaje;
        }

        public CiudadesDePartida Partida { get => this.partida; }
        public Destino Destino { get => this.destino; }
        /// <summary>
        /// Fecha en la cual va a iniciar el viaje
        /// </summary>
        public DateTime Inicio { get => this.fechaInicio; }
        public Crucero Crucero { get => this.crucero; }
        public int CamarotesPremium { get => this.camarotesPremium; }
        public int CamarotesTurista { get => this.camarotesTurista; }
        public double CostoTurista { get => this.costoTurista; }
        public double CostoPremium { get => this.costoPremium; }
        /// <summary>
        /// Duracion del viaje en horas
        /// </summary>
        public int Duracion { get => this.duracionDelViaje; }


        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Partida: {this.partida}");
            cadena.AppendLine($"Destino: {this.destino}");
            cadena.AppendLine($"Fecha de Inicio: {this.fechaInicio}");
            cadena.AppendLine($"Crucero: {this.crucero}");
            cadena.AppendLine($"Camarote Premium: {this.camarotesPremium}");
            cadena.AppendLine($"Camarotes Turista: {this.camarotesTurista}");
            cadena.AppendLine($"Costo Premium: {this.costoPremium}");
            cadena.AppendLine($"Costo Turista: {this.costoTurista}");
            cadena.AppendLine($"Duracion del viaje(Horas): {this.duracionDelViaje}");

            return cadena.ToString();

        }

    }
}
