using System.Drawing;

namespace ExampleDesignPatterns.Structural.Bridge.Framework;

public class Form : Control
{
    public FormBorderStyle FormBorderStyle { get; set; }

    public SizeF AutoScaleDimensions { get; set; }

    public AutoScaleMode AutoScaleMode { get; set; }

    public Size ClientSize { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public Color BackColor { get; set; }

    public Icon? Icon { get; set; }

    public IList<Control> Controls { get; set; } = [];
}
