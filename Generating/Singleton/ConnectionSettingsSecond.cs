namespace ExampleDesignPatterns.Generating.Singleton;

public class ConnectionSettingsSecond
{
    private static readonly Lazy<ConnectionSettingsSecond> _lazy = new(() => new ConnectionSettingsSecond());

    public string ProviderName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public int ConnectionTimeout { get; set; }

    protected ConnectionSettingsSecond()
    {
    }

    public static ConnectionSettingsSecond Instance
    {
        get => _lazy.Value;
    }

    public override string ToString()
    {
        return $"ProviderName: {ProviderName}{Environment.NewLine}" +
                $"ConnectionTimeout: {ConnectionTimeout}{Environment.NewLine}" +
                $"ConnectionString: {ConnectionString}";
    }

}

