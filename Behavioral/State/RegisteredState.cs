namespace ExampleDesignPatterns.Behavioral.State;

/// <summary>
/// Состояние зарегистрированной заявки в службе техподдержки.
/// </summary>
public class RegisteredState : UserRequestState
{
    public RegisteredState()
    {
        Console.WriteLine("Обработка заявки");
    }

    /// <inheritdoc/>
    protected override void ChangeState(UserRequest request)
    {
        request.Comment = "Заявка обработана успешно.";

        request.State = new SuccessfullyProcessedState();
    }

}
