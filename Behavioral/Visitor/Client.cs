namespace ExampleDesignPatterns.Behavioral.Visitor;

public static class Client
{
    public static void Run()
    {
        var documents = new IDocument[]
        {
            new Doc(),
            new Docx(),
            new Pdf()
        };

        IDocumentVisitor documentVisitor = new TextExtractorVisitor();

        //Осуществляется обход разных документов единообразным способом 
        // (через контрактный метод документа, в который передается Посетитель):
        foreach (var document in documents)
        {
            document.Accept(documentVisitor);
        }
    }
}
