namespace ExampleDesignPatterns.Behavioral.Iterator;

public class Book
{
    public required string Name { get; set; }
    public required string Author { get; set; }

    public Book() : this(string.Empty, string.Empty)
    {       
    }

    public Book(string name, string author)
    {
        Name = name;
        Author = author;
    }

    public override string ToString() => $"{Name} {Author}";
}
