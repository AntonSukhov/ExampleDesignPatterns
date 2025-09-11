namespace ExampleDesignPatterns.Structural.Bridge;

public static class Client
{
    public static void Run()
    {
        WindowBase msWindow = new MsWindow();
        msWindow.Show();
    }
}
