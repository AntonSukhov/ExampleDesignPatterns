using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class ExecuteErrorSolutionHandler : HandlerBase
{
    public override void Handle(ParametersContext parametersContext)
    {
        ArgumentNullException.ThrowIfNull(parametersContext);

        var error = parametersContext.GetParameterValueAsClass<Error>(ConstantsService.Error)
            ?? throw new CustomException(ConstantsService.ExceptionMessage);

        Console.WriteLine($"Выполняем найденное решение ошибки:{Environment.NewLine}{error}");

        _nextHandler?.Handle(parametersContext);
    }
}
