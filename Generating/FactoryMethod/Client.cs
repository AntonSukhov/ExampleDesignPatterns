using Microsoft.Data.SqlClient;

namespace ExampleDesignPatterns.Generating.FactoryMethod;

public static class Client
{
    public static void Run()
    {
        IDbConnectionCreator dbConnectionCreator = new SqlDbConnectionCreator();
        ICreator creator = new Creator();

        var connection1 = dbConnectionCreator.Create("Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");
        var connection2 = creator.Create<SqlConnection>();
        connection2.ConnectionString = connection1.ConnectionString;

        Console.WriteLine(connection1.ConnectionString);
        Console.WriteLine(connection2.ConnectionString);


    }
}
