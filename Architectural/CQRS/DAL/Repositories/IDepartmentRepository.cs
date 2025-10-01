using ExampleDesignPatterns.Architectural.CQRS.DAL.Models;

namespace ExampleDesignPatterns.Architectural.DAL.Repositories;

/// <summary>
/// Репозиторий работы с отделом.
/// </summary>
public interface IDepartmentRepository
{
    /// <summary>
    /// Создает отдел.
    /// </summary>
    /// <param name="departmentCreationModel">Модель создания отдела.</param>
    public void Create(DepartmentCreationModel departmentCreationModel);

    /// <summary>
    /// Получает название отдела по его ИД.
    /// </summary>
    /// <param name="id">ИД отдела.</param>
    /// <returns>Название отдела или <c>Null</c>.</returns>
    public string? GetDepartmentNameById(Guid id);

}
