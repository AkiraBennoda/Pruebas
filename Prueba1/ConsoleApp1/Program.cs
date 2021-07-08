using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static List<Double> bin = new List<double>();


        static void Main(string[] args)
        {
            String numero;
            int binario;
            Console.WriteLine("Proporciona un numero entero para obtenr su binario:");
            Console.WriteLine();
            numero = Console.ReadLine();

            binario = Convert.ToInt32(numero);
            
            ConvierteEntero(binario);
        }

        private static void ConvierteEntero(int numero)
        {
   
            int ini = numero;
            int residuo = 0;
            string cadBin = "";

            while (numero > 0)
            {
                residuo = numero % 2;
                numero  = numero / 2;
                cadBin += residuo.ToString(); 

            }
         

            Console.WriteLine($"\n Hola, el binario de {ini} es { Invertir(cadBin)}");
            Console.ReadKey();

        }

        private static string Invertir(string cadBin)
        {
            char[] arrBin = cadBin.ToCharArray();
            Array.Reverse(arrBin);
            return new string(arrBin);
        }
    }
}
