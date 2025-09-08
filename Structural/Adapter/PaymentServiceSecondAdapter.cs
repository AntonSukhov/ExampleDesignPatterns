namespace ExampleDesignPatterns.Structural.Adapter;


/// <summary>
/// Адаптер внешнего платежного сервиса.
/// Используется accоциация с внешним сервисом вместо наследование.
/// </summary>
public class PaymentServiceSecondAdapter : IPaymentTerminal
{
    private readonly PaymentService _paymentService = new();

    public void Pay(decimal amount, string payer)
    {
        _paymentService.MakePayment((double)amount, payer);
    }
}
