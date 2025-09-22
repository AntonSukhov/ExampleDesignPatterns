namespace ExampleDesignPatterns.Behavioral.Mediator;

/// <summary>
/// Базовый компонент системы (коллега), участвующий в их взаимодействии через Посредника.
/// </summary>
public abstract class Colleague
{
    /// <summary>
    /// Ссылка на посредника, для взаимодействия компонент.
    /// </summary>
    protected IMediator mediator;

    /// <summary>
    /// Получает имя компонента.
    /// </summary>
    public string Name { get; }

    protected Colleague(IMediator mediator, string name)
    {
        this.mediator = mediator;
        Name = name;
    }
}
