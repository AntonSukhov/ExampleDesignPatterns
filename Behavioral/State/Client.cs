namespace ExampleDesignPatterns.Behavioral.State;

public static class Client
{
    public static void Run()
    {
        var request = new UserRequest
        (id: 1,
        description: "На сервере 123.45.67.89 не загружается сайт domen.ru, возникает ошибка 500 Server Error (скриншот).",
        userName: Environment.UserName);

        request.BeginProcessing();
    }
}
