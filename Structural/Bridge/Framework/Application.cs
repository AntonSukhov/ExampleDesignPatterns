namespace ExampleDesignPatterns.Structural.Bridge.Framework;

public static class Application
{
    public static void EnableVisualStyles()
    {
        Console.WriteLine($"Включает визуальные стили для приложения.");
    }

    public static void Run(Form form)
    {
        ArgumentNullException.ThrowIfNull(form);

        Console.WriteLine($"Запущена форма {form.Name}.");
    }
}
