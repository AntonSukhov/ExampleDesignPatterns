namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class Request
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public RequestType RequestType { get; set; } = RequestType.None;
    public string Description { get; set; } = string.Empty;
}
