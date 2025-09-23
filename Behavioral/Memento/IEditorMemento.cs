namespace ExampleDesignPatterns.Behavioral.Memento;

/// <summary>
/// Хранитель редактора.
/// </summary>
/// <remarks>
/// Представляет собой "полный" интерфейс хранителя редактора с которым работает "владелец" состояния.
/// </remaks>
public interface IEditorMemento : INarrowEditorMemento
{
    public string Text { get; set; }
}
