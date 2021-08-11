using System;

namespace FactorySample
{
    public class LogisticaRodoviaria : ILogistica
    {
        public void Entregar(Entrega entrega)
        {
            Console.WriteLine($"Fazendo a entrega rodoviaria: {entrega.Local}");
        }
    }
}
