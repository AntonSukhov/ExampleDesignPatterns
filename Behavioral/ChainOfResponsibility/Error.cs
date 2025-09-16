namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

public class Error
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime? CloseDate { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Solved { get; set; }

    public override string ToString()
    {
        var registrationDate = RegistrationDate?.ToShortDateString() ?? string.Empty;
        var closeDate = CloseDate?.ToShortDateString() ?? string.Empty;

        return $"Id: {Id}{Environment.NewLine}CreateDate: {CreateDate:O}{Environment.NewLine}" +
               $"RegistrationDate: {registrationDate}{Environment.NewLine}CloseDate: {closeDate}{Environment.NewLine}" +
               $"Description: {Description}";
    }
}
