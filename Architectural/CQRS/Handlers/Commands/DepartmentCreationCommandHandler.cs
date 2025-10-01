using ExampleDesignPatterns.Architectural.CQRS.Commands;
using ExampleDesignPatterns.Architectural.CQRS.DAL.Models;
using ExampleDesignPatterns.Architectural.DAL.Repositories;

namespace ExampleDesignPatterns.Architectural.CQRS.Handlers.Commands;

/// <summary>
/// Обработчик команды создания отдела.
/// </summary>
public class DepartmentCreationCommandHandler : ICommandHandler<DepartmentCreationCommand>
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentCreationCommandHandler(IDepartmentRepository departmentRepository)
    {
        ArgumentNullException.ThrowIfNull(departmentRepository);

        _departmentRepository = departmentRepository;
    }
   
    /// <inheritdoc/>
    public void Execute(DepartmentCreationCommand command)
    {
        var departmentCreationModel = new DepartmentCreationModel
        {
            DepartmentId = command.DepartmentId,
            DepartmentName = command.DepartmentName
        };

        _departmentRepository.Create(departmentCreationModel);
    }
}
