
using API.Settings;

namespace API.Database;

public class DatabaseManager : IDatabaseManager
{
    internal static string? SroVtAccountConnectionString = "";
    internal static string? SroVtLogConnectionString = "";
    internal static string? SroVtShardConnectionString = "";
    internal static string? DuckSoupConnectionString = "";

    public DatabaseManager()
    {
        ServiceFactory.ServiceFactory.Register<DatabaseManager>(typeof(IDatabaseManager), this);
        var settings = ServiceFactory.ServiceFactory.Load<ISettingsManager>(typeof(ISettingsManager)).Settings;
        
        // string address, int port, string username, string password, string sharDb, string logDb, string accountDb, string proxyDb
        SroVtAccountConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.AccountDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;";
        SroVtShardConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.SharDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;";
        SroVtLogConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.LogDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;";
        DuckSoupConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.ProxyDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;";

        using var context = new Database.DuckSoup.DuckSoup();
        context.Database.CreateIfNotExists();
        context.Database.Initialize(false);
    }

    public bool CheckConnection()
    {
        bool acc, shard, log, proxy;
        using (var db = new SRO_VT_ACCOUNT.SRO_VT_ACCOUNT())
        {
            acc = db.Database.Exists();
        }

        using (var db = new SRO_VT_SHARD.SRO_VT_SHARD())
        {
            shard = db.Database.Exists();
        }

        using (var db = new SRO_VT_LOG.SRO_VT_LOG())
        {
            log = db.Database.Exists();
        }

        using (var db = new DuckSoup.DuckSoup())
        {
            proxy = db.Database.Exists();
        }

        return acc && shard && log && proxy;
    }

    public void Dispose()
    {
        SroVtAccountConnectionString = null;
        SroVtLogConnectionString = null;
        SroVtShardConnectionString = null;
        DuckSoupConnectionString = null;
    }
}