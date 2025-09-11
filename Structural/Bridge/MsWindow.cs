using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Окно в стиле MS.
/// </summary>
public class MsWindow : WindowBase
{
    public MsWindow()
    {
        _windowImplementor = new MsWindowImplementor();
        _form = _windowImplementor.FormSetup();
        _button = _windowImplementor.ButtonSetup();
    }

    public override void Show()
    {
        _form.FormBorderStyle = FormBorderStyle.Fixed3D;
        base.Show();
    }
}
