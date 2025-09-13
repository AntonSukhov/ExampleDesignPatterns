
namespace ExampleDesignPatterns.Structural.Decorator;

public class LogServiceDecorator : ILogService
{
    private ILogService? _logService;

    public LogServiceDecorator()
    {
    }

    public LogServiceDecorator(ILogService logService)
    {
        _logService = logService;
    }

    public void Log(Exception exception)
    {
        var message = $"{DateTime.UtcNow:O} Протоколируем тест ошибки {exception.Message}";
        message = _logService != null ? $"{message} и выполняем следующие дополнительные действия:" : message;

        Console.WriteLine(message);
        _logService?.Log(exception);
    }

    public void SetInnerLogService(ILogService logService)
    {
        _logService = logService;
    }
}
