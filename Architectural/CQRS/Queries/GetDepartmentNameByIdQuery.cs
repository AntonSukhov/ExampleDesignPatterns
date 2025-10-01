namespace ExampleDesignPatterns.Architectural.CQRS.Queries;

/// <summary>
/// Запрос на получение названия отдела по его ИД.
/// </summary>
/// <remarks>Типом данных результата обработчика текущего запроса является <see cref="string?"/></remarks>
public class GetDepartmentNameByIdQuery : IQuery<string?>
{
    /// <summary>
    /// Получает ИД отдела.
    /// </summary>
    /// <remarks>Значение ИД отдела является входным параметром обработчика текущего запроса.</remarks>
    public Guid DepartmentId { get; }

    public GetDepartmentNameByIdQuery(Guid departmentId)
    {
        DepartmentId = departmentId;
    }
}
