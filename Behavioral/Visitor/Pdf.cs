namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Документ типа Pdf.
/// </summary>
public class Pdf : IDocument
{
    /// <inheritdoc/>
    public void Accept(IDocumentVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitPdf(this);
    }

    /// <summary>
    /// Предоставляет содержимое документа типа <see cref="Pdf"/>.
    /// </summary>
    /// <returns>Содержимое документа</returns>
    public string GetPdfContent()
    {
        return $"Содержимое документа {nameof(Pdf)}: Привет мир!!!";
    }
}
