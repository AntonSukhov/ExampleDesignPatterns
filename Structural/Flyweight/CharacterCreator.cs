namespace ExampleDesignPatterns.Structural.Flyweight;

public class CharacterCreator
{
    private readonly Dictionary<string, CharacterBase> _characterPool = [];

    public CharacterCreator()
    {
        _characterPool.Add("А", new Character("А"));
        _characterPool.Add("Б", new Character("Б"));
        _characterPool.Add("С", new Character("С"));
        _characterPool.Add("Д", new Character("Д"));
        _characterPool.Add("Е", new Character("Е"));
    }

    public CharacterBase GetCharacter(string characterName)
    {
        if (_characterPool.TryGetValue(characterName, out var character))
        {
            return character;
        }

        var newCharacter = new Character(characterName);

        _characterPool.Add(characterName, newCharacter);

        return newCharacter;
    }
}
