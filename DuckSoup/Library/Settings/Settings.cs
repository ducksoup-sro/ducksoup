#region

using API.Settings;

#endregion

namespace DuckSoup.Library.Settings;

public class Settings : ISettings
{
    public string Address { get; set; }
    public int? Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string SharDb { get; set; }
    public string LogDb { get; set; }
    public string AccountDb { get; set; }
    public string ProxyDb { get; set; }
    public int MaximumPool { get; set; }
    public int MinimumPool { get; set; }
    public int ConnectionLifetime { get; set; }

    public ISettings Init()
    {
        Address = "0.0.0.0";
        Port = 1433;
        Username = "sa";
        Password = "123456";
        SharDb = "SRO_VT_SHARD";
        LogDb = "SRO_VT_LOG";
        AccountDb = "SRO_VT_ACCOUNT";
        ProxyDb = "DuckSoup";
        MaximumPool = 500;
        MinimumPool = 50;
        ConnectionLifetime = 0;

        return this;
    }

    public void Dispose()
    {
        Address = null;
        Port = null;
        Username = null;
        Password = null;
        SharDb = null;
        LogDb = null;
        AccountDb = null;
        ProxyDb = null;
    }
}