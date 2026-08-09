using ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.UnitOfWorks;

public interface IUnitOfWork: IDisposable
{
    /// <summary>
    /// Получает репозиторий вида работ.
    /// </summary>
    public IWorkTypeRepository WorkTypeRepository { get; }

    /// <summary>
    /// Получает репозиторий операции.
    /// </summary>
    public IOperationRepository OperationRepository { get; }

    /// <summary>
    /// Асинхронное сохранение изменений.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены выполнения метода.</param>
    /// <returns></returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);

}
