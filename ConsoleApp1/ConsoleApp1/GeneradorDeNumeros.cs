using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GeneradorDeNumeros
    {
        static int[] numerosAlAzar = new int[7];
        static object bandera = new object();
        static long[] factoriales = new long[7];
        long suma = 0;
        
        private List<IObservadorDeNumeros> observadores;
        public GeneradorDeNumeros()
        {
            observadores = new List<IObservadorDeNumeros>();
        }
        
        public void Suscribirse(IObservadorDeNumeros unObservador)
        {
            observadores.Add(unObservador);
        }
        public void Desuscribirse(IObservadorDeNumeros unObservador)
        {
            observadores.Remove(unObservador);
        }


        public void GenerarXNumeros()
        {
            for (int i = 0; i < 7; i++)
            {
              
                Random nroAlAzar = new Random();
                int nro = nroAlAzar.Next(1,10);
                numerosAlAzar[i] = nro;
                Thread.Sleep(100);
                Monitor.Enter(bandera);
                Monitor.Pulse(bandera);                
                Monitor.Wait(bandera);

                Monitor.Exit(bandera);
            }
        }

        public void GenerarFactoriales()
        {
            for (int i = 0; i < 7; i++)
            {
                Monitor.Enter(bandera);
                Monitor.Wait(bandera);

                factoriales[i] = CalcularFactorial(numerosAlAzar[i]);

                suma = suma + factoriales[i];
                observadores.ForEach(item => item.ImprimirNumero(numerosAlAzar[i], factoriales[i]));
                Monitor.Pulse(bandera);
                Monitor.Exit(bandera);
            }
            observadores.ForEach(item => item.ImprimirSumaFinal(suma));
        }


        public int CalcularFactorial(int numero)
        {
            int rta = numero;
            while (numero > 1)
            {
                numero--;
                rta = numero * rta;
            }
            return rta;
        }
    }
}
