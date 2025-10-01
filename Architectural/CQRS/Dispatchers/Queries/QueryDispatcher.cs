using Autofac;
using ExampleDesignPatterns.Architectural.CQRS.Exceptions;
using ExampleDesignPatterns.Architectural.CQRS.Handlers.Queries;
using ExampleDesignPatterns.Architectural.CQRS.Queries;

namespace ExampleDesignPatterns.Architectural.CQRS.Dispatchers.Queries;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IComponentContext _componentContext;

    public QueryDispatcher(IComponentContext componentContext)
    {
        ArgumentNullException.ThrowIfNull(componentContext);
        
        _componentContext = componentContext;
    }

    /// <inheritdoc/>
    public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
    {
        ArgumentNullException.ThrowIfNull(query);

        var queryHandler = _componentContext.Resolve<IQueryHandler<TQuery, TResult>>()
            ?? throw new QueryHandlerNotFoundException("Не найден обработчик запросов");

        var result = queryHandler.Execute(query);
        return result;
    }
}
