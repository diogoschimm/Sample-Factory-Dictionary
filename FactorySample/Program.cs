using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace FactorySample
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var serviceProvedor = host.Services.CreateScope().ServiceProvider;

            var logisticaFactory = serviceProvedor.GetRequiredService<LogisticaFactory>();
            var nomeLogistica = "maritima";

            var logistica = logisticaFactory.GetLogistica(nomeLogistica);
            logistica.Entregar(new Entrega() { Local = "Cuiabá MT" });
             
            return host.RunAsync();
        }
        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddScoped<LogisticaFactory>();
                    services.AddScoped<LogisticaAerea>();
                    services.AddScoped<LogisticaMaritima>();
                    services.AddScoped<LogisticaRodoviaria>();
                });
        }
    }
}
