using System.Data;
using Microsoft.Data.SqlClient;

namespace ExampleDesignPatterns.Generating.FactoryMethod;

public class SqlDbConnectionCreator : IDbConnectionCreator
{
    public IDbConnection Create(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
}
