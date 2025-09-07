namespace ExampleDesignPatterns.Generating.Builder;

/// <summary>
/// Дом.
/// </summary>
public class House
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Roof Roof { get; set; } = new Roof();
    public IList<Floor> Floors { get; set; } = [];
    public Basement? Basement { get; set; }

}
