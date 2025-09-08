namespace ExampleDesignPatterns.Structural.Adapter;

/// <summary>
/// Платежный терминал.
/// (Внутренний платежный сервис).
/// </summary>
public interface IPaymentTerminal
{
    /// <summary>
    /// Выполняет оплату.
    /// </summary>
    /// <param name="amount">Значение суммы оплаты.</param>
    /// <param name="payer">Плательщик.</param>
    public void Pay(decimal amount, string payer);
}
