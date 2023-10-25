using System;
using API.ServiceFactory;
using API.Settings;
using Database;
using Database.VSRO188.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DuckSoup.Library.Database;

public class DatabaseManager
{
    public DatabaseManager()
    {
        ServiceFactory.Register<DatabaseManager>(typeof(DatabaseManager), this);
        var settings = ServiceFactory.Load<ISettingsManager>(typeof(ISettingsManager)).Settings;
        
        // string address, int port, string username, string password, string sharDb, string logDb, string accountDb, string proxyDb
        DuckContext.ConnectionStrings[typeof(SRO_VT_ACCOUNT)] =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.AccountDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        DuckContext.ConnectionStrings[typeof(SRO_VT_SHARD)] =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.SharDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        DuckContext.ConnectionStrings[typeof(SRO_VT_LOG)] =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.LogDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";
        DuckContext.ConnectionStrings[typeof(API.Database.Context.DuckSoup)] =
            $"data source={settings.Address},{settings.Port};initial catalog={settings.ProxyDb};persist security info =True; User Id={settings.Username};Password={settings.Password};MultipleActiveResultSets=True;App=DuckSoupEntityFramework;Encrypt=False;";

        try
        {
            using var context = new API.Database.Context.DuckSoup();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            Log.Error("An error occurred while migrating the database: {@e}", ex);
        }
    }
}