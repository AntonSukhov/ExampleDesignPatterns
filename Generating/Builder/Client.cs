namespace ExampleDesignPatterns.Generating.Builder;

public static class Client
{
    public static void Run()
    {
        IHouseBuilder houseBuilder = new HouseBuilder();
        var director = new Director(houseBuilder);

        var house = director.CreateHouse(houseName: "Трёхэтажный коттедж с каменной крышек и подвалом.",
                                         roofName: "Каменная крыша престиж",
                                         roofFrameStructure: RoofFrameStructures.Cattle,
                                         roofMaterial: RoofMaterials.Stone,
                                         numberFloors: 3);


        Console.WriteLine($"Id: {house.Id} Name: {house.Name}");
    }
}
