using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace ExampleDesignPatterns.Generating.AbstractFactory;

public class SqlDbProvider : IDbProvider
{
    public DbConnection CreateConnection(string connectionString)
    {
        var connection = new SqlConnection(connectionString);

        return connection;
    }

    public DbCommand CreateCommand(string commandText, CommandType commandType = CommandType.Text)
    {
        var command = new SqlCommand(commandText)
        {
            CommandType = commandType
        };

        return command;
    }

    public DbParameter CreateParameter(string parameterName, DbType parameterType, object parameterValue,
        ParameterDirection parameterDirection = ParameterDirection.Input)
    {
        var parameter = new SqlParameter(parameterName, parameterValue)
        {
            DbType = parameterType,
            Direction = parameterDirection
        };

        return parameter;
    }
}
