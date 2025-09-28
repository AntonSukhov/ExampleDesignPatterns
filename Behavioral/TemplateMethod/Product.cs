namespace ExampleDesignPatterns.Behavioral.TemplateMethod;

public class Product
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Cost { get; set; }
    public int Count { get; set; } = 1;
}
