using System.Data;

namespace ExampleDesignPatterns.Generating.FactoryMethod;

public interface IDbConnectionCreator
{
    public IDbConnection Create(string connectionString);
}
