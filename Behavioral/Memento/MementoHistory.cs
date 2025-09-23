namespace ExampleDesignPatterns.Behavioral.Memento;

public class MementoHistory : IMementoHistory
{
    private readonly Stack<INarrowEditorMemento> _mementos = [];


    public void Save(INarrowEditorMemento memento)
    {
        ArgumentNullException.ThrowIfNull(memento);

        _mementos.Push(memento);
    }

    public INarrowEditorMemento? Undo()
    {
        _mementos.TryPop(out var lastMemento);

        return lastMemento;
    }
}
