using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Strategy;

public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        SetPaymentStrategy(paymentStrategy);
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        ArgumentNullException.ThrowIfNull(paymentStrategy);

        _paymentStrategy = paymentStrategy;
    }

    public void Pay(decimal amount)
    {
        if (amount <= 0m)
            throw new CustomException($"Значение платежа должно быть больше нуля");


        _paymentStrategy.Pay(amount);

        Console.WriteLine($"Платёж в размере {amount} руб. выполнен успешно с помощью {_paymentStrategy.GetPaymentMethodName()}");
    }
}
