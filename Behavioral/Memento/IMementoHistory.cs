namespace ExampleDesignPatterns.Behavioral.Memento;

/// <summary>
/// История хранителей редактора.
/// </summary>
public interface IMementoHistory
{
    /// <summary>
    /// Сохранить хранителя редактора.
    /// </summary>
    /// <param name="memento">Хранитель редактора.</param>
    public void Save(INarrowEditorMemento memento);

    /// <summary>
    /// Отменить и получить сохранение хранителя редактора.
    /// </summary>
    /// <returns>Хранитель редактора.</returns>
    public INarrowEditorMemento? Undo();
}
