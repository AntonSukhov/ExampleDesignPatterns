namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Издатель.
/// </summary>
public interface IObservable<out T>
{
    /// <summary>
    /// Регистрирует наблюдателя.
    /// </summary>
    /// <param name="observer">Наблюдатель.</param>
    void RegisterObserver(IObserver<T> observer);

    /// <summary>
    /// Удаляет зарегистрированного наблюдателя.
    /// </summary>
    /// <param name="observer">Наблюдатель</param>
    void UnregisterObserver(IObserver<T> observer);

    /// <summary>
    /// Уведомление зарегистрированных наблюдателей.
    /// </summary>
    void NotifyObservers();
}
