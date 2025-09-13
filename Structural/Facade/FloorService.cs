namespace ExampleDesignPatterns.Structural.Facade;

public class FloorService
{
    public IEnumerable<Floor> BuildFloors(int number)
    {
        for (var i = 0; i < number; i++)
        {
            yield return new Floor { Number = i + 1 };
        }
    }
}
