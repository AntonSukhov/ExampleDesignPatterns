namespace ExampleDesignPatterns.Behavioral.Command;

public interface ICommand
{
    public double Execute(OperationType operationType, double firstOperand, double secondOperand);
    public double Undo();
}
