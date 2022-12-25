using Entidades.Listas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Archivos
{
    public static class SerializacionXML<T> where T : class
    {
        private static StreamWriter escribir;
        private static StreamReader leer;
        private static XmlSerializer serializar;
        private static string path;

        static SerializacionXML()
        {
            if (!Directory.Exists("..\\Archivos\\Serializacion\\XML"))
            {
                Directory.CreateDirectory("..\\Archivos\\Serializacion\\XML");
            }

            SerializacionXML<T>.path = "..\\Archivos\\Serializacion\\XML\\";
        }

        public static bool Serializar(string archivo, Almacenamiento<T> lista)
        {
            bool retorno = false;

                try
                {
                    using(SerializacionXML<T>.escribir = new StreamWriter(SerializacionXML<T>.path+archivo))
                    {
                        SerializacionXML<T>.serializar = new XmlSerializer(typeof(List<T>));

                        SerializacionXML<T>.serializar.Serialize(SerializacionXML<T>.escribir, lista.Lista);

                        retorno = true;
                    }
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }

            return retorno;
        }

        public static Almacenamiento<T> Deserializar(string archivo)
        {
            Almacenamiento<T> retorno = new Almacenamiento<T>(2147483647);

                try
                {
                    using(SerializacionXML<T>.leer = new StreamReader(SerializacionXML<T>.path+archivo))
                    {
                        SerializacionXML<T>.serializar = new XmlSerializer(typeof(List<T>));

                        retorno = (List<T>)SerializacionXML<T>.serializar.Deserialize(SerializacionXML<T>.leer);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            return retorno;
        }

    }
}
