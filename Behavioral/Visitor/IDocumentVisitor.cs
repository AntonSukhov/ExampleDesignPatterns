namespace ExampleDesignPatterns.Behavioral.Visitor;

/// <summary>
/// Посетитель документа.
/// </summary>
public interface IDocumentVisitor
{
    /// <summary>
    /// Посещение документа типа <see cref="Doc"/>.
    /// </summary>
    /// <param name="document">Документ.</param>
    public void VisitDoc(Doc document);

    /// <summary>
    /// Посещение документа типа <see cref="Docx"/>.
    /// </summary>
    /// <param name="document">Документ.</param>
    public void VisitDocx(Docx document);

    /// <summary>
    /// Посещение документа типа <see cref="Pdf"/>.
    /// </summary>
    /// <param name="document">Документ.</param>
    public void VisitPdf(Pdf document);
}
