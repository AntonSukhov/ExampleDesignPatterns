namespace ExampleDesignPatterns.Structural.Adapter;

public static class Client
{
    public static void Run()
    {
        IPaymentTerminal paymentTerminalFirst = new PaymentServiceAdapter();
        IPaymentTerminal paymentTerminalSecond = new PaymentServiceSecondAdapter();
        var amount = 5000m;
        var payer = "Иванов Иван Иванович";

        MakePayment(paymentTerminalFirst, amount, payer);

        MakePayment(paymentTerminalSecond, amount, payer);
    }

    private static void MakePayment(IPaymentTerminal paymentTerminal, decimal paymentAmount, string payer)
    {
        ArgumentNullException.ThrowIfNull(paymentTerminal);

        paymentTerminal.Pay(paymentAmount, payer);
    }
}
