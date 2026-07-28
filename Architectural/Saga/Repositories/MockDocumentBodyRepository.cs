using System.Collections.Concurrent;

namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public class MockDocumentBodyRepository : IDocumentBodyRepository
{
    private readonly ConcurrentDictionary<Guid, string> _bodies = new();

    public async Task CreateBodyAsync(Guid documentId, string content, CancellationToken ct)
    {
        _bodies[documentId] = content;
        
        await Task.CompletedTask;
    }

    public async Task UndoBodyAsync(Guid documentId, CancellationToken ct)
    {
        _bodies.TryRemove(documentId, out _);
        
        await Task.CompletedTask;
    }
}
