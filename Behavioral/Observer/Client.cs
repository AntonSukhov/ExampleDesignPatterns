namespace ExampleDesignPatterns.Behavioral.Observer;

public static class Client
{
    public static void Run()
    {
        var stock = new Stock();
        var vtbBank = new Bank("ВТБ", stock);
        var sberBank = new Bank("Сбербанк", stock);
        var broker = new Broker("Пётр", stock);

        stock.ExecuteTrade();

        broker.StopTrade();

        stock.ExecuteTrade();

        var jointBankAccount = new JointBankAccount();

        jointBankAccount.BankAccountChanged += (sender, args) =>
        {
            Console.WriteLine($"Отправка на почту информации об операции со счетом:{Environment.NewLine}{args}");
        };

        jointBankAccount.AddAmount(amount: 10000m, depositor: "Иванов Иван Иванович");
        jointBankAccount.RemoveAmount(amount: 3000m, depositor: "Петров Пётр Петрович");
    }
}
