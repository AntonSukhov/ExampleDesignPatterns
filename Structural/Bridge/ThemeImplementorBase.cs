using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Абстрактный реализатор — определяет тему оформления (визуальное оформление).
/// В паттерне Bridge это "implementation" сторона.
/// </summary>
public abstract class ThemeImplementorBase
{
    protected Form _form = new();
    protected Button _button = new();

    /// <summary>
    /// Настройка формы в рамках данной темы.
    /// </summary>
    public abstract Form FormSetup();

    /// <summary>
    /// Настройка кнопки в рамках данной темы.
    /// </summary>
    public abstract Button ButtonSetup();

    /// <summary>
    /// Цвет фона формы.
    /// </summary>
    public abstract Color FormBackColor { get; }

    /// <summary>
    /// Текст заголовка формы.
    /// </summary>
    public abstract string FormTitle { get; }
}
