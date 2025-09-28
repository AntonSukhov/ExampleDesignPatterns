namespace ExampleDesignPatterns.Behavioral.Strategy;

/// <summary>
/// Платеж с помощью PayPal.
/// </summary>
public class PayPal : IPaymentStrategy
{
    public string GetPaymentMethodName()
    {
        return "PayPal";
    }

    public void Pay(decimal amount)
    {
        //Тут некоторый код: скорее всего используется некоторое API PayPal
        Console.WriteLine($"{DateTime.UtcNow.ToString("G")} №{Random.Shared.Next(1, 99999)} Платёж {amount} {GetPaymentMethodName()}");
    }
}
