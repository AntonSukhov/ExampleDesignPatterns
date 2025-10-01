using ExampleDesignPatterns.Architectural.CQRS.Services;

namespace ExampleDesignPatterns.Architectural.CQRS;

//Command and Query Responsibility Segregation (CQRS) - Разделение ответственности по командам и запросам.

public static class Client
{
    public static void Run()
    {
        var (queryDispatcher, commandDispatcher) = DispatchersCreator.Create();

        var departmentService = new DepartmentService(queryDispatcher, commandDispatcher);

        var department = new { Id = Guid.NewGuid(), Name = "Отдел 101" };

        departmentService.CreateDepartment(department.Id, department.Name);                      

        var departmentName = departmentService.GetDepartmentNameById(Guid.NewGuid());

        Console.WriteLine($"Название отдела: {departmentName}");
    }
}
