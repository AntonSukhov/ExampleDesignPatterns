using System.Threading.Tasks.Dataflow;

namespace ExampleDesignPatterns.Behavioral.Iterator;

public static class Client
{
    public static void Run()
    {
        IList<Book> books = [   new Book { Name = "Гений", Author = "Теодор Драйзер" },
                                new Book { Name = "Тихий Дон", Author = "Михаил Шолохов"},
                                new Book { Name = "Мать", Author = "Максим Горький"} ];

        // Используем:
        // 1) перечисляемый тип: IAggregate<T>, Library 
        // 2) перечислитель: Iterator<T>, LibraryIterator

        var library = new Library(books);
        var libraryIterator = library.CreateIterator();

        while (!libraryIterator.IsDone())
        {
            Console.WriteLine(libraryIterator.CurrentItem());
            libraryIterator.Next();
        }

        Console.WriteLine(libraryIterator.CurrentItem()); //Книга недоступна - BookNull

        // Используем:
        // 1) перечисляемый тип: IList<T>
        // 2) перечислитель: IEnumerator<T>

        var enumerator = books.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }

        Console.WriteLine(enumerator.Current); //пустая строка - Null
        
    }
}
