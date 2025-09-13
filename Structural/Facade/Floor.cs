namespace ExampleDesignPatterns.Structural.Facade;

/// <summary>
/// Этаж здания.
/// </summary>
public class Floor
{
    public int Number { get; set; }

    public override string ToString()
    {
        return $"Этаж {Number}";
    }
}
