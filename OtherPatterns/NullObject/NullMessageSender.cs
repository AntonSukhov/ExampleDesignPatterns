namespace ExampleDesignPatterns.OtherPatterns.NullObject;

/// <summary>
/// Пустой отправитель сообщений.
/// </summary>
public class NullMessageSender : IMessageSender
{
    public void Send(string message)
    {
        //ничего не делает
    }
}
