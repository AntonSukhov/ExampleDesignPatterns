using ExampleDesignPatterns.Architectural.CQRS.Commands;

namespace ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Commands;

/// <summary>
/// Диспетчер команд.
/// </summary>
/// <remarks>По сигнатуре команды находит в контейнере обработчиков команд нужный обработчик и выполняет его.</remarks>

public interface ICommandDispatcher
{
    /// <summary>
    /// Выполняет обработку команды с помощью найденного обработчика.
    /// </summary>
    /// <typeparam name="TCommand">Тип данных команды.</typeparam>
    /// <param name="command">Команда.</param>
    public void Execute<TCommand>(TCommand command) where TCommand : ICommand;
}
