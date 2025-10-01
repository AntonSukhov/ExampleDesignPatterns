using ExampleDesignPatterns.Architectural.CQRS.Queries;

namespace ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Queries;

/// <summary>
/// Диспетчер запросов.
/// </summary>
/// <remarks>По сигнатуре запроса находит в контейнере обработчиков запросов нужный обработчик и выполняет его.</remarks>
public interface IQueryDispatcher
{
    /// <summary>
    /// Выполняет обработку запроса с помощью найденного обработчика.
    /// </summary>
    /// <typeparam name="TQuery">Тип данных запроса.</typeparam>
    /// <typeparam name="TResult">Тип данных результата выполнения обработчика запроса.</typeparam>
    /// <param name="query">Запрос.</param>
    /// <returns>Результат выполнения обработчика запроса.</returns>
    public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
}
