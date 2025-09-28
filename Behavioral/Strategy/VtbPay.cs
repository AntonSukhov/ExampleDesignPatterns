namespace ExampleDesignPatterns.Behavioral.Strategy;

public class VtbPay : IPaymentStrategy
{
    public string GetPaymentMethodName()
    {
        return "ВТБ Pay";
    }

    public void Pay(decimal amount)
    {
        //Тут некоторый код: скорее всего используется некоторое API ВТБ Pay

        Console.WriteLine($"{DateTime.UtcNow.ToString("G")} №{Guid.NewGuid()} Платёж {amount} {GetPaymentMethodName()}");
    }
}
