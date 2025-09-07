using System.Data;
using Npgsql;

namespace ExampleDesignPatterns.Generating.FactoryMethod;

public class NpgDbConnectionCreator : IDbConnectionCreator
{
    public IDbConnection Create(string connectionString)
    {
        return new NpgsqlConnection(connectionString);
    }
}
