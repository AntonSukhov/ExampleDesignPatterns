namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public interface IDocumentHeaderRepository
{
    Task<Guid> CreateHeaderAsync(Guid documentId, string content, CancellationToken ct);
    Task UndoHeaderAsync(Guid documentId, CancellationToken ct);
}
