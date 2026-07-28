using System.Collections.Concurrent;

namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public class MockDocumentFooterRepository : IDocumentFooterRepository
{
    private readonly ConcurrentDictionary<Guid, string> _footers = new();

    public async Task CreateFooterAsync(Guid documentId, string content, CancellationToken ct)
    {
        _footers[documentId] = content;
        
        await Task.CompletedTask;
    }

    public async Task UndoFooterAsync(Guid documentId, CancellationToken ct)
    {
        _footers.TryRemove(documentId, out _);
        
        await Task.CompletedTask;
    }
}
