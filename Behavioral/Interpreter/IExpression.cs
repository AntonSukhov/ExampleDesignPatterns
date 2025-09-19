using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.Interpreter;

public interface IExpression<out T>
{
    public T Interpret(ParametersContext context);
}
