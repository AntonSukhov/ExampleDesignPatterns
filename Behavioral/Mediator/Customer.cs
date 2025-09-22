namespace ExampleDesignPatterns.Behavioral.Mediator;

/// <summary>
/// Покупатель.
/// </summary>
public class Customer : Colleague
{
    public Customer(IMediator mediator, string name) : base(mediator, name)
    {
    }

    /// <summary>
    /// Размещает заказ.
    /// </summary>
    /// <remarks>
    /// Происходит вывод сообщения о размещении заказа и уведомление о нем посредника.
    /// </remarks>
    /// <param name="orderInfo">Информация о заказе.</param>
    public void PlaceOrder(string orderInfo)
    {
        Console.WriteLine($"[{Name}]: Заказываю '{orderInfo}'");
        mediator.Notify(this, ConstantsService.OrderPlaced, orderInfo);  // Уведомляем посредника о размещении заказа.
    }
    /// <summary>
    /// Получает от посредника уведомление о статусе заказа.
    /// </summary>
    /// <param name="orderStatus">Статус заказа.</param>
    public void ReceiveOrder(string orderStatus)
    {
        Console.WriteLine($"[{Name}]: {orderStatus}");
    }
}
