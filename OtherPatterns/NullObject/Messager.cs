namespace ExampleDesignPatterns.OtherPatterns.NullObject;

public class Messanger
{
    private readonly IMessageSender _messageSender;

    public Messanger(IMessageSender messageSender)
    {
        _messageSender = messageSender ?? new NullMessageSender();
    }

    public void SendMessage(string message)
    {
        _messageSender.Send(message);
    }
}
