using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class RegisterErrorHandler : HandlerBase
{
    public override void Handle(ParametersContext parametersContext)
    {
        ArgumentNullException.ThrowIfNull(parametersContext);

        var error = parametersContext.GetParameterValueAsClass<Error>(ConstantsService.Error)
            ?? throw new CustomException(ConstantsService.ExceptionMessage);

        Console.WriteLine($"Регистрируем ошибку:{Environment.NewLine}{error}");
        error.RegistrationDate = DateTime.UtcNow;

        _nextHandler?.Handle(parametersContext);
    }
}
