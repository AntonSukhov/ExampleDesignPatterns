namespace ExampleDesignPatterns.Structural.Facade;

public static class Client
{
    public static void Run()
    {
        IHouseFacade houseFacade = new HouseFacade();
        var house = houseFacade.BuildHouse(floorCount: 3);

        Console.WriteLine(house);
    }
}
