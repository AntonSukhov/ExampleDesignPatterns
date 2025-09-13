
namespace ExampleDesignPatterns.Structural.Decorator;

public class EmailLogService : ILogService
{
    public void Log(Exception exception)
    {
        Console.WriteLine($"{DateTime.UtcNow:O} Отправляем текст ошибки {exception.Message} по почте.");
    }
}
