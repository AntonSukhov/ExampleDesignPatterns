namespace ExampleDesignPatterns.Architectural.Repository.Entities;

/// <summary>
/// Сущность договора.
/// </summary>
public class ContractEntity
{
    public int Id { get;set; }
    public string? Number { get; set; }
    public DateTime CreateDate { get; set; }

    public override string ToString()
    {
        return $"Id:{Id} Number:{Number} CreateDate:{CreateDate}";
    }
}
