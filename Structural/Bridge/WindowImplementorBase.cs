using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

public abstract class WindowImplementorBase
{
    protected Form _form = new();
    protected Button _button = new();

    public abstract Form FormSetup();
    public abstract Button ButtonSetup();
}
