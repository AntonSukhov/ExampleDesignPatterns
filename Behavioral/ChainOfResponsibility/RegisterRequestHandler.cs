using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class RegisterRequestHandler : HandlerBase
{
    public override void Handle(ParametersContext parametersContext)
    {
        ArgumentNullException.ThrowIfNull(parametersContext);

        var request = parametersContext.GetParameterValueAsClass<Request>(ConstantsService.RequestName);

        if (request == null)
        {
            throw new CustomException($"{nameof(Request)} не Null, но не содержит входных данных");
        }

        

    }
}
