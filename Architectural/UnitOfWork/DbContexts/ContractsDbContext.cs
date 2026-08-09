using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.DbContexts;

/// <summary>
/// Контекст базы данных договоров.
/// </summary>
public class ContractsDbContext: DbContext
{
    /// <summary>
    /// Получает или задает набор единиц работ.
    /// </summary>
    public DbSet<WorkUnitEntity> WorkUnits { get; set; }

    /// <summary>
    /// Получает или задает набор видов работ.
    /// </summary>
    public DbSet<WorkTypeEntity> WorkTypes { get; set; }

    /// <summary>
    /// Получает или задает набор операций.
    /// </summary>
    public DbSet<OperationEntity> Operations { get; set; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="ContractsDbContext"/>.
    /// </summary>
    /// <param name="options">Опции контекста работы с базой данных договоров.</param>
    public ContractsDbContext(DbContextOptions options): base(options) {}
}
