namespace ExampleDesignPatterns.Structural.Decorator;

public static class Client
{
    public static void Run()
    {
        try
        {
            throw new FileNotFoundException();
        }
        catch (Exception exception)
        {

            ILogService fileLogService = new FileLogService();
            ILogService dbLogService = new DataBaseLogService();
            ILogService emailLogService = new EmailLogService();
            ILogService logServiceDecorator = new LogServiceDecorator(fileLogService);
            var logServiceDecoratorSecond = new LogServiceDecorator(logServiceDecorator);

            fileLogService.Log(exception);
            logServiceDecorator.Log(exception);
            logServiceDecoratorSecond.Log(exception);

            logServiceDecoratorSecond.SetInnerLogService(dbLogService);
            logServiceDecoratorSecond.Log(exception);

            logServiceDecoratorSecond.SetInnerLogService(emailLogService);
            logServiceDecoratorSecond.Log(exception);
        }

    }
}
