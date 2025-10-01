using ExampleDesignPatterns.Architectural.CQRS.Queries;
using ExampleDesignPatterns.Architectural.DAL.Repositories;

namespace ExampleDesignPatterns.Architectural.CQRS.Handlers.Queries;

/// <summary>
/// Обработчик запроса на получение названия отдела по его ИД.
/// </summary>
public class GetDepartmentNameByIdQueryHandler : IQueryHandler<GetDepartmentNameByIdQuery, string?>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentNameByIdQueryHandler(IDepartmentRepository departmentRepository)
    {
        ArgumentNullException.ThrowIfNull(departmentRepository);

        _departmentRepository = departmentRepository;
    }


    /// <inheritdoc/>
    public string? Execute(GetDepartmentNameByIdQuery query)
    {
        ArgumentNullException.ThrowIfNull(query);

        var name = _departmentRepository.GetDepartmentNameById(query.DepartmentId);

        return name;
    }
}
