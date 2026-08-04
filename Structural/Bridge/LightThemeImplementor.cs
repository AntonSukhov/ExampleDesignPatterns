using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Реализатор — светлая тема оформления.
/// </summary>
public class LightThemeImplementor : ThemeImplementorBase
{
    public override Color FormBackColor => Color.White;

    public override string FormTitle => "Light Theme";

    public override Button ButtonSetup()
    {
        _button.Location = new Point(75, 70);
        _button.Size = new Size(125, 25);
        _button.Text = "Light Button";
        _button.ForeColor = Color.Black;
        _button.BackColor = Color.LightGray;

        return _button;
    }

    public override Form FormSetup()
    {
        _form.AutoScaleDimensions = new SizeF(6F, 13F);
        _form.AutoScaleMode = AutoScaleMode.Font;
        _form.ClientSize = new Size(284, 172);
        _form.Name = "Light Form";
        _form.Text = FormTitle;
        _form.BackColor = FormBackColor;

        return _form;
    }
}
