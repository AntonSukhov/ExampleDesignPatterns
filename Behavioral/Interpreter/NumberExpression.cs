using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Interpreter;

/// <summary>
/// Терминальное выражение.
/// </summary>
/// <remarks>
/// В контексте формальных грамматик терминальные выражения — это символы, которые не могут быть дальше 
/// разложены или заменены, т.е. они являются «конечными» элементами языка, из которых строятся строки языка.
/// </remarks>
public class NumberExpression : IExpression<double>
{
    private readonly string _parameterName;

    public NumberExpression(string parameterName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(parameterName);

        _parameterName = parameterName;
    }

    public double Interpret(ParametersContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var value = context.GetParameterValueAsStruct<double>(_parameterName)
            ?? throw new CustomException($"Отсутствует параметр {_parameterName}");

        return value;
    }
}
