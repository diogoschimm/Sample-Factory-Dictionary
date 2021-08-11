using System;

namespace FactorySample
{
    public class LogisticaMaritima : ILogistica
    {
        public void Entregar(Entrega entrega)
        {
            Console.WriteLine($"Fazendo a entrega maritima: {entrega.Local}");
        }
    }
}
