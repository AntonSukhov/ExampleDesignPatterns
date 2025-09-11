using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Окно в стиле MAC
/// </summary>
public class MacWindow : WindowBase
{
    public MacWindow()
    {
        _windowImplementor = new MacWindowImplementor();
        _form = _windowImplementor.FormSetup();
        _button = _windowImplementor.ButtonSetup();
    }
    public override void Show()
    {
        _form.FormBorderStyle = FormBorderStyle.FixedSingle;
        base.Show();
    }
}
