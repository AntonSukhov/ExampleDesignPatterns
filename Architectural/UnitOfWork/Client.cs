using ExampleDesignPatterns.Architectural.UnitOfWork.DbContexts;
using ExampleDesignPatterns.Architectural.UnitOfWork.Entities;
using ExampleDesignPatterns.Architectural.UnitOfWork.Repositories;
using ExampleDesignPatterns.Architectural.UnitOfWork.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace ExampleDesignPatterns.Architectural.UnitOfWork;

public static class Client
{
    public static async Task RunAsync()
    {
        var connectionString = "Host=localhost;Port=5432;Database=DbContracts;Username=postgres;Password=sa";
        
        var workType = new WorkTypeShortEntity
        {
            Id = Guid.NewGuid(),
            Name = "Тестовый вид работ 1913"
        };

        var operation = new OperationEntity
        {
            Id =  Guid.NewGuid(),
            Name = "Add",
            CreatedAt = DateTimeOffset.UtcNow
        };

        using(var unityOfWork = CreateUnityOfWork(connectionString))
        {
            await unityOfWork.WorkTypeRepository.CreateAsync(workType);

            await unityOfWork.OperationRepository.CreateAsync(operation);

            await unityOfWork.SaveChangesAsync();
        }
    }

    private static IUnitOfWork CreateUnityOfWork(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContractsDbContext>();
        var options = optionsBuilder.UseNpgsql(connectionString).Options;
        var dbContext = new ContractsDbContext(options);

        var workTypeRepository = new WorkTypeRepository(dbContext);
        var operationRepository = new OperationRepository(dbContext);

        var unityOfWork = new UnitOfWorks.UnitOfWork(dbContext, workTypeRepository, 
            operationRepository);

        return unityOfWork;
    }
}
