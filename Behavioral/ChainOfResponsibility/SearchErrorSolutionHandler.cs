using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class SearchErrorSolutionHandler : HandlerBase
{
    public override void Handle(ParametersContext parametersContext)
    {
        ArgumentNullException.ThrowIfNull(parametersContext);

        var error = parametersContext.GetParameterValueAsClass<Error>(ConstantsService.Error)
            ?? throw new CustomException(ConstantsService.ExceptionMessage);

        Console.WriteLine($"Ищем решение ошибки:{Environment.NewLine}{error}");

        error.Solved = Random.Shared.Next(0, 1) == 1;

        if (error.Solved)
            _nextHandler?.Handle(parametersContext);
            
        _nextAlternativeHandler?.Handle(parametersContext);
    }
}
