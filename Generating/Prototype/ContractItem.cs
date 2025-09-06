namespace ExampleDesignPatterns.Generating.Prototype;

public class ContractItem : ICloneable
{
    public required int Id { get; set; }
    public required string Description { get; set; }

    public required int Count { get; set; }

    public ContractItem Clone()
    {
        return new ContractItem
        {
            Id = Id,
            Count = Count,
            Description = (string)Description.Clone()
        };
    }

    object ICloneable.Clone() => Clone();

    public override string ToString()
    {
        return $"Id: {Id} Description: {Description} Count: {Count}";
    }
}
