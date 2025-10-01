namespace ExampleDesignPatterns.OtherPatterns.NullObject;

public static class Client
{
    public static void Run()
    {
        var message = "Hello World";
        var messageSender = new EmailMessageSender();
        var messager1 = new Messanger(messageSender);
        var messager2 = new Messanger(null);

        messager1.SendMessage(message);
        messager2.SendMessage(message);
    }
}
