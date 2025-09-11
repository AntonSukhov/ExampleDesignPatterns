using System.Drawing;
using ExampleDesignPatterns.Structural.Bridge.Framework;

namespace ExampleDesignPatterns.Structural.Bridge;

public class Button: Control
{
    public Point Location { get; set; }
    public Size Size { get; set; }
    public string Text { get; set; } = string.Empty;
    public Color ForeColor { get; set; }
    public Color BackColor { get; set; }
}
