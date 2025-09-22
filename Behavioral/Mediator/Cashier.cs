namespace ExampleDesignPatterns.Behavioral.Mediator;

/// <summary>
/// Кассир.
/// </summary>
public class Cashier : Colleague
{
    public Cashier(IMediator mediator, string name) : base(mediator, name)
    {
    }

    /// <summary>
    /// Выполняет обработку оплаты товара.
    /// </summary>
    /// <param name="productName">Название оплачиваемого товара.</param>
    /// <returns><c>true</c> товар оплачен успешно, иначе <c>false</c>.</returns>
    public void ProcessPayment(string productName)
    {
        var price = productName == "Coffee" ? 5m : 10m;  //Тут должна быть интеграция с API платежной системы.

        Console.WriteLine($"[{Name}]: Оплата за '{productName}' ({price:C}) — успешно!");

        mediator.Notify(this, ConstantsService.PaymentDone, productName ); //тут всегда уведомление об успешности оплаты
    }

}
