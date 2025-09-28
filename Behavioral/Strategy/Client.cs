using System.Net.Http.Headers;

namespace ExampleDesignPatterns.Behavioral.Strategy;

public static class Client
{
    public static void Run()
    {
        IPaymentStrategy vtbPay = new VtbPay();
        IPaymentStrategy payPal = new PayPal();

        var paymentContext = new PaymentContext(vtbPay);
        paymentContext.Pay(amount: 2500m);

        paymentContext.SetPaymentStrategy(payPal);

        paymentContext.Pay(amount: 15000m);

    }
}
