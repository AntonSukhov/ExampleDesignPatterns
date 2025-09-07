namespace ExampleDesignPatterns.Generating.FactoryMethod;

public class Creator : ICreator
{
    public TResult Create<TResult>() where TResult : new()
    {
        return new TResult();
    }
}
