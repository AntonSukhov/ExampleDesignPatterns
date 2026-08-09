using ExampleDesignPatterns.Architectural.UnitOfWork.DbContexts;
using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

/// <summary>
/// Реализация репозитория операции.
/// </summary>
public class OperationRepository : IOperationRepository
{
    private readonly ContractsDbContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр <see cref="OperationRepository"/>.
    /// </summary>
    /// <param name="dbContext">Контекст работы с БД договоров ГПД.</param>
    public  OperationRepository (
        ContractsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<OperationEntity>> GetAllAsync()
    {
        return await _dbContext.Operations.AsNoTracking()
                                            .OrderBy(p=>p.Id)
                                            .ToListAsync();                                   
    }

    /// <inheritdoc/>
    public async Task CreateAsync(OperationEntity operation)
    {
         await _dbContext.Operations.AddAsync(operation);
    }
}
