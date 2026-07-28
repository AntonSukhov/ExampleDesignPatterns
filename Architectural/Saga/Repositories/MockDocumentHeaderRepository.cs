using System.Collections.Concurrent;

namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public class MockDocumentHeaderRepository : IDocumentHeaderRepository
{
   private readonly ConcurrentDictionary<Guid, string> _headers = new();

    public async Task<Guid> CreateHeaderAsync(Guid documentId, string content, CancellationToken ct)
    {
        _headers[documentId] = content;

        // Имитация задержки, чтобы было видно пошаговое выполнение
        return await Task.FromResult(documentId);
    }

    public async Task UndoHeaderAsync(Guid documentId, CancellationToken ct)
    {
        _headers.TryRemove(documentId, out _);

        await Task.CompletedTask;
    }
}
