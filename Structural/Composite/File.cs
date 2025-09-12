namespace ExampleDesignPatterns.Structural.Composite;

/// <summary>
/// Файл файловой системы.
/// </summary>
public class File : FileSystemObject
{
    public File(string name) : base(name)
    {       
    }

    public override void Print()
    {
        Console.WriteLine($"Содержимое файла {_name}");
    }

    public override FileSystemObject? GetChild(int index)
    {
        throw new NotImplementedException();
    }

    public override void Add(FileSystemObject obj)
    {
        throw new NotImplementedException();
    }

    public override void Remove(FileSystemObject obj)
    {
        throw new NotImplementedException();
    }
}
