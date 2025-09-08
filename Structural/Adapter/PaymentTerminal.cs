namespace ExampleDesignPatterns.Structural.Adapter;

public class PaymentTerminal : IPaymentTerminal
{
    public void Pay(decimal amount, string payer)
    {
        if (amount <= 0)
        {
            throw new PaymentException($"Значение {amount} для {nameof(amount)} недопустимо.");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(payer);

        Console.WriteLine($"Лицо ${payer} выполнило {DateTime.UtcNow} платеж на сумму {amount}руб.");
    }
}
