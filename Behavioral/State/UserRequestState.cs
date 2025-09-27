namespace ExampleDesignPatterns.Behavioral.State;

/// <summary>
/// Состояние обработки заявки пользователя.
/// </summary>
public abstract class UserRequestState
{
    public void Change(UserRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        ChangeState(request);

        if (request.ClosedDate == null)
        {
           request.State.Change(request);
        }  
    }

    /// <summary>
    /// Изменяет состояние обработки заявки пользователя.
    /// </summary>
    /// <param name="request">Заявка пользователя.</param>
    protected abstract void ChangeState(UserRequest request);
}
