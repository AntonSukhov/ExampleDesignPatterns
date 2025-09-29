namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Документ типа Docx.
/// </summary>
public class Docx : IDocument
{
    /// <inheritdoc/>
    public void Accept(IDocumentVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitDocx(this);
    }

    /// <summary>
    /// Предоставляет содержимое документа типа <see cref="Docx"/>.
    /// </summary>
    /// <returns>Содержимое документа</returns>
    public string GetDocxContent()
    {
        return $"Содержимое документа {nameof(Docx)}: Hello world";
    }
}
