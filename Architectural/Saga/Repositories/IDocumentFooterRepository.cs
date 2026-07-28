namespace ExampleDesignPatterns.Architectural.Saga.Repositories;

public interface IDocumentFooterRepository
{
    Task CreateFooterAsync(Guid documentId, string content, CancellationToken ct);
    Task UndoFooterAsync(Guid documentId, CancellationToken ct);
}
