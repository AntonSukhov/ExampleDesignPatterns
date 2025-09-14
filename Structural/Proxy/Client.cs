namespace ExampleDesignPatterns.Structural.Proxy;

public static class Client
{
    public static void Run()
    {
        IRemoteService proxy = new RemoteServiceProxy();
        var response = proxy.Request("{id:10}");

        Console.WriteLine(response);     
    }
}
