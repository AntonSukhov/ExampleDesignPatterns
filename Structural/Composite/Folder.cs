namespace ExampleDesignPatterns.Structural.Composite;

public class Folder : FileSystemObject
{
    private readonly IList<FileSystemObject> _childs;

    public Folder(string name) : base(name)
    {
        _childs = [];
    }

    public override void Print()
    {
        Console.WriteLine($"Содержимое папки {_name}:");
        foreach (var child in _childs)
        {
            child.Print();
        }
    }

    public override FileSystemObject? GetChild(int index)
    {
        if (_childs.Count - 1 <= Math.Abs(index))
            return null;

        return _childs[index];
    }

    public override void Add(FileSystemObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        _childs.Add(obj);
    }

    public override void Remove(FileSystemObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

         _childs.Remove(obj);
    }

}
