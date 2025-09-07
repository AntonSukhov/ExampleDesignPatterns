namespace ExampleDesignPatterns.Generating.Builder;

public class Director
{
    private readonly IHouseBuilder _houseBuilder;

    public Director(IHouseBuilder houseBuilder)
    {
        _houseBuilder = houseBuilder;
    }

    public House CreateHouse()
    {
        _houseBuilder.DefiningHouseBaseSettings(name: "Трёхэтажный коттедж с каменной крышек и подвалом.");
        _houseBuilder.CreateRoof("Каменная крыша престиж", RoofFrameStructures.Cattle, RoofMaterials.Stone);
        _houseBuilder.CreateFloor(number: 3);
        _houseBuilder.CreateBasement();

        return _houseBuilder.GetHouse();
    }
}
