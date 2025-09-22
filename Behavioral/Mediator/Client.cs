namespace ExampleDesignPatterns.Behavioral.Mediator;

public static class Client
{
    public static void Run()
    {
        // Создаем медиатор: это инициализирует всю систему
        var cafe = new CafeMediator();

        Console.WriteLine("=== Простая симуляция заказов в кафе ===");

        // Симулируем размещение заказа: запустит всю цепочку
        cafe.Customer.PlaceOrder("Coffee");
    }
}
