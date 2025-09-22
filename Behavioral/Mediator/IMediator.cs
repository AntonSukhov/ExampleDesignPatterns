namespace ExampleDesignPatterns.Behavioral.Mediator;

/// <summary>
/// Посредник, обеспечивающий взаимодействие множества объектов без необходимости ссылаться друг на друга.
/// </summary>
public interface IMediator
{
    /// <summary>
    ///  Уведомление посредника о возникновении события у отправителя.
    /// </summary>
    /// <param name="sender">Отправитель уведомления.</param>
    /// <param name="eventName">Название события</param>
    /// <param name="data">Дополнительные данные.</param>
    public void Notify(Colleague sender, string eventName, string data);
}
