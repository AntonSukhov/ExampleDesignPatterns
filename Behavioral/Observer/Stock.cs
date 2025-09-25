namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Валютная биржа.
/// </summary>
/// <remarks>Биржа играет роль издателя.</remarks>
public class Stock : IObservable<StockInfo>
{
    private readonly StockInfo _stockInfo = new();
    private readonly IList<IObserver<StockInfo>> _observers = [];

    /// <<inheritdoc/>
    public void NotifyObservers()
    {
        foreach (var item in _observers)
        {
            item.Update(_stockInfo);
        }
    }

    /// <<inheritdoc/>
    public void RegisterObserver(IObserver<StockInfo> observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        _observers.Add(observer);
    }

    /// <<inheritdoc/>
    public void UnregisterObserver(IObserver<StockInfo> observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        _observers.Remove(observer);
    }

     /// <summary>
     /// Запуск торгов валютой.
     /// </summary>
    public void ExecuteTrade()
    {
        _stockInfo.Cny = Random.Shared.Next(11, 14) + 0.05m;

        NotifyObservers();
    }
}
