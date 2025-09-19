namespace ExampleDesignPatterns.Utils;

/// <summary>
/// Объект, который инкапсулирует параметры и предоставляет удобный интерфейс для их получения и изменения.
/// </summary>
public class ParametersContext
{
    private readonly Dictionary<string, object> _parameters = [];

    public object? GetParameterValue(string name)
    {
        _parameters.TryGetValue(name, out var value);

        return value;
    }

    public T? GetParameterValueAsClass<T>(string name) where T : class
    {
        if (_parameters.TryGetValue(name, out var value) && value != null && value is T typedValue)
            return typedValue;

        return null;
    }

    public T? GetParameterValueAsStruct<T>(string name) where T : struct
    {
        if (_parameters.TryGetValue(name, out var value) && value != null && value is T typedValue)
            return typedValue;

        return null;
    }


    public void SetParameter(string name, object value)
    {
        if (!_parameters.TryAdd(name, value))
            _parameters[name] = value;
    }
}
