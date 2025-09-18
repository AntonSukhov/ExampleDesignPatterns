using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Command;

/// <summary>
/// Хранилище операций.
/// </summary>
public class OperationStorage
{
    private readonly Dictionary<OperationType, IOperation> _operations = [];

    public OperationStorage()
    {
        _operations.Add(OperationType.Sum, new SumOperation());
        _operations.Add(OperationType.Subtract, new SubtractOperation());
        _operations.Add(OperationType.Multiply, new MultiplyOperation());
        _operations.Add(OperationType.Divide, new DivideOperation());
    }

    public IOperation GetOperationByType(OperationType type)
    {
        if (_operations.TryGetValue(type, out var operation))
            return operation;

        throw new CustomException($"Операция {type.GetTypeCode()} не найдена");
    }

}
