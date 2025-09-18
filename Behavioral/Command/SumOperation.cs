namespace ExampleDesignPatterns.Behavioral.Command;

public class SumOperation : IOperation
{
    public OperationType OperationType => OperationType.Sum;

    public double Execute(double firstOperand, double secondOperand)
    {
        return firstOperand + secondOperand;
    }
}
