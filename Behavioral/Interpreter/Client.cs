using System.Reflection.Metadata.Ecma335;
using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Interpreter;

public static class Client
{
    public static void Run()
    {
        var parameter1 = new { Name = "p1", Value = 10d };
        var parameter2 = new { Name = "p2", Value = 5d };
        var parameter3 = new { Name = "p3", Value = 3d };

        var parametersContext = new ParametersContext();

        parametersContext.SetParameter(parameter1.Name, parameter1.Value);
        parametersContext.SetParameter(parameter2.Name, parameter2.Value);
        parametersContext.SetParameter(parameter3.Name, parameter3.Value);

        //Создадим выражение: p1 + p2 - p3

        IExpression<double> expression = new SubtractExpression
        (
            leftExpression: new AddExpression
            (
                leftExpression: new NumberExpression(parameter1.Name),
                rightExpression: new NumberExpression(parameter2.Name)
            ),
            rightExpression: new NumberExpression(parameter3.Name)
        );

        var value = expression.Interpret(parametersContext);

        Console.WriteLine(value);

    }
}
