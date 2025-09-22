namespace ExampleDesignPatterns.Behavioral.Mediator;

public class CafeMediator : IMediator
{
    private readonly Cashier _cashier;
    private readonly Barista _barista;

    public Customer Customer { get; }

    /// <summary>
    /// Текущий заказ для передачи между шагами его обработки.
    /// </summary>
    private string _currentOrder;

    public CafeMediator()
    {
        Customer = new Customer(this, "Клиент");
        _cashier = new Cashier(this, "Кассир");
        _barista = new Barista(this, "Бариста");
        _currentOrder = string.Empty;
    }



    public void Notify(Colleague sender, string eventName, string data)
    {
        if (eventName == ConstantsService.OrderPlaced && sender is Customer)
        {
            _currentOrder = data;  // Сохраняем текущий заказ

            // Шаг 1: Переходим к оплате
            _cashier.ProcessPayment(_currentOrder);
        }
        else if (eventName == ConstantsService.PaymentDone && sender is Cashier)
        {
            if (_currentOrder != null)  // Если оплата успешна
            {
                // Шаг 2: Переходим к приготовлению
                _barista.PrepareOrder(_currentOrder);
            }
            else
            {
                // Обработка отказа оплаты
                Customer.ReceiveOrder("Заказ отменен: ошибка оплаты");
            }
        }
        else if (eventName == ConstantsService.OrderReady && sender is Barista)
        {
            // Шаг 3: Финальное уведомление клиенту
            Customer.ReceiveOrder($"Ваш '{_currentOrder}' готов! Приятного аппетита.");
        }
    }

    
}
