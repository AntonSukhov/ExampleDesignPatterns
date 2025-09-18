namespace ExampleDesignPatterns.Behavioral.Command;

public interface IOperation
{
    public OperationType OperationType{ get;}
    public double Execute(double firstOperand, double secondOperand);
}
 