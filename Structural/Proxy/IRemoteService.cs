namespace ExampleDesignPatterns.Structural.Proxy;

/// <summary>
/// Удаленный сервис.
/// </summary>
public interface IRemoteService
{
    public string Request(string data);
}
