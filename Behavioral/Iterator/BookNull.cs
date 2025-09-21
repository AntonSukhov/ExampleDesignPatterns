namespace ExampleDesignPatterns.Behavioral.Iterator;

public class BookNull : Book
{
    private static readonly Lazy<BookNull> _lazy = new(() => new BookNull
    {
        Name = string.Empty,
        Author = string.Empty
    });

    public static BookNull Instance => _lazy.Value;

    private BookNull()
    {
    }

    public override string ToString() => "Книга недоступна";
}
