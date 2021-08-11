# Sample-Factory-Dictionary
Exemplo de Factory com Dictionary

## Factory

Utilizamos um Dictionary para armazenar pelo nome da logistica o tipo de logistica, o obtemos o tipo de logistica a partir da chave.

```c#
  public class LogisticaFactory
  {
      private readonly IServiceProvider _serviceProvider;

      public LogisticaFactory(IServiceProvider serviceProvider)
      {
          this._serviceProvider = serviceProvider;
      }
      private readonly Dictionary<string, Type> Tipos = new Dictionary<string, Type>
      {
          {"maritima", typeof(LogisticaMaritima) },
          {"rodoviaria", typeof(LogisticaRodoviaria) },
          {"aerea", typeof(LogisticaAerea ) }
      };

      public ILogistica GetLogistica(string logistica)
      {
          return (ILogistica)_serviceProvider.GetService(Tipos[logistica]);
      }
  }
```

## Programa principal

```c#
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
```
