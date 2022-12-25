using System;
using Entidades.Viajes;
using Entidades.Barcos;
using System.Text;
using Entidades.Personas;
using Entidades.Listas;
using Entidades.BaseDeDatos.ConexionesPersonas;

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

        #region Constructores
        public Viaje()
        {
            this.id = 0;
            this.partida = 0;
            this.destino = null;
            this.fechaInicio = DateTime.Now;
            this.crucero = null;
            this.camarotesPremium = 0;
            this.camarotesTurista = 0;
            this.costoPremium = 0;
            this.costoTurista = 0;
            this.duracionDelViaje = 0;
        }

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

        #endregion

        #region Propiedades
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
        public DateTime Llegada { get => this.fechaInicio + new TimeSpan(this.duracionDelViaje, 0, 0); }

        /// <summary>
        /// Te dice la disponibilidad actual que tiene el viaje
        /// </summary>
        public Disponibilidad Estado
        {
            get
            {
                Disponibilidad retorno = Disponibilidad.Disponible;

                if (this.fechaInicio <= DateTime.Now && DateTime.Now <= this.Llegada)
                {
                    retorno = Disponibilidad.Navegando;

                }
                else if (DateTime.Now >= this.Llegada)
                {
                    retorno = Disponibilidad.Terminado;
                }
                else if (!this.crucero.Estado)
                {
                    retorno = Disponibilidad.Lleno;
                }

                return retorno;
            }
        }

        #endregion

        #region Calculos
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

        #endregion

        #region Metodos

        public static Viaje Convertir(string[] viaje)
        {
             
            return new Viaje
                (
                   int.Parse(viaje[0]),
                   (CiudadesDePartida)int.Parse(viaje[1]),
                    (Destino)int.Parse(viaje[2]),
                    DateTime.Parse(viaje[3]),
                    (Crucero)int.Parse(viaje[4]),
                    int.Parse(viaje[5]),
                    int.Parse(viaje[6]),
                    double.Parse(viaje[7]),
                    double.Parse(viaje[8]),
                    int.Parse(viaje[9])
                );
        }

        public static int Comparar(Almacenamiento<Viaje> lista, Viaje viaje)
        {
            int retorno = -1;

                for (int i = 0; i < lista.Contar; i++)
                {
                    if (lista[i] == viaje)
                    {
                        retorno = i;
                        break;
                    }
                }

            return retorno;
        }

        public double Ganancias()
        {
            double retorno = 0;
            Almacenamiento<Persona> lista = ConexionSQLTripulantes.Obtener(this);

                for(int i=0;i<lista.Contar;i++)
                {
                    if(lista[i] is Pasajero)
                    {   
                        if(((Pasajero)lista[i]).Clase == Clases.Premium)
                        {
                            retorno += this.costoPremium;
                        }
                        else if(((Pasajero)lista[i]).Clase == Clases.Turista)
                        {
                            retorno += this.costoTurista;
                        }
                    }
                }

            return retorno;
        }

        /// <summary>
        /// Se encarga de saber si el viaje tiene lo que el pasajero quiere
        /// </summary>

        public bool Requisitos(Pasajero pasajero)
        {
            bool retorno = true;

                if(pasajero.Casino == true && this.crucero.Casinos < 1)
                {
                    retorno = false;
                }

                if(pasajero.Piscina == true && this.crucero.Piscinas < 1)
                {
                    retorno = false;
                }

                if(pasajero.Gimnacio == true && this.crucero.Gimnacios < 1)
                {
                    retorno = false;
                }

            return retorno;
        }

        #endregion

        #region Operadores

        public static implicit operator Viaje(string[] viaje)
        {
            return new Viaje
            (
                int.Parse(viaje[0]),
                (CiudadesDePartida)int.Parse(viaje[1]),
                (Destino)int.Parse(viaje[2]),
                DateTime.Parse(viaje[3].ToString()),
                (Crucero)int.Parse(viaje[4]),
                int.Parse(viaje[5]),
                int.Parse(viaje[6]),
                double.Parse(viaje[7]),
                double.Parse(viaje[8]),
                int.Parse(viaje[9])
            ) ;
        }

        public static bool operator ==(Viaje viaje1, Viaje viaje2)
        {
            return (viaje1.Destino == viaje2.Destino && viaje1.fechaInicio.ToShortDateString() == viaje2.fechaInicio.ToShortDateString());
        }

        public static bool operator !=(Viaje viaje1, Viaje viaje2)
        {
            return !(viaje1==viaje2);
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.Append($"{this.id} - ");
            cadena.Append($"{((int)this.partida)} - ");
            cadena.Append($"{(int)this.destino} - ");
            cadena.Append($"{this.fechaInicio} - ");
            cadena.Append($"{this.crucero.ID} - ");
            cadena.Append($"{this.camarotesPremium} - ");
            cadena.Append($"{this.camarotesTurista} - ");
            cadena.Append($"{this.costoPremium} - ");
            cadena.Append($"{this.costoTurista} - ");
            cadena.Append($"{this.duracionDelViaje}");

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
        #endregion

    }
}
