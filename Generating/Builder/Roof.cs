namespace ExampleDesignPatterns.Generating.Builder;

/// <summary>
/// Крыша дома.
/// </summary>
public class Roof
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public RoofFrameStructures FrameStructure { get; set; }
    public RoofMaterials Materiale { get; set; }
}
