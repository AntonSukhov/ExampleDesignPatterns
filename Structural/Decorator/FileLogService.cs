
namespace ExampleDesignPatterns.Structural.Decorator;

public class FileLogService : ILogService
{
    public void Log(Exception exception)
    {
        Console.WriteLine($"{DateTime.UtcNow:O} Сохраняем текст ошибки {exception.Message} в файл.");
    }
}
