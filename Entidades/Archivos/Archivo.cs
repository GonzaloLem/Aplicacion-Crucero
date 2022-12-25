using Entidades.Extensiones;
using Entidades.Listas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Archivos
{
    public class Archivo<T> where T : class
    {
        private delegate T DeleagadoConvertir(string[] item);

        private StreamWriter escribir;
        private StreamReader leer;
        private string path;
        private DeleagadoConvertir convertir;

        private Archivo()
        {
            if (!Directory.Exists("..\\Archivos"))
            {
                Directory.CreateDirectory("..\\Archivos");
            }

            this.path = "..\\Archivos\\";
        }

        public Archivo(Func<string[], T> funcion) : this()
        {
            this.convertir = funcion.Invoke;
        }

        /// <summary>
        /// Se fija si el archivo que le pasaste existe, en caso de no existir se crea
        /// </summary>
        public static bool Averiguar(string ruta)
        {
            bool retorno = true;

                if(!File.Exists(ruta))
                {
                    retorno = false;
                }

            return retorno;
        }

        /// <summary>
        /// Agrega al archivo la lista que se le pase
        /// </summary>
        /// <returns></returns>
        public bool Agregar(string archivo, Almacenamiento<T> lista)
        {
            bool retorno = false;

            try
            {
                if (!Archivo<T>.Averiguar(this.path + archivo))
                {

                    this.escribir = new StreamWriter(this.path + archivo, true);

                    foreach (T item in lista.Lista)
                    {
                        this.escribir.WriteLine(item.ToString());
                    }

                }
                else
                {
                    this.Sobrescribir(archivo, lista);
                }
                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.escribir != null)
                {
                    this.escribir.Close();
                }
            }

            return retorno;
        }

        public bool Sobrescribir(string archivo, Almacenamiento<T> lista)
        {
            bool retorno = false;

                try
                {
                    using(this.escribir = new StreamWriter(this.path+archivo))
                    {
                        foreach(T item in lista.Lista)
                        {
                            this.escribir.WriteLine(item.ToString());
                        }
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            return retorno;
        }

        public Almacenamiento<T> Leer(string archivo)
        {
            Almacenamiento<T> retorno = new Almacenamiento<T>(2147483647);

                try
                {
                    if (Archivo<T>.Averiguar(this.path + archivo))
                    {
                        using (this.leer = new StreamReader(this.path + archivo))
                        {
                            string texto = null;
                            while ((texto = this.leer.ReadLine()) != null)
                            {
                                string[] objeto = texto.Split(" - ");

                                T item = this.convertir(objeto);

                                retorno += item;

                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            return retorno;
        }

        public string LeerHastaElFinal(string archivo)
        {
            string retorno = "";

                try
                {
                    using(this.leer = new StreamReader(this.path+archivo))
                    {
                        retorno = this.leer.ReadToEnd();
                    }
                }
                catch(Exception ex)
                {
                    Console.Write(ex.ToString());
                }

            return retorno;
        }

    }
}
