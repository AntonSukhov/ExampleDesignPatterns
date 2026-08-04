using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Абстрактный контекст — определяет поведение окна.
/// Содержит ссылку на ThemeImplementorBase для делегирования визуального оформления.
/// </summary>
public abstract class WindowBase
{
    protected Form? _form;
    protected Button? _button;
    protected ThemeImplementorBase? _themeImplementor;

    /// <summary>
    /// Настраивает тему оформления через Implementator.
    /// </summary>
    protected void ApplyTheme()
    {
        if (_themeImplementor == null) return;

        _form = _themeImplementor.FormSetup();
        _button = _themeImplementor.ButtonSetup();
    }

    /// <summary>
    /// Показывает окно. Переопределяется в конкретных окнах для добавления поведенческих настроек.
    /// </summary>
    public virtual void Show()
    {
        if (_form == null || _button == null) return;

        _form.Controls.Add(_button);
        Application.EnableVisualStyles();
        Application.Run(_form);
    }
}
