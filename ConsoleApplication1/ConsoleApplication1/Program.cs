using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            string respuesta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Beep(15000, 3000);
            
            do
            {
                if (i == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Hola,mundo.¿Quiere salir de este bucle de saludos?Escriba 'sí' ");

                }
                if (i == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("¿Y qué quieres que haga?No tengo funciones.Introduzca 'sí para salir.");
                }
                if (i == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Qué pesao.Pues ahora cojo y me cierro");
                }
                respuesta = Console.ReadLine();
                i = i + 1;
            } while (respuesta != "sí" && i<4);
            Console.ReadLine();

        }
    }
}
