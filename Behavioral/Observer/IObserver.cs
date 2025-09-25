namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Подписчик.
/// </summary>
/// <typeparam name="T">Тип данных информации для подписчика.</typeparam>
public interface IObserver<in T>
{
    /// <summary>
    /// Обновление состояния подписчика.
    /// </summary>
    /// <param name="data">Данные для подписчика от издателя.</param>
    public void Update(T data);
}
