using Autofac;
using ExampleDesignPatterns.Architectural.CQRS.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Exceptions;
using ExampleDesignPatterns.Architectural.CQRS.Handlers.Commands;

namespace ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Queries;

public class CommandDispatcher : ICommandDispatcher
{
     private readonly IComponentContext _componentContext;

    public CommandDispatcher(IComponentContext componentContext)
    {
        ArgumentNullException.ThrowIfNull(componentContext);

        _componentContext = componentContext;
    }
    
    /// <inheritdoc/>
    public void Execute<TCommand>(TCommand command) where TCommand : ICommand
    {
        ArgumentNullException.ThrowIfNull(command);

        var commandHandler = _componentContext.Resolve<ICommandHandler<TCommand>>()
            ?? throw new CommandHandlerNotFoundException("Не найден обработчик комманд");

        commandHandler.Execute(command);
    }
}
