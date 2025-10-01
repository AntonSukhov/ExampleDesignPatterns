using ExampleDesignPatterns.Architectural.CQRS.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Queries;
using ExampleDesignPatterns.Architectural.CQRS.Queries;

namespace ExampleDesignPatterns.Architectural.CQRS.Services;

 /// <summary>
 /// Сервис работы с отделом.
 /// </summary>
 /// <remarks>Сервис использует диспетчеров, чтобы неявно использовать обработчики запросов и комманд.</remarks>
public class DepartmentService
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public DepartmentService(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
    {
        ArgumentNullException.ThrowIfNull(queryDispatcher);
        ArgumentNullException.ThrowIfNull(commandDispatcher);

        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    public void CreateDepartment(Guid id, string name)
    {
        var command = new DepartmentCreationCommand(id, name);
        _commandDispatcher.Execute(command);
    }

    public string? GetDepartmentNameById(Guid id)
    {
        var query = new GetDepartmentNameByIdQuery(id);
        var departmentName = _queryDispatcher.Execute<GetDepartmentNameByIdQuery, string?>(query);

        return departmentName;
    }
}
