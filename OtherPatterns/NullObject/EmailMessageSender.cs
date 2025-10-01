namespace ExampleDesignPatterns.OtherPatterns.NullObject;

/// <summary>
/// Отправитель сообщений по электронной почте.
/// </summary>
public class EmailMessageSender : IMessageSender
{
    /// <inheritdoc/>
    public void Send(string message)
    {
        Console.WriteLine($"Отправляет сообщение: {message} по электронной почте");
    }
}
