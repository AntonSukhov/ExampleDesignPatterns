namespace ExampleDesignPatterns.Structural.Proxy;

/// <summary>
/// Реализация удаленного сервиса.
/// </summary>
public class RemoteService : IRemoteService
{
    public string Request(string data)
    {
        Console.WriteLine($"[RemoteService] Обработка запроса: {data}");
           
        return $"Ответ на '{data}'";
    }
}
