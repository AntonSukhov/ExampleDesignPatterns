namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Аргументы банковского счета.
/// </summary>
public class BankAccountArgs
{
    /// <summary>
    /// Получает вкладчика, который внес или снял денежную сумму на(с) счет(а).
    /// </summary>
    public string Depositor { get; }

    /// <summary>
    ///  Получает тип операции с банковским счетом.
    /// </summary>
    public BankAccountTransactionType BankAccountTransactionType { get; }

    /// <summary>
    /// Получает денежную сумму операции со счетом.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Получает итоговую денежную сумму на счете.
    /// </summary>
    public decimal TotalAmount { get; }

    public BankAccountArgs(string depositor, BankAccountTransactionType bankAccountTransactionType,
        decimal amount, decimal totalAmount)
    {
        Depositor = depositor;
        BankAccountTransactionType = bankAccountTransactionType;
        Amount = amount;
        TotalAmount = totalAmount;
    }

    public override string ToString() => $"Вкладчик: {Depositor} Тип операции: {BankAccountTransactionType.ToString()} " +
                                         $"Сумма операции: {Amount} Итоговая сумма счета: {TotalAmount}";
}
