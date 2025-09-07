namespace ExampleDesignPatterns.Generating.Builder;

public class HouseBuilder : IHouseBuilder
{
    private readonly House _house = new();

    public void DefiningHouseBaseSettings(string name)
    {
        _house.Id = Guid.NewGuid();
        _house.Name = name;
    }

    public void CreateBasement()
    {
        _house.Basement = new Basement
        {
            Id = Guid.NewGuid()
        };
    }

    public void CreateFloor(int number)
    {
        for (var i = 1; i <= number && number > 0; i++)
        {
            _house.Floors.Add(new Floor
            {
                Id = Guid.NewGuid(),
                Number = i
            });
        }
    }

    public void CreateRoof(string name, RoofFrameStructures frameStructure, RoofMaterials materiale)
    {
        _house.Roof = new Roof
        {
            Id = Guid.NewGuid(),
            Name = name,
            Materiale = materiale,
            FrameStructure = frameStructure
        };
    }

    public House GetHouse()
    {
        return _house;
    }
}
