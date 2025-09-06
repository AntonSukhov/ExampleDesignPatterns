namespace ExampleDesignPatterns.Generating.Prototype;

public class Contract : ICloneable
{
    public required int Id { get; set; }
    public required string Number { get; set; }
    public required DateTime CreateDate { get; set; }
    public required decimal TotalAmount { get; set; }

    public List<ContractItem> Items { get; set; } = [];


    public Contract Clone()
    {
        return new Contract
        {
            Id = Id,
            Number = (string)Number.Clone(),
            CreateDate = CreateDate,
            TotalAmount = TotalAmount,
            Items = [.. Items.Select(item => item.Clone())]
        };
    }

    object ICloneable.Clone() => Clone();


    public override string ToString()
    {
        var itemsToString = string.Join(" ", Items?.Select(p => p.ToString()) ?? []);

        return $"Id: {Id} Number: {Number} CreateDate: {CreateDate} TotalAmount: {TotalAmount}{Environment.NewLine}Items: {itemsToString}";
    }
}
