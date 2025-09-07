namespace ExampleDesignPatterns.Generating.Builder;

public class Director
{
    private readonly IHouseBuilder _houseBuilder;

    public Director(IHouseBuilder houseBuilder)
    {
        _houseBuilder = houseBuilder;
    }

    public House CreateHouse(string houseName, string roofName, RoofFrameStructures roofFrameStructure,
        RoofMaterials roofMaterial, int numberFloors)
    {
        _houseBuilder.DefiningHouseBaseSettings(houseName);
        _houseBuilder.CreateRoof(roofName, roofFrameStructure, roofMaterial);
        _houseBuilder.CreateFloor(numberFloors);
        _houseBuilder.CreateBasement();

        return _houseBuilder.GetHouse();
    }
}
