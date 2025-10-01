namespace ExampleDesignPatterns.Architectural.CQRS.Commands;

/// <summary>
/// Команда создания отдела.
/// </summary>
public class DepartmentCreationCommand : ICommand
{
    /// <summary>
    /// Получает ИД отдела.
    /// </summary>
    /// <remarks>Значение ИД отдела является входным параметром обработчика текущей команды.</remarks>
    public Guid DepartmentId { get; }

    /// <summary>
    /// Получает название отдела.
    /// </summary>
    /// <remarks>Значение Название отдела является входным параметром обработчика текущей команды.</remarks>
    public string DepartmentName { get; }

    public DepartmentCreationCommand(Guid departmentId, string departmentName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(departmentName);

        DepartmentId = departmentId;
        DepartmentName = departmentName;
    }
}
