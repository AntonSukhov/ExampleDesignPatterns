using System.Data;
using System.Data.Common;

namespace ExampleDesignPatterns.Generating.AbstractFactory;

public interface IDbProvider
{
    public DbConnection CreateConnection(string connectionString);
    public DbCommand CreateCommand(string commandText, CommandType commandType = CommandType.Text);
    public DbParameter CreateParameter(string parameterName, DbType parameterType, object parameterValue,
        ParameterDirection parameterDirection = ParameterDirection.Input);
}
