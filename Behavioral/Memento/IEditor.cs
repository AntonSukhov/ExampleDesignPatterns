namespace ExampleDesignPatterns.Behavioral.Memento;

/// <summary>
///  Редактор текста.
/// </summary>
public interface IEditor
{
    /// <summary>
    /// Получает или задаёт значение текста редактора.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Отображает состояние редактора.
    /// </summary>
    public void Display();

    /// <summary>
    /// Восстанавливает состояние редактора
    /// </summary>
    /// <param name="editorMemento">Хранитель редактора.</param>
    public void Restore(IEditorMemento editorMemento);

    /// <summary>
    /// Создает хранителя редактора.
    /// </summary>
    /// <returns>Хранитель редактора.</returns>
    public IEditorMemento CreateMemento();
}
