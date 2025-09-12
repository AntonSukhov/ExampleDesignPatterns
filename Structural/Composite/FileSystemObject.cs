namespace ExampleDesignPatterns.Structural.Composite;

/// <summary>
/// Файловая система, состоящая из древовидной структуры, файлов и папок.
/// Файлы являются листовыми объектами, т.е. у них не может быть дочерних элементов (папки или файлы).
/// Папки являются состовными (узловыми) объектами, т.е. у них могут быть дочерние элементы.
/// </summary>
public abstract class FileSystemObject
{
    protected string _name;

    protected FileSystemObject(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        _name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine(_name);
    }
    public abstract FileSystemObject? GetChild(int index);
    public abstract void Add(FileSystemObject obj);
    public abstract void Remove(FileSystemObject obj);
}
