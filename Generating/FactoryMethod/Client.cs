using Microsoft.Data.SqlClient;

namespace ExampleDesignPatterns.Generating.FactoryMethod;

public static class Client
{
    public static void Run()
    {
        IDbConnectionCreator dbConnectionCreator = new SqlDbConnectionCreator();

        var connection = dbConnectionCreator.Create("Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");
        Console.WriteLine(connection.ConnectionString);
    }
}
