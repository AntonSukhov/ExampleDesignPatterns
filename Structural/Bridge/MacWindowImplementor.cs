using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Реализация в части настройки окна в стиле Mac.
/// </summary>
public class MacWindowImplementor : WindowImplementorBase
{
    public override Button ButtonSetup()
    {
        _button.Location = new Point(75, 70);
        _button.Size = new Size(125, 25);
        _button.Text = "Leopard";
        _button.ForeColor = Color.White;
        _button.BackColor = Color.LightGray;

        return _button;
    }

    public override Form FormSetup()
    {
        _form.AutoScaleDimensions = new SizeF(6F, 13F);
        _form.AutoScaleMode = AutoScaleMode.Font;
        _form.ClientSize = new Size(284, 172);
        _form.Name = "Mac form";
        _form.Text = "Mac OS - Snow Leopard";
        _form.BackColor = Color.White;

        return _form;
    }
}
