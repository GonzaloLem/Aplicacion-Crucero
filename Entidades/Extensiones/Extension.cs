using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extensiones
{
    public static class Extension
    {

        public static byte Conversor(this byte byt, bool booleano)
        {
            byte retorno = 0;

            if (booleano == true)
            {
                retorno = 1;
            }

            return retorno;
        }

        public static bool Validar(this string str, string cadena)
        {
            bool retorno = false;

            if (str.Length >= cadena.Length)
            {
                string comp = null;

                for (int i = 0; i < cadena.Length; i++)
                {
                    comp += str[i];
                }

                    if(comp == cadena)
                    {
                        retorno = true;
                    }
            }

            return retorno;
        }

        public static string Hasta(this string str, char caracter)
        {
            string retorno = null;

                for(int i=0;i<str.Length;i++)
                {
                    if(str[i] == caracter)
                    {
                        break;
                    }
                    retorno += str[i];

                }

            return retorno;
        }

        public static int Contar(this string str, string cadena, char caracter)
        {
            int retorno = -1;

                for(int i=0;i<cadena.Length;i++)
                {
                    if(cadena[i] == caracter)
                    {
                        retorno = i;
                        break;
                    }
                }

            return retorno;
        }

        public static string Rehacer(this string str, string cadena, int index)
        {
            string retorno = null;

                for(int i=index; i<cadena.Length;i++)
                {
                    retorno += cadena[i];
                }

            return retorno;
        }

        public static string Rehacer(this string str, int index)
        {
            string retorno = null;

            for (int i = index; i < str.Length; i++)
            {
                retorno += str[i];
            }

            return retorno;
        }

    }
}
