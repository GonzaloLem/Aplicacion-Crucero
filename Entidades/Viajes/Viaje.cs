using System;
using Entidades.Viajes;
using Entidades.Barcos;
using System.Text;

namespace Entidades
{
    public class Viaje
    {
        int id;
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
            this.id = 0;
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

        public Viaje(int id, CiudadesDePartida partida, Destino destino, DateTime fechaInicio, Crucero crucero, int camarotesPremium, int camarotesTurista, double costoPremium, double costoTurista, int duracionViaje) : this(partida, destino, fechaInicio, crucero, camarotesPremium, camarotesTurista, costoPremium, costoTurista, duracionViaje)
        {
            this.id = id;
        }

        public int ID { get => this.id; }
        public CiudadesDePartida Partida { get => this.partida; }

        /// <summary>
        /// Devuelve el tipo de destino que es
        /// </summary>
        public string Tipo { get => this.destino.ToString(); }

        public int Destino 
        {
            get
            {
                if(this.destino is DestinoRegional)
                {
                    return (int)((DestinoRegional)this.destino).Regional;
                }
                else if(this.destino is DestinoExtraRegional)
                {
                    return (int)((DestinoExtraRegional)this.destino).ExtraRegional;
                }
                return -1;
            }
        }
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


        public static int Calcular(Destino destino)
        {
            int retorno = -1;

                Random rd = new Random();

                    if(destino is DestinoRegional)
                    {
                        retorno = rd.Next(72,361);
                    }
                    else if(destino is DestinoExtraRegional)
                    {
                        retorno = rd.Next(480, 721);
                    }

            return retorno;
        }
        public static int Calcular(int camarotes, byte tipo)
        {
            int retorno = -1;

                retorno = ((camarotes * 35)/100);

                    if(tipo == 0)
                    {
                        retorno = camarotes - retorno;
                    }

            return retorno;
        }

        public static double Calcular(Destino destino, int horas, byte tipo)
        {
            int retorno = -1;

                if(destino is DestinoRegional)
                {
                    retorno = horas * 57;
                }
                else if(destino is DestinoExtraRegional)
                {
                    retorno = horas * 127;
                }

                    if(tipo == 1)
                    {
                        retorno += ( (retorno * 20) / 100);
                    }

            return retorno;
        }

        public static bool operator ==(Viaje viaje1, Viaje viaje2)
        {
            return (viaje1.Destino == viaje2.Destino && viaje1.fechaInicio.ToShortDateString() == viaje2.fechaInicio.ToShortDateString());
        }

        public static bool operator !=(Viaje viaje1, Viaje viaje2)
        {
            return !(viaje1==viaje2);
        }

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

        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is Viaje)
                {
                    retorno = true;
                }

            return retorno;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
