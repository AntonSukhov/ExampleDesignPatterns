using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Interpreter;

/// <summary>
/// Нетерминальное выражение для вычитания.
/// </summary>
public class SubtractExpression : IExpression<double>
{
    private readonly IExpression<double> _leftExpression;
    private readonly IExpression<double> _rightExpression;

    public SubtractExpression(IExpression<double> leftExpression, IExpression<double> rightExpression)
    {
        ArgumentNullException.ThrowIfNull(leftExpression);
        ArgumentNullException.ThrowIfNull(rightExpression);

        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public double Interpret(ParametersContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var value = _leftExpression.Interpret(context) - _rightExpression.Interpret(context);

        return value;
    }
}
