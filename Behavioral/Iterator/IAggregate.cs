namespace ExampleDesignPatterns.Behavioral.Iterator;

/// <summary>
/// Совокупность объектов.
/// </summary>
/// <typeparam name="T">Тип данных объекта.</typeparam>
public interface IAggregate<out T>
{
    public IIterator<T> CreateIterator();
    public int Count();
    public T this[int index] { get; }
}
