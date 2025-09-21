namespace ExampleDesignPatterns.Behavioral.Iterator;

/// <summary>
/// Итератор для последовательного обхода коллекции элементов типа <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">Тип элементов коллекции.</typeparam>
public interface IIterator<out T>
{
    /// <summary>
    /// Переходит к первому элементу коллекции.
    /// </summary>
    public void First();

    /// <summary>
    /// Переходит к следующему элементу коллекции.
    /// </summary>
    public void Next();

    /// <summary>
    /// Возвращает текущий элемент коллекции без изменения позиции.
    /// </summary>
    /// <returns>Текущий элемент коллекции.</returns>
    public T CurrentItem();

    /// <summary>
    /// Проверяет, достигнут ли конец коллекции.
    /// </summary>
    /// <returns><c>true</c>, если все элементы пройдены; иначе <c>false</c>.</returns>
    public bool IsDone();
}
