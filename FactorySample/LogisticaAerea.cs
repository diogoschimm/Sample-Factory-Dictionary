using System;

namespace FactorySample
{
    public class LogisticaAerea : ILogistica
    {
        public void Entregar(Entrega entrega)
        {
            Console.WriteLine($"Fazendo a entrega aerea: {entrega.Local}");
        }
    }
}
