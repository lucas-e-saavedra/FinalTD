using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Observador observador = new Observador();
            GeneradorDeNumeros numeros = new GeneradorDeNumeros();
            numeros.Suscribirse(observador);

            Thread th1 = new Thread(numeros.GenerarXNumeros);
            th1.Name = "Hilo 1";
            
            Thread th2 = new Thread(numeros.GenerarFactoriales);
            th2.Name = "Hilo 2";

            th1.Start();
            th2.Start();

            Console.ReadKey();

            
        }

        class Observador : IObservadorDeNumeros
        {
            public void ImprimirNumero(int numeroAlAzar, long factorial)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"El factorial de {numeroAlAzar} es: {factorial}");
            }

            public void ImprimirSumaFinal(long sumaTotal)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"La suma total es {sumaTotal}");
            }
        }
    }
}
