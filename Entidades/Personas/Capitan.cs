using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Capitan : Persona
    {

        private int horasDeViaje;
        private int viajesRealizadosConLaEmpresa;

        public Capitan() :base(null, null, 0, 0, 0, 0)
        {
            this.horasDeViaje = 0;
            this.viajesRealizadosConLaEmpresa = 0;
        }
        
        public Capitan(string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, int horasViaje) : base(nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.horasDeViaje = horasViaje;
            this.viajesRealizadosConLaEmpresa = 0;
        }

        public Capitan(int id, string nombre, string apellido, int edad, int dni, Nacionalidades nacionalidad, double celular, int horasViaje, int viajesConLaEmpresa) : base(id, nombre, apellido, edad, dni, nacionalidad, celular)
        {
            this.horasDeViaje = horasViaje;
            this.viajesRealizadosConLaEmpresa = viajesConLaEmpresa;
        }

        public Capitan(int horasDeViaje, int viajesRelizadosConLaEmpresa) : base(null, null, -1, -1, Nacionalidades.Alemania, -1)
        {
            this.horasDeViaje = horasDeViaje;
            this.viajesRealizadosConLaEmpresa = viajesRelizadosConLaEmpresa;
        }
        public int Horas { get => this.horasDeViaje; }
        public int Viajes { get => this.viajesRealizadosConLaEmpresa; }
        public override string Tipo { get => "Capitan"; }
        public override Roles Rol { get => Roles.Capitan; }
        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.AppendLine($"Horas de Viajes: {this.horasDeViaje}");
            cadena.AppendLine($"Viajes con la Empresa: {this.viajesRealizadosConLaEmpresa}");

            return cadena.ToString();
        }



    }
}
