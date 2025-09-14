namespace ExampleDesignPatterns.Structural.Flyweight;

public class Row
{
    private readonly IList<CharacterBase> _characters = [];

    /// <summary>
    /// Возвращает список символов, входящих в строку.
    /// </summary>
    public IList<CharacterBase> GetCharacters() => _characters;

    /// <summary>
    /// Добавляет символ в строку.
    /// </summary>
    /// <param name="character">Символ для добавления.</param>
    public void AddCharacterToRow(CharacterBase character)
    {
        _characters.Add(character);
    }

    /// <summary>
    /// Удаляет символ из строки.
    /// </summary>
    /// <param name="character">Символ, который нужно удалить.</param>
    /// <param name="characterOccurrenceNumberInRow">Номер вхождения символа в строке (по умолчанию 1 — первое вхождение).</param>
    public void RemoveCharacterFromRow(CharacterBase character, int characterOccurrenceNumberInRow = 1)
    {
        var index = GetCharacterIndex(character, characterOccurrenceNumberInRow);

        if (index >= 0)
            _characters.RemoveAt(index);
    }

    public override string ToString()
    {
        var chars = _characters?.Select(p => p.Name) ?? [];
        var charsToString = string.Join(string.Empty, chars);

        return charsToString;
    }

    /// <summary>
    /// Получает индекс символа в строке.
    /// </summary>
    /// <param name="character">Символ для поиска.</param>
    /// <param name="characterOccurrenceNumberInRow">Номер вхождения символа в строке.</param>
    /// <returns>Индекс символа в строке или -1, если символ с таким вхождением не найден.</returns>
    private int GetCharacterIndex(CharacterBase character, int characterOccurrenceNumberInRow)
    {
        var gettedCharacter = _characters.Select((c, i) => new { Index = i, Character = c })
                                         .Where(p => p.Character.Name == character.Name)
                                         .Select((c, i) => new { c.Index, OccurrenceNumber = i })
                                         .SingleOrDefault(p => p.OccurrenceNumber == characterOccurrenceNumberInRow);

        return gettedCharacter?.Index ?? -1;
    }
}
