namespace ExampleDesignPatterns.Behavioral.Observer;

/// <summary>
/// Совместный банковский счет.
/// </summary>
public class JointBankAccount
{
    private decimal _amount;

    public event EventHandler<BankAccountArgs>? BankAccountChanged;

    public void AddAmount(decimal amount, string depositor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(depositor);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        _amount += amount;

        BankAccountChanged?.Invoke(this,
            new BankAccountArgs(depositor, BankAccountTransactionType.AddAmount, amount, totalAmount: _amount));
    }

    public void RemoveAmount(decimal amount, string depositor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(depositor);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        if (_amount - amount < 0)
            throw new ArgumentException("На счете недостаточно средств для выполнения операции.", nameof(amount));

        _amount -= amount;

        BankAccountChanged?.Invoke(this,
            new BankAccountArgs(depositor, BankAccountTransactionType.RemoveAmount, amount, totalAmount: _amount));
    }
}
