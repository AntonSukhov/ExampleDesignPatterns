using ExampleDesignPatterns.Utils;

namespace ExampleDesignPatterns.Behavioral.ChainOfResponsibility;

/// <summary>
/// Базовый обработчик в цепочке обработчиков некоторого объекта.
/// </summary>
/// <remarks>
/// Данный обработчик является расширением обработчика "классического" паттерна Цепочка обязанностей, за счет введения
/// ветвления, т.е. появления следующего алтернативного обработчика <see cref="_nextAlternativeHandler"/>.
/// </remarks>
public abstract class HandlerBase
{
    protected HandlerBase? _nextHandler;
    protected HandlerBase? _nextAlternativeHandler;

    /// <summary>
    /// Выполняет обработку объекта.
    /// </summary>
    /// <param name="parametersContext">Контекст с параметрами для обработки.</param>
    public abstract void Handle(ParametersContext parametersContext);

    /// <summary>
    /// Устанавливает следующий обработчик.
    /// </summary>
    /// <param name="handler">Следующий обработчик.</param>
    public void SetNextHandler(HandlerBase handler)
    {
        _nextHandler = handler;
    }

    /// <summary>
    ///  Устанавливает следующий обработчик, являющийся альтернативным обработчиком.
    /// </summary>
    /// <param name="handler">Альтернативный обработчик.</param>
    public void SetNextAlternativeHandler(HandlerBase handler)
    {
        _nextAlternativeHandler = handler;
    }
}
