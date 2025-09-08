namespace ExampleDesignPatterns.Structural.Adapter;

/// <summary>
/// Адаптер внешнего платежного сервиса.
/// Используется наследование вместо отношения ассоциации с внешним сервисом.
/// </summary>
public class PaymentServiceAdapter : PaymentService, IPaymentTerminal
{
    public void Pay(decimal amount, string payer)
    {
        MakePayment((double)amount, payer);
    }
}
