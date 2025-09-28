namespace ExampleDesignPatterns.Behavioral.TemplateMethod;

public static class Client
{
    public static void Run()
    {
        ILogger logger = new ConsoleLogger();
        BaseOrderCostCalculator orderCostCalculator = new OrderCostCalculator(logger);

        var orderProducts = new[] {
            new Product { Id = 1, Name = "Товар1", Cost = 1200m, Count = 1 },
            new Product { Id = 2, Name = "Товар2", Cost = 500m, Count = 5 },
            new Product { Id = 3, Name = "Товар3", Cost = 690m, Count = 2 },
            new Product { Id = 4, Name = "Товар4", Cost = 100m, Count = 10 },
            };
        var shopperEmail = "user189@mail.ru";

        var orderCost = orderCostCalculator.Сalculate(shopperEmail, orderProducts);

        Console.WriteLine(orderCost);
    }
}
