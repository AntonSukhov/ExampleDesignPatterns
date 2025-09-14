namespace ExampleDesignPatterns.Structural.Flyweight;

public abstract class CharacterBase
{
    public string Name { get; protected set; } = string.Empty;

    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}
