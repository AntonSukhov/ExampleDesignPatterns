using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Command;

public static class Client
{
    public static void Run()
    {
        var operationStorage = new OperationStorage();
        ICommand command = new Command(operationStorage);

        var firstOperand = 10d;
        var secondOperand = 5d;
        var operationType = OperationType.Sum;

        var commandResult = command.Execute(operationType, firstOperand, secondOperand); //сумма двух чисел

        Console.WriteLine($"{operationType}({firstOperand}, {secondOperand}) = {commandResult}");

        operationType = OperationType.Multiply;

        commandResult = command.Execute(operationType, firstOperand, secondOperand); //произведение двух чисел

        Console.WriteLine($"{operationType}({firstOperand}, {secondOperand}) = {commandResult}");

        commandResult = command.Undo(); //откат произведения двух чисел

        Console.WriteLine($"{commandResult}");

        commandResult = command.Undo(); //откат суммы двух чисел

        Console.WriteLine($"{commandResult}");

        try
        {
            command.Undo();             //откат приводит к ошибке
        }
        catch (CustomException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
