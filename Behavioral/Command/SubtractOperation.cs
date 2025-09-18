namespace ExampleDesignPatterns.Behavioral.Command;

public class SubtractOperation : IOperation
{
    public OperationType OperationType => OperationType.Subtract;

    public double Execute(double firstOperand, double secondOperand)
    {
        return firstOperand - secondOperand;
    }
}
