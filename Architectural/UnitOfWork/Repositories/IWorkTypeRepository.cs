using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

// <summary>
/// Репозиторий видов работ.
/// </summary>
public interface IWorkTypeRepository
{
    /// <summary>
    /// Предоставляет все виды работ.
    /// </summary>
    /// <returns>Виды работ.</returns>
    Task<IReadOnlyCollection<WorkTypeEntity>> GetAllAsync();

    /// <summary>
    /// Создаёт вид работ.
    /// </summary>
    /// <param name="workType">Вид работ.</param>
    /// <returns/>
    Task CreateAsync(WorkTypeShortEntity workType);

}