using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

/// <summary>
/// Реализация в части настройки окна в стиле MS.
/// </summary>
public class MsWindowImplementor : WindowImplementorBase
{
    public override Button ButtonSetup()
    {
        _button.Location = new Point(75, 70);
        _button.Size = new Size(125, 25);
        _button.Text = "Windows";
        _button.ForeColor = Color.Aqua;
        _button.BackColor = Color.DarkBlue;

        return _button;
    }

    public override Form FormSetup()
    {
        _form.AutoScaleDimensions = new SizeF(6F, 13F);
        _form.AutoScaleMode = AutoScaleMode.Font;
        _form.ClientSize = new Size(284, 172);
        _form.Name = "Microsoft Form";
        _form.Text = "Windows Explorer";
        _form.BackColor = Color.LightBlue;

        return _form;
    }
}
