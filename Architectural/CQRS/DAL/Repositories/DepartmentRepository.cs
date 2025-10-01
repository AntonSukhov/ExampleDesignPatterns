
using ExampleDesignPatterns.Architectural.CQRS.DAL.Models;

namespace ExampleDesignPatterns.Architectural.DAL.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    /// <inheritdoc/>
    public void Create(DepartmentCreationModel departmentCreationModel)
    {
        ArgumentNullException.ThrowIfNull(departmentCreationModel);

        Console.WriteLine($"Создан отдел c названием \"{departmentCreationModel.DepartmentName}\" ({departmentCreationModel.DepartmentId})");
    }

    /// <inheritdoc/>
    public string? GetDepartmentNameById(Guid id)
    {
        return $"Отдел {id.ToString()}";
    }
}
