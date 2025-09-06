namespace ExampleDesignPatterns.Generating.Prototype;

public static class Client
{
    public static void Run()
    {
        var contract = new Contract
        {
            Id = 1,
            CreateDate = DateTime.UtcNow,
            Number = "Д7770-01",
            TotalAmount = 100000m,
            Items =
            [
                new ContractItem {Id = 1, Count = 50, Description = "Скобы"},
                new ContractItem {Id = 2, Count = 100, Description = "Рейки"},
                new ContractItem {Id = 3, Count = 1000, Description = "Винтов"}
            ]
        };

        var contractClone = contract.Clone();

        Console.WriteLine(contractClone);

    }
}
