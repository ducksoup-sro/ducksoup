#region

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using API;
using API.Command;
using API.Database;
using API.Server;
using API.ServiceFactory;
using DuckSoup.Library;
using DuckSoup.Library.Commands;
using DuckSoup.Library.Event;
using DuckSoup.Library.Party;
using DuckSoup.Library.Plugins;
using DuckSoup.Library.Server;
using DuckSoup.Library.Settings;
using DuckSoup.Library.Webserver;
using log4net;
using log4net.Config;

#endregion

[assembly: XmlConfigurator(Watch = true)]

namespace DuckSoup;

public static class Program
{
    private static void Main()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        // prints out logo + version
        Global.Logger.InfoFormat("\n\n" +
                                 ",--.          .   .---.             \n" +
                                 "|   \\ . . ,-. | , \\___  ,-. . . ,-. \n" +
                                 "|   / | | |   |<      \\ | | | | | | \n" +
                                 "^--'  `-^ `-' ' ` `---' `-' `-^ |-' \n" +
                                 "                                |   \n" +
                                 "         Version  {0}         ' \n" +
                                 "\n",
            FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
                .ProductVersion);
        Console.Title = "Starting up...";

        var settingsManager = new SettingsManager();
        var databaseManager = new DatabaseManager();
        if (!databaseManager.CheckConnection())
            return;

        var sharedObjects = new SharedObjects();
        var partyManager = new PartyManager();
        var serverManager = new ServerManager();
        var webserverManager = new WebserverManager();
        var commandManager = new CommandManager();
        var pluginManager = new PluginManager();
        var eventManager = new EventManager();

        // Make sure we start the command loop in order to not exit the application
        ServiceFactory.Load<ICommandManager>(typeof(ICommandManager)).StartCommandLoop();
    }

    public static void Stop()
    {
        ServiceFactory.Load<IServerManager>(typeof(IServerManager)).Dispose();
        ServiceFactory.Load<ICommandManager>(typeof(ICommandManager)).Dispose();
    }
}