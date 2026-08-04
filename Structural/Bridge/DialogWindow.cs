using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Конкретный контекст — диалоговое окно.
/// Определяет поведение: окно с кнопками OK/Cancel.
/// </summary>
public class DialogWindow : WindowBase
{
    public DialogWindow(ThemeImplementorBase themeImplementor)
    {
        _themeImplementor = themeImplementor;
        ApplyTheme();
    }

    public override void Show()
    {
        if (_form != null)
        {
            // Диалоговое окно — фиксированный размер
            _form.FormBorderStyle = FormBorderStyle.FixedDialog;
            _form.MaximizeBox = false;
            _form.MinimizeBox = false;
        }

        base.Show();
    }
}
