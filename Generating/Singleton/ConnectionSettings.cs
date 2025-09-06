namespace ExampleDesignPatterns.Generating.Singleton;

public class ConnectionSettings
{
    private static volatile ConnectionSettings? _connectionSettings;
    private static readonly object _syncObject = new();

    public string ProviderName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public int ConnectionTimeout { get; set; }

    protected ConnectionSettings()
    {
    }

    public static ConnectionSettings Instance
    {
        get
        {
            if (_connectionSettings == null)
            {
                lock (_syncObject)
                {
                    _connectionSettings ??= new ConnectionSettings();
                }
            }

            return _connectionSettings;
        }
    }

    public override string ToString()
    {
        return $"ProviderName: {ProviderName}{Environment.NewLine}" +
                $"ConnectionTimeout: {ConnectionTimeout}{Environment.NewLine}" +
                $"ConnectionString: {ConnectionString}";
    }

}



/*Вопрос: Зачем нужна вторая проверка внутри lock?

Ответ:
Без второй проверки внутри lock возможна ситуация, когда несколько потоков одновременно проходят внешнюю проверку
(видят, что _connectionSettings == null), и каждый поток пытается создать экземпляр внутри блокировки. 
Но блокировка гарантирует, что только один поток будет создавать объект в один момент времени.

Однако, если внутри lock не проверять _connectionSettings повторно, то первый поток создаст объект, а последующие потоки, 
дождавшись снятия блокировки, тоже создадут новый объект, перезаписывая ссылку. 
Это нарушит паттерн Singleton.

Итог:
Вторая проверка внутри lock гарантирует, что объект создаётся только один раз, даже если несколько потоков одновременно 
попали в блок lock.

*/
