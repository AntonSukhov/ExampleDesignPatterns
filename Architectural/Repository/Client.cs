using ExampleDesignPatterns.Architectural.Repository.DbContexts;
using ExampleDesignPatterns.Architectural.Repository.Repositories;

namespace ExampleDesignPatterns.Architectural.Repository;

public static class Client
{
    public static async Task RunAsync()
    {
      var repository = CreateContractRepository();

       var contracts = await repository.GetAllAsync();

       
       foreach (var contract in contracts)
       {
           Console.WriteLine(contract);
       }


       await repository.RemoveAsync(10);
    }

    private static IContractRepository CreateContractRepository()
    {
        var dbContext = new ContractsDbContext();
        
        return new ContractRepository(dbContext);
    }
}
