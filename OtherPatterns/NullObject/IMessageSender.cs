namespace ExampleDesignPatterns.OtherPatterns.NullObject;

/// <summary>
/// Отправитель сообщений.
/// </summary>
public interface IMessageSender
{
    /// <summary>
    /// Отправляет сообщение.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public void Send(string message);
}
