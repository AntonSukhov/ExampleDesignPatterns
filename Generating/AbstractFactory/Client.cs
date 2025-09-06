namespace ExampleDesignPatterns.Generating.AbstractFactory;

public static class Client
{
    public static void Run()
    {
        IDbProvider dbProvider = new SqlDbProvider();

        var connection = dbProvider.CreateConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");

        Console.WriteLine(connection.ConnectionString);
    }
}
