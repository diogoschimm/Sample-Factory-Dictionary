# Sample-Factory-Dictionary
Exemplo de Factory com Dictionary

## Factory

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
