namespace ExampleDesignPatterns.Behavioral.Command;

public class DivideOperation : IOperation
{
    public OperationType OperationType => OperationType.Divide;

    public double Execute(double firstOperand, double secondOperand)
    {
        return firstOperand / secondOperand;        
    }
}
