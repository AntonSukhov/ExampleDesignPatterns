namespace ExampleDesignPatterns.Behavioral.State;

/// <summary>
/// Заявка пользователя в службу технической поддержки.
/// </summary>
public class UserRequest
{
    /// <summary>
    /// Получает ИД заявки.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Получает описание заявки.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Получает имя инициатора заявки.
    /// </summary>
    public string UserName { get; }

    /// <summary>
    /// Получает и задаёт дату регистрации заявки.
    /// </summary>
    public DateTime? RegisteredDate { get; set; }

    /// <summary>
    /// Получает и задаёт комментарий к обработки заявки.
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Получает и задаёт дату закрытия заявки.
    /// </summary>
    public DateTime? ClosedDate { get; set; }

    /// <summary>
    /// Получает или задает состояние обработки заявки пользователя.
    /// </summary>
    public UserRequestState State { get; set; }

    public UserRequest(int id, string description, string userName)
    {
        Id = id;
        Description = description;
        UserName = userName;
        State = new UnregisteredState();
    }

    /// <summary>
    /// Начать обработку заявки.
    /// </summary>
    public void BeginProcessing() => State.Change(this);
}
