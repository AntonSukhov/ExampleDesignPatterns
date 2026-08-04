using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Реализатор — тёмная тема оформления.
/// </summary>
public class DarkThemeImplementor : ThemeImplementorBase
{
    public override Color FormBackColor => Color.DarkGray;

    public override string FormTitle => "Dark Theme";

    public override Button ButtonSetup()
    {
        _button.Location = new Point(75, 70);
        _button.Size = new Size(125, 25);
        _button.Text = "Dark Button";
        _button.ForeColor = Color.White;
        _button.BackColor = Color.Black;

        return _button;
    }

    public override Form FormSetup()
    {
        _form.AutoScaleDimensions = new SizeF(6F, 13F);
        _form.AutoScaleMode = AutoScaleMode.Font;
        _form.ClientSize = new Size(284, 172);
        _form.Name = "Dark Form";
        _form.Text = FormTitle;
        _form.BackColor = FormBackColor;

        return _form;
    }
}
