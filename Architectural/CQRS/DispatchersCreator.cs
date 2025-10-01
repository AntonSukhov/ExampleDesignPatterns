using Autofac;
using ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Queries;
using ExampleDesignPatterns.Architectural.CQRS.Handlers.Commands;
using ExampleDesignPatterns.Architectural.CQRS.Handlers.Queries;
using ExampleDesignPatterns.Architectural.DAL.Repositories;

namespace ExampleDesignPatterns.Architectural.CQRS;

/// <summary>
/// Создатель диспетчеров запросов и команд.
/// </summary>
public static class DispatchersCreator
{
    /// <summary>
    /// Создать диспетчера запроса и команды.
    /// </summary>
    /// <returns>Диспетчер запроса и команды.</returns>
    public static (IQueryDispatcher, ICommandDispatcher) Create()
    {
        var containerBuilder = new ContainerBuilder();

        containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                         .AsClosedTypesOf(typeof(ICommandHandler<>))
                         .InstancePerDependency();

        containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                         .AsClosedTypesOf(typeof(IQueryHandler<,>))
                         .InstancePerDependency();

        containerBuilder.RegisterType<DepartmentRepository>()
                        .As<IDepartmentRepository>();

        IComponentContext componentContext = containerBuilder.Build();

        return (new QueryDispatcher(componentContext),
                new CommandDispatcher(componentContext));
    }
}
