using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Конкретный контекст — модальное окно.
/// Определяет поведение: модальное окно блокирует родительское окно.
/// </summary>
public class ModalWindow : WindowBase
{
    public ModalWindow(ThemeImplementorBase themeImplementor)
    {
        _themeImplementor = themeImplementor;
        ApplyTheme();
    }

    public override void Show()
    {
        if (_form != null)
        {
            // Модальное окно — фиксированный размер, нельзя изменить
            _form.FormBorderStyle = FormBorderStyle.FixedSingle;
            _form.MaximizeBox = false;
        }

        base.Show();
    }
}
