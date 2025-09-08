namespace ExampleDesignPatterns.Structural.Adapter;

public class PaymentException : Exception
{
    public PaymentException(string? message) : base(message)
    {
        
    }
}
