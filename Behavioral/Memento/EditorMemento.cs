namespace ExampleDesignPatterns.Behavioral.Memento;

/// <summary>
/// Хранитель редактора.
/// </summary>
public class EditorMemento : IEditorMemento
{
    public string Text { get; set; }

    public EditorMemento(string text)
    {
        Text = text;
    }
}
