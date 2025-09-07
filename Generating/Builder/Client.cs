namespace ExampleDesignPatterns.Generating.Builder;

public static class Client
{
    public static void Run()
    {
        IHouseBuilder houseBuilder = new HouseBuilder();
        var director = new Director(houseBuilder);

        var house = director.CreateHouse();


        Console.WriteLine($"Id: {house.Id} Name: {house.Name}");
    }
}
