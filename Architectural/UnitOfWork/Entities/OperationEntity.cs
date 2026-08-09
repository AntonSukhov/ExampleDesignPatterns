namespace ExampleDesignPatterns.Architectural.UnitOfWork.Entities;

 /// <summary>
 /// Сущность операция.
 /// </summary>
public class OperationEntity
{
    /// <summary>
    /// Получает или задает ИД операции.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Получает или задает название операции.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Получает или задает дату создания операции.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
}
