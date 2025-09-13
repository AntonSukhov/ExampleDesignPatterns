
namespace ExampleDesignPatterns.Structural.Decorator;

public class DataBaseLogService : ILogService
{
    public void Log(Exception exception)
    {
        Console.WriteLine($"{DateTime.UtcNow:O} Сохраняем текст ошибки {exception.Message} в таблицу базы данных.");
    }
}
