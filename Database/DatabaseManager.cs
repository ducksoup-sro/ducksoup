using API.Settings;
using Microsoft.EntityFrameworkCore;

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
            $"data source={settings.Address},{settings.Port};initial catalog={settings.AccountDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        SroVtShardConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.SharDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        SroVtLogConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.LogDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        DuckSoupConnectionString =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.ProxyDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";



        try
        {
            using var context = new Context.DuckSoup();
            context.Database.Migrate();
            // context.SaveChanges();
        }
        catch (Exception ex)
        {
            Global.Logger.Error(ex + " An error occurred while migrating the database");
        }
    }

    public bool CheckConnection()
    {
        bool acc, shard, log, proxy;
        using (var db = new Context.SRO_VT_ACCOUNT())
        {
            acc = db.Database.CanConnect();
        }

        using (var db = new Context.SRO_VT_SHARD())
        {
            shard = db.Database.CanConnect();
        }

        using (var db = new Context.SRO_VT_LOG())
        {
            log = db.Database.CanConnect();
        }

        using (var db = new Context.DuckSoup())
        {
            proxy = db.Database.CanConnect();
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