using Entidades.Extensiones;
using Entidades.Listas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entidades.Archivos
{
    public static class SerializacionJSON<T> where T : class
    {
        private static StreamWriter escribir;
        private static StreamReader leer;
        private static string path;

        static SerializacionJSON()
        {
            if (!Directory.Exists("..\\Archivos\\Serializacion\\JSON"))
            {
                Directory.CreateDirectory("..\\Archivos\\Serializacion\\JSON");
            }

            SerializacionJSON<T>.path = "..\\Archivos\\Serializacion\\JSON\\";
        }

        /// <summary>
        /// Serializa la lista en el archivo .json que el pasaste como parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Serializar(string archivo, Almacenamiento<T> lista)
        {
            bool retorno = false;

            try
            {
               using(SerializacionJSON<T>.escribir = new StreamWriter(SerializacionJSON<T>.path+archivo))
               {

                    string serializado = JsonSerializer.Serialize(lista.Lista);

                    SerializacionJSON<T>.escribir.WriteLine(serializado);
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
                    using(SerializacionJSON<T>.leer = new StreamReader(SerializacionJSON<T>.path+archivo))
                    {
                        string serializado = SerializacionJSON<T>.leer.ReadToEnd();

                        retorno = JsonSerializer.Deserialize<List<T>>(serializado);   

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
