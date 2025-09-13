namespace ExampleDesignPatterns.Structural.Facade;

public class RoofService
{
    public Roof BuildRoof()
    {
        return new Roof();
    }
}
