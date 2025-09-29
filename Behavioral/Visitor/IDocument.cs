namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Документ.
/// </summary>
public interface IDocument
{
    /// <summary>
    /// Осуществляет некоторую работу с документом с помощью указанного посетителя.
    /// </summary>
    /// <param name="visitor">Посетитель документа.</param>
    public void Accept(IDocumentVisitor visitor);
}

