namespace ExampleDesignPatterns.Behavioral.Command;

public class MultiplyOperation : IOperation
{
    public OperationType OperationType => OperationType.Multiply;
    public double Execute(double firstOperand, double secondOperand)
    {
        return firstOperand * secondOperand;
    }
}
