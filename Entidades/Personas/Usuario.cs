using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Personas
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string usuario;
        private string contraseña;
        private Roles rol;

        public Usuario(int id, string nombre, string usuario, string contraseña, Roles rol)
        {
            this.id = id;
            this.nombre = nombre;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.rol = rol;
        }

        public int ID { get => this.id; }
        public string Nombre { get => this.nombre; }
        public string User { get => this.usuario; }
        public string Contraseña { get => this.contraseña; }
        public Roles Rol { get => this.rol; }

        public static bool operator ==(Usuario user1, Usuario user2)
        {
            return (user1.id == user2.id);
        }

        public static bool operator !=(Usuario user1, Usuario user2)
        {
            return !(user1==user2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

                if(obj is Usuario)
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
