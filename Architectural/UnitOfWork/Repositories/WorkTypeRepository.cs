using ExampleDesignPatterns.Architectural.UnitOfWork.DbContexts;
using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

/// <summary>
/// Реализация репозитория вида работ.
/// </summary>
public class WorkTypeRepository : IWorkTypeRepository
{
    private readonly ContractsDbContext _dbContext;

    /// <summary>
    /// Инициализирует экземпляр <see cref="WorkTypeRepository"/>.
    /// </summary>
    /// <param name="dbContext">Контекст работы с БД договоров ГПД.</param>
    public  WorkTypeRepository(
        ContractsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

        _dbContext = dbContext;
    }
    

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<WorkTypeEntity>> GetAllAsync()
    {
        return await _dbContext.WorkTypes.AsNoTracking()
                                         .Include(p => p.WorkUnit)
                                         .OrderBy(p => p.Id)
                                         .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task CreateAsync(WorkTypeShortEntity workType)
    {
        var workTypeEntity = MapToEntity(workType);

        await _dbContext.WorkTypes.AddAsync(workTypeEntity);
    }
   
    private static WorkTypeEntity MapToEntity(WorkTypeShortEntity workType)
    {
        return new WorkTypeEntity 
        { 
            Id = workType.Id, 
            Name = workType.Name, 
            WorkUnitId = workType.WorkUnitId
        };
    }
}