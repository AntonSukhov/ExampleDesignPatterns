namespace ExampleDesignPatterns.Structural.Adapter;


/// <summary>
/// Адаптер внешнего платежного сервиса.
/// Используется accоциация с внешним сервисом вместо наследование.
/// Внешний сервис передаётся извне через конструктор.
/// </summary>
public class PaymentServiceSecondAdapter : IPaymentTerminal
{
    private readonly PaymentService _paymentService;

    public PaymentServiceSecondAdapter(PaymentService paymentService)
    {
        ArgumentNullException.ThrowIfNull(paymentService);
        _paymentService = paymentService;
    }

    public void Pay(decimal amount, string payer)
    {
        _paymentService.MakePayment((double)amount, payer);
    }
}
