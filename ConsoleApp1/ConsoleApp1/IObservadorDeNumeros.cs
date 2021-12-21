using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IObservadorDeNumeros
    {
        void ImprimirNumero(int numeroAlAzar, long factorial);
        void ImprimirSumaFinal(long sumaTotal);
    }
}
