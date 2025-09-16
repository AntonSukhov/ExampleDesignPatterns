using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class FinishWorksHandler : HandlerBase
{
    public override void Handle(ParametersContext parametersContext)
    {
        ArgumentNullException.ThrowIfNull(parametersContext);

        var error = parametersContext.GetParameterValueAsClass<Error>(ConstantsService.Error)
            ?? throw new CustomException(ConstantsService.ExceptionMessage);

        error.CloseDate = DateTime.UtcNow;

        Console.WriteLine($"Завершена обработка ошибки:{Environment.NewLine}{error}");
    }
}
