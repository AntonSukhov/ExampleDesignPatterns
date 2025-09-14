namespace ExampleDesignPatterns.Structural.Flyweight;

public static class Client
{
    public static void Run()
    {
        var characterCreator = new CharacterCreator();
        var text = "АББА_группа_1980";

        var row = new Row();

        foreach (var c in text)
        {
            var character = characterCreator.GetCharacter(c.ToString());
            row.AddCharacterToRow(character);
        }

        Console.WriteLine($"Строка: {row}");
    }
}
