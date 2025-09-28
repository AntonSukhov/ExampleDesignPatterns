namespace ExampleDesignPatterns.Behavioral.Strategy;

/// <summary>
/// Стратегия выполнения платежа.
/// </summary>
public interface IPaymentStrategy
{
    /// <summary>
    /// Предоставляет название метода выполнения платежа.
    /// </summary>
    /// <returns>Название метода выполнения платежа.</returns>
    string GetPaymentMethodName();

    /// <summary>
    /// Выполняет платёж.
    /// </summary>
    /// <param name="amount">Размер платежа.</param>
    void Pay(decimal amount);
}
