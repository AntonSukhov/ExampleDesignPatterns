namespace ExampleDesignPatterns.Structural.Facade;

public interface IHouseFacade
{
    public House BuildHouse(int floorCount = 1);
}
