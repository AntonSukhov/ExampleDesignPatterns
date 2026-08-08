using ExampleDesignPatterns.Architectural.Repository.Entities;

namespace ExampleDesignPatterns.Architectural.Repository.Repositories;

/// <summary>
/// Репозиторий договора.
/// </summary>
public interface IContractRepository
{
    /// <summary>
    /// Ассинхронно получает все договора.
    /// </summary>
    /// <returns>Коллекция всех договоров.</returns>
    public Task<IReadOnlyCollection<ContractEntity>> GetAllAsync();

    /// <summary>
    /// Ассинхронно удаляет договор.
    /// </summary>
    /// <param name="contractId">ИД удаляемого договора</param>
    /// <returns>Результат выполнения удаления.</returns>
    public Task RemoveAsync(int contractId);
}
