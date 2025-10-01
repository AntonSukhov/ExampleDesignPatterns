using ExampleDesignPatterns.Architectural.CQRS.Commands;

namespace ExampleDesignPatterns.Architectural.CQRS.Handlers.Commands;

/// <summary>
/// Обработчик команды.
/// </summary>
/// <typeparam name="TCommand">Тип данных команда.</typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    /// <summary>
    /// Выполняет обработку команды.
    /// </summary>
    /// <param name="command">Команда.</param>
    public void Execute(TCommand command);
}
