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

    }
}
