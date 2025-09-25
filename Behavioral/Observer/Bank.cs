namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Банк.
/// </summary>
/// <remarks>Банк играет роль подписчика.</remarks>
public class Bank : IObserver<StockInfo>
{
    private readonly string _name;

    private readonly IObservable<StockInfo> _observable;

    public Bank(string name, IObservable<StockInfo> observable)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(observable);

        _name = name;
        _observable = observable;
        _observable.RegisterObserver(this); //Подписчик регистрирует сам себя с помощью вызова метода издателя.
    }

    public void Update(StockInfo data)
    {
        ArgumentNullException.ThrowIfNull(data);

        if (data.Cny > 13m)
            Console.WriteLine($"Банк {_name} продает {nameof(data.Cny)};  Курс {nameof(data.Cny)}: {data.Cny}");
        else
            Console.WriteLine($"Банк {_name} покупает {nameof(data.Cny)}; Курс {nameof(data.Cny)}: {data.Cny}");

    }
}
