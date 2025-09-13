namespace ExampleDesignPatterns.Structural.Facade;

public class FoundationService
{
    public Foundation BuildFoundation()
    {
        return new Foundation();
    }
}
