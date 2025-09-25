using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Брокер.
/// </summary>
/// <remarks>Брокер играет роль подписчика.</remarks>
public class Broker : IObserver<StockInfo>
{
    private readonly string _name;
    private IObservable<StockInfo>? _observable;

    public Broker(string name, IObservable<StockInfo> observable)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(observable);

        _name = name;
        _observable = observable;
        _observable.RegisterObserver(this);
    }

    public void Update(StockInfo data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Cny >= 12.5m)
            Console.WriteLine($"Брокер {_name} продает {nameof(data.Cny)};  Курс {nameof(data.Cny)}: {data.Cny}");
        else
            Console.WriteLine($"Брокер {_name} покупает {nameof(data.Cny)}; Курс {nameof(data.Cny)}: {data.Cny}");
    }

    public void StopTrade()
    {
        _observable?.UnregisterObserver(this);
        _observable = null;
    }
}
