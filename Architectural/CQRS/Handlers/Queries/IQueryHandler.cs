using ExampleDesignPatterns.Architectural.CQRS.Queries;

namespace ExampleDesignPatterns.Architectural.CQRS.Handlers.Queries;

/// <summary>
/// Обработчик запроса.
/// </summary>
/// <typeparam name="TQuery">Тип данных запроса.</typeparam>
/// <typeparam name="TResult">Тип данных результата обработки запроса.</typeparam>
public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
{
    /// <summary>
    /// Выполняет обработку запроса.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <returns>Результат обработки запроса.</returns>
    TResult Execute(TQuery query);
}
