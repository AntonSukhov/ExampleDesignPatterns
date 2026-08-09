using ExampleDesignPatterns.Architectural.UnitOfWork.DbContexts;
using ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;

namespace ExampleDesignPatterns.Architectural.UnitOfWork.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly ContractsDbContext _dbContext;
    private readonly IWorkTypeRepository _workTypeRepository;
    private readonly IOperationRepository _operationRepository;

    public IWorkTypeRepository WorkTypeRepository  => _workTypeRepository; 
    public IOperationRepository OperationRepository  => _operationRepository;

    public UnitOfWork(
        ContractsDbContext dbContext,
        IWorkTypeRepository workTypeRepository, 
        IOperationRepository operationRepository)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        ArgumentNullException.ThrowIfNull(workTypeRepository, nameof(workTypeRepository));
        ArgumentNullException.ThrowIfNull(operationRepository, nameof(operationRepository));

        _dbContext = dbContext;
        _workTypeRepository = workTypeRepository;
        _operationRepository = operationRepository;
    }

    /// <inheritdoc/>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    // <inheritdoc/>
    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
