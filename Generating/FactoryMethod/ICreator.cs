namespace ExampleDesignPatterns.Generating.FactoryMethod;

public interface ICreator
{
    public TResult Create<TResult>() where TResult : new();
}
