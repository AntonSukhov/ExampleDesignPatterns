namespace ExampleDesignPatterns.Generating.Builder;

public interface IHouseBuilder
{
    public void DefiningHouseBaseSettings(string name);
    public void CreateRoof(string name, RoofFrameStructures frameStructure, RoofMaterials materiale);
    public void CreateFloor(int number);
    public void CreateBasement();
    public House GetHouse();
}
