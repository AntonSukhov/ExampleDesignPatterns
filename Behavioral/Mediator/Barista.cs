namespace ExampleDesignPatterns.Behavioral.Mediator;

/// <summary>
/// Сотрудник кухни, который готовит кофе.
/// </summary>
public class Barista : Colleague
{
    public Barista(IMediator mediator, string name) : base(mediator, name)
    {
    }

    // <summary>
    /// Готовит заказ.
    /// </summary>
    /// <param name="jsonOrderInfo">Информация о заказе.</param>
    public void PrepareOrder(string orderInfo)
    {
        Console.WriteLine($"[{Name}]: Готовим '{orderInfo}'...");
 
        Thread.Sleep(1000);

        Console.WriteLine($"[{Name}]: '{orderInfo}' готов!");

        mediator.Notify(this, ConstantsService.OrderReady, orderInfo);  // Уведомляем посредника о готовности заказа.
    }
}
