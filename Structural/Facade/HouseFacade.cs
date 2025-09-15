using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Structural.Facade;

public class HouseFacade : IHouseFacade
{
    private readonly RoofService _roofService = new();
    private readonly FloorService _floorService = new();
    private readonly FoundationService _foundationService = new();

    public House BuildHouse(int floorCount = 1)
    {
        if (floorCount <= 0)
            throw new CustomException($"Значение переменной {nameof(floorCount)} меньше или равно 0");

        var foundation = _foundationService.BuildFoundation();
        var roof = _roofService.BuildRoof();
        var floors = _floorService.BuildFloors(floorCount)
                                  .ToList();

        var house = new House { Foundation = foundation, Roof = roof, Floors = floors };

        return house;
    }
}
