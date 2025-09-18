using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Command;

public class Command : ICommand
{
    private readonly OperationStorage _operationStorage;
    private readonly Stack<double> _commandResultHistory;
    private readonly double _defaultCommandResultValue;

    public Command(OperationStorage operationStorage, double defaultCommandResultValue = 0d)
    {
        ArgumentNullException.ThrowIfNull(operationStorage);

        _commandResultHistory = new Stack<double>();
        _operationStorage = operationStorage;
        _defaultCommandResultValue = defaultCommandResultValue;
    }

    public double Execute(OperationType operationType, double firstOperand, double secondOperand)
    {
        var operation = _operationStorage.GetOperationByType(operationType);

        var result = operation.Execute(firstOperand, secondOperand);

        _commandResultHistory.Push(result);

        return result;
    }

    public double Undo()
    {
        if (_commandResultHistory.Count == 0)
            throw new CustomException($"Нельзя выполнить откат команды.");

        _commandResultHistory.Pop();

        var result = _commandResultHistory.Count > 0 ? _commandResultHistory.Peek() : _defaultCommandResultValue;

        return result;
    }
}
