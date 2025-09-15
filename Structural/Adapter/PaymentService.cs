using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Structural.Adapter;

/// <summary>
/// Внешний платежный сервис.
/// </summary>
public class PaymentService
{

    /// <summary>
    /// Делает оплату.
    /// </summary>
    /// <param name="amount">Сумма оплаты.</param>
    /// <param name="payer">Плательщик.</param>
    /// <exception cref="CustomException"></exception>
    public void MakePayment(double amount, string payer)
    {
        if (amount <= 0)
        {
            throw new CustomException($"Недопустимое значение {nameof(amount)}: {amount}");
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(payer);

        Console.WriteLine($"Платёж от {DateTime.UtcNow} выполнен {payer} на сумму {amount}руб.");
    }
}
