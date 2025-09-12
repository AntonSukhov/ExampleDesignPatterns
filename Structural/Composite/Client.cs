namespace ExampleDesignPatterns.Structural.Composite;

public static class Client
{
    public static void Run()
    {
        FileSystemObject programFilesFolder = new Folder("Program Files");
        FileSystemObject myFolder = new Folder("MyFolder");
        FileSystemObject pngFile = new File("Picture19.png");
        FileSystemObject docFile = new File("Document1910.doc");
        FileSystemObject txtFile = new File("Readme.txt");

        programFilesFolder.Add(txtFile);
        programFilesFolder.Add(myFolder);
        myFolder.Add(pngFile);
        myFolder.Add(docFile);

        programFilesFolder.Print();

        var child = programFilesFolder.GetChild(0);

        if (child != null)
        {
            child.Print();
            programFilesFolder.Remove(child);
        }

         programFilesFolder.Print();

    }
}
