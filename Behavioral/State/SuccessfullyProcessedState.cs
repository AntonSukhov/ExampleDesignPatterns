namespace ExampleDesignPatterns.Behavioral.State;

/// <summary>
/// Состояние успешной обработки заявки.
/// </summary>
public class SuccessfullyProcessedState : UserRequestState
{
    public SuccessfullyProcessedState()
    {
        Console.WriteLine("Закрытие заявки");
    }

    /// <inheritdoc/>
    protected override void ChangeState(UserRequest request)
    {
        request.ClosedDate = DateTime.UtcNow;

        request.State = new ClosedRequestState();
    }
}
