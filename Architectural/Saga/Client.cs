using ExampleDesignPatterns.Architectural.Saga.Repositories;

namespace ExampleDesignPatterns.Architectural.Saga;

public static class Client
{
    public static async Task RunAsync()
    {
        // Создаём заглушки репозиториев (в реальном проекте — через DI)
        var headerRepo = new MockDocumentHeaderRepository();
        var bodyRepo = new MockDocumentBodyRepository();
        var footerRepo = new MockDocumentFooterRepository();

        // Инициализируем сагу
        var saga = new DocumentCreationSaga(headerRepo, bodyRepo, footerRepo);

        try
        {
            var docId = await saga.ExecuteAsync(
                "Заголовок документа",
                "Основное содержимое документа",
                "Подвал документа",
                CancellationToken.None);

            Console.WriteLine($"Документ успешно создан: {docId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании документа. Выполнена компенсация. Ошибка: {ex.Message}");
        }
    }
}