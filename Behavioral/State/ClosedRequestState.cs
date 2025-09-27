namespace ExampleDesignPatterns.Behavioral.State;

public class ClosedRequestState : UserRequestState
{
    public ClosedRequestState()
    {
        Console.WriteLine("Заявка закрыта");
    }

    protected override void ChangeState(UserRequest request)
    {
    }
}
