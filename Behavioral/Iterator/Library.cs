namespace ExampleDesignPatterns.Behavioral.Iterator;

/// <summary>
/// Библиотека.
/// </summary>
public class Library : IAggregate<Book>
{
    private readonly IList<Book> _books;

    public Library(IList<Book> books)
    {
        ArgumentNullException.ThrowIfNull(books);
        _books = books;
    }

    public IIterator<Book> CreateIterator() => new LibraryIterator(this);

    public int Count() => _books.Count;

    public Book this[int index] => (index >= 0 && index< _books.Count)?_books[index]: BookNull.Instance;
}
