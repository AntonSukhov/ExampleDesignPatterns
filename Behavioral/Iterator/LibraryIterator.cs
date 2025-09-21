namespace ExampleDesignPatterns.Behavioral.Iterator;

public class LibraryIterator : IIterator<Book>
{
    private readonly IAggregate<Book> _library;
    private readonly int _libraryCount;
    private int _currentIndex;

    public LibraryIterator(IAggregate<Book> aggregate)
    {
        ArgumentNullException.ThrowIfNull(aggregate);

        _library = aggregate;
        _libraryCount = _library.Count();
        _currentIndex = 0;
    }

    public void First() => _currentIndex = 0;

    public void Next()
    {
         if(!IsDone())
            _currentIndex++;
    }

    public Book CurrentItem() => IsDone() ? BookNull.Instance : _library[_currentIndex];

    public bool IsDone() => _currentIndex >= _libraryCount;
}
