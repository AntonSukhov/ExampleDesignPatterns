namespace ExampleDesignPatterns.Generating.Singleton;

public static class Client
{
    public static void Run()
    {

        var connectionSettings1 = ConnectionSettings.Instance;
        Console.WriteLine(connectionSettings1);

        connectionSettings1.ConnectionTimeout = 1000;
        connectionSettings1.ProviderName = "OLE DB";
        connectionSettings1.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";

        var connectionSettings2 = ConnectionSettings.Instance;

        Console.WriteLine(connectionSettings2);


        Console.WriteLine("*****Одиночка с помощью Lazy:******");

        var connectionSettings3 = ConnectionSettingsSecond.Instance;
        Console.WriteLine(connectionSettings3);

        connectionSettings3.ConnectionTimeout = 1001;
        connectionSettings3.ProviderName = "OLE DB";
        connectionSettings3.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";

        var connectionSettings4 = ConnectionSettingsSecond.Instance;

        Console.WriteLine(connectionSettings4);


    }
}
