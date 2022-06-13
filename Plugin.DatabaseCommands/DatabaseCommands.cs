using System.Timers;
using API;
using API.Command;
using API.Database.DuckSoup;
using API.Plugin;
using API.Server;
using API.ServiceFactory;
using Plugin.DatabaseCommands.Database;
using Timer = System.Timers.Timer;

namespace Plugin.DatabaseCommands;

public class DatabaseCommands : IPlugin
{
    private Timer? _commandTimer;
    private ICommandManager? _commandManager;

    public void Dispose()
    {
        _commandTimer?.Stop();
        _commandTimer?.Dispose();
        _commandManager = null;
    }

    public string Name => "DatabaseCommands";
    public string Version => "1.0.0";
    public string Author => "b0ykoe";
    public ServerType ServerType => ServerType.None;

    public void OnEnable()
    {
        _commandManager = ServiceFactory.Load<ICommandManager>(typeof(ICommandManager));
        using (var context = new DuckSoup())
        {
            context.Database.ExecuteSqlCommand(@"
                if not exists (select * from sysobjects where name='DatabaseCommand' and xtype='U')
                BEGIN
                    create table DatabaseCommand
                    (
                        CommandId int identity
                        constraint DatabaseCommand_pk
                        primary key,
                            Command   nvarchar(max) not null,
                        SendAfter DATETIME
                    )
                    create unique index DatabaseCommand_CommandId_uindex
                    on DatabaseCommand (CommandId)
                END");
        }
        InitializeTimer();
    }

    public void OnServerStart(IAsyncServer server)
    {
        // wont get fired. Duo to ServerType.None
    }

    public List<Command> RegisterCommands()
    {
        return new List<Command>();
    }

    private void InitializeTimer()
    {
        _commandTimer = new Timer(1000);
        _commandTimer.Elapsed += OnTimerTick;
        _commandTimer.AutoReset = true;
        _commandTimer.Enabled = true;
    }

    private void OnTimerTick(object? sender, ElapsedEventArgs e)
    {
        using var context = new DuckSoupExt();
        var databaseCommandTables = context.DatabaseCommand.ToList();

        foreach (var commandEntry in databaseCommandTables)
        {
            if (commandEntry.SendAfter == null || DateTime.Compare((DateTime) commandEntry.SendAfter, DateTime.Now) < 0)
            {
                _commandManager?.ExecuteCommand(commandEntry.Command);
                context.DatabaseCommand.Remove(commandEntry);
            }
        }

        context.SaveChanges();
    }
}