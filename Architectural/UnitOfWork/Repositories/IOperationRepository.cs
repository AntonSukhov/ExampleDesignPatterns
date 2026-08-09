using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

// <summary>
/// Репозиторий операций.
/// </summary>
public interface IOperationRepository
{
    /// <summary>
    /// Предоставляет все операции.
    /// </summary>
    /// <returns>Операции.</returns>
    Task<IReadOnlyCollection<OperationEntity>> GetAllAsync();

    /// <summary>
    /// Создаёт операцию.
    /// </summary>
    /// <param name="operation">Операция.</param>
    /// <returns/>
    Task CreateAsync(OperationEntity operation);
}
