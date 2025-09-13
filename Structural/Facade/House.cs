namespace ExampleDesignPatterns.Structural.Facade;

public class House
{
    public required Roof Roof { get; set; }

    public required Foundation Foundation { get; set; }

    public required IList<Floor> Floors { get; set; }

    public override string ToString()
    {
        return $"{Roof} {string.Join(", ", Floors)} {Foundation}";
    }
}
