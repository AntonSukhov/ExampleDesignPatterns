namespace ExampleDesignPatterns.Behavioral.Memento;

public class Editor : IEditor
{
    public string Text { get; set; }

    public Editor() : this(string.Empty)
    { }

    public Editor(string text)
    {
        Text = text;
    }

    public IEditorMemento CreateMemento() => new EditorMemento(Text);

    public void Display() => Console.WriteLine(Text);

    public void Restore(IEditorMemento editorMemento)
    {
        ArgumentNullException.ThrowIfNull(editorMemento);

        Text = editorMemento.Text;
    }
}
