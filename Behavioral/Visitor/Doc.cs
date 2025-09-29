namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Документ типа Doc.
/// </summary>
public class Doc : IDocument
{
    /// <inheritdoc/>
    public void Accept(IDocumentVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitDoc(this);
    }

    /// <summary>
    /// Предоставляет содержимое документа типа <see cref="Doc"/>.
    /// </summary>
    /// <returns>Содержимое документа</returns>
    public string GetDocContent()
    {
        return $"Содержимое документа {nameof(Doc)}: Доброе утро страна";
    }
}
