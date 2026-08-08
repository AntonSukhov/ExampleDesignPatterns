using ExampleDesignPatterns.Architectural.Repository.DbContexts;
using ExampleDesignPatterns.Architectural.Repository.Entities;

namespace ExampleDesignPatterns.Architectural.Repository.Repositories;

/// <summary>
/// Реализация репозитория договора.
/// </summary>
public class ContractRepository : IContractRepository
{
    private readonly ContractsDbContext _dbContext;

    public ContractRepository(ContractsDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<ContractEntity>> GetAllAsync()
    {     
        //Некоторый код, который должен использовать _dbContext;

        await Task.Delay(15);
        
        return 
        [
            new ContractEntity{ Id = 1, Number = "Д157-1", CreateDate = new DateTime (2026, 8, 6)}, 
            new ContractEntity{ Id = 2, Number = "Д10-12", CreateDate = new DateTime (2026, 1, 16)}, 
            new ContractEntity{ Id = 3, Number = "Д23-7", CreateDate = new DateTime (2026, 4, 20)}
        ];
    }

    /// <inheritdoc/>
    public async Task RemoveAsync(int contractId)
    {
        //Некоторый код, который должен использовать _dbContext;

        await Task.Delay(7);
    }
}
