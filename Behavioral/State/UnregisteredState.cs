namespace ExampleDesignPatterns.Behavioral.State;

/// <summary>
/// Состояние незарегистрированной заявки в службе техподдержки.
/// </summary>
public class UnregisteredState : UserRequestState
{
    public UnregisteredState()
    {
        Console.WriteLine("Регистрация заявки");
    }

    /// <inheritdoc/>
    protected override void ChangeState(UserRequest request)
    {
        request.RegisteredDate = DateTime.UtcNow;

        request.State = new RegisteredState();
    }
}
