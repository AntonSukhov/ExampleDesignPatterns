namespace ExampleDesignPatterns.Architectural.Saga.Enums;

/// <summary>
/// Статусы жизненного цикла саги.
/// </summary>
public enum SagaStatus
{
    /// <summary>
    /// Сага только стартовала, ни один шаг ещё не выполнен.
    /// </summary>
    Pending,

    /// <summary>
    /// Успешно выполнен шаг: создан заголовок документа.
    /// </summary>
    HeaderCreated,

    /// <summary>
    /// Успешно выполнены шаги: заголовок и тело документа.
    /// </summary>
    BodyCreated,

    /// <summary>
    /// Все шаги успешно выполнены: документ полностью собран.
    /// </summary>
    Completed,

    /// <summary>
    /// Произошла ошибка, все выполненные шаги были корректно компенсированы.
    /// </summary>
    Compensated
}