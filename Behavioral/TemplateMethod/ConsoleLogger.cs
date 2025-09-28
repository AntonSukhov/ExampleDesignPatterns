
namespace ExampleDesignPatterns.Behavioral.TemplateMethod;

public class ConsoleLogger : ILogger
{
    public void Log(Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
}
