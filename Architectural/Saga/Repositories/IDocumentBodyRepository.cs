namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public interface IDocumentBodyRepository
{
    Task CreateBodyAsync(Guid documentId, string content, CancellationToken ct);
    Task UndoBodyAsync(Guid documentId, CancellationToken ct);
}
