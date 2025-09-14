namespace ExampleDesignPatterns.Structural.Proxy;

public class RemoteServiceProxy : IRemoteService
{
    private readonly IRemoteService _remoteService = new RemoteService();

    public string Request(string data)
    {
        Console.WriteLine("[Proxy] Установка соединения с удалённым сервисом...");
        Console.WriteLine("[Proxy] Отправка запроса на сервер...");

        var response = _remoteService.Request(data);

        Console.WriteLine("[Proxy] Получен ответ от сервера.");
        
        return response;
    }
}
