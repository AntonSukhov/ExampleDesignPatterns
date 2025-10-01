namespace ExampleDesignPatterns.Architectural.CQRS.DAL.Models;

/// <summary>
/// Модель создания отдела.
/// </summary>
public class DepartmentCreationModel
{
    /// <summary>
    /// Получает и задает ИД отдела.
    /// </summary>
    public required Guid DepartmentId { get; set; }

    /// <summary>
    /// Получает и задает название отдела.
    /// </summary>
    public required string DepartmentName { get; set; }
}
