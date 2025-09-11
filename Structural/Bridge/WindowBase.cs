using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

public abstract class WindowBase
{
    protected Form _form = new();
    protected Button _button = new();
    protected WindowImplementorBase? _windowImplementor;

    public virtual void Show()
    {
        _form.Controls.Add(_button);
        Application.EnableVisualStyles();
        Application.Run(_form);
    }
}
