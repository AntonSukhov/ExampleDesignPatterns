namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Посетитель извлекающий текст документа.
/// </summary>
public class TextExtractorVisitor : IDocumentVisitor
{
    /// <inheritdoc/>
    public void VisitDoc(Doc document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var content = document.GetDocContent();

        Console.WriteLine(content);

    }

    /// <inheritdoc/>
    public void VisitDocx(Docx document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var content = document.GetDocxContent();

        Console.WriteLine(content);
    }

    /// <inheritdoc/>
    public void VisitPdf(Pdf document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var content = document.GetPdfContent();

        Console.WriteLine(content);
    }
}
