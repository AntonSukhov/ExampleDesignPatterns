using System.Data;
using System.Data.Common;
using Npgsql;

namespace ExampleDesignPatterns.Generating.AbstractFactory;

public class NpgDbProvider : IDbProvider
{
    public DbConnection CreateConnection(string connectionString)
    {
        var connection = new NpgsqlConnection(connectionString);

        return connection;
    }

    public DbCommand CreateCommand(string commandText, CommandType commandType = CommandType.Text)
    {
        var command = new NpgsqlCommand(commandText)
        {
            CommandType = commandType
        };

        return command;
    }


    public DbParameter CreateParameter(string parameterName, DbType parameterType, object parameterValue,
        ParameterDirection parameterDirection = ParameterDirection.Input)
    {
        var parameter = new NpgsqlParameter(parameterName, parameterType)
        {
            Value = parameterValue,
            Direction = parameterDirection
        };

        return parameter;
    }
}
