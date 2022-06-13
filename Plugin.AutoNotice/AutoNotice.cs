using System.Timers;
using API;
using API.Command;
using API.Database.DuckSoup;
using API.Plugin;
using API.Server;
using API.ServiceFactory;
using Plugin.AutoNotice.Database;
using Timer = System.Timers.Timer;

namespace Plugin.AutoNotice;

public class AutoNotice : IPlugin
{
    private Timer? _noticeTimer;
    private ISharedObjects? SharedObjects;

    public void Dispose()
    {
        _noticeTimer?.Stop();
        _noticeTimer?.Dispose();
        SharedObjects = null;
    }

    public string Name => "AutoNotice";
    public string Version => "1.0.0";
    public string Author => "b0ykoe";
    public ServerType ServerType => ServerType.None;

    public void OnEnable()
    {
        SharedObjects = ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects));
        using (var context = new DuckSoup())
        {
            context.Database.ExecuteSqlCommand(
                @"if not exists (select * from sysobjects where name='AutoNotice' and xtype='U')
                BEGIN
                    create table AutoNotice 
                    ( 
                        NoticeId  int identity 
                        constraint AutoNotice_pk 
                        primary key, 
                            Receiver  nvarchar(32)  not null, 
                        Notice    nvarchar(max) not null, 
                        SendAfter DATETIME 
                    ) 
                    create unique index AutoNotice_NoticeId_uindex 
                    on AutoNotice (NoticeId)
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
        _noticeTimer = new Timer(1000);
        _noticeTimer.Elapsed += OnTimerTick;
        _noticeTimer.AutoReset = true;
        _noticeTimer.Enabled = true;
    }

    private void OnTimerTick(object? sender, ElapsedEventArgs e)
    {
        using var context = new DuckSoupExt();
        var autoNoticeTables = context.AutoNotice.ToList();
        foreach (var autoNoticeEntry in autoNoticeTables)
        {
            var send = false;

            if (autoNoticeEntry.SendAfter != null &&
                DateTime.Compare((DateTime) autoNoticeEntry.SendAfter, DateTime.Now) > 0)
            {
                continue;
            }

            if (SharedObjects?.AgentSessions == null)
            {
                break;
            }

            foreach (var sharedObjectsAgentSession in SharedObjects.AgentSessions.Where(sharedObjectsAgentSession =>
                         sharedObjectsAgentSession.CharacterGameReady))
            {
                if (autoNoticeEntry.Receiver.ToLower() == "all")
                {
                    sharedObjectsAgentSession.SendNotice(autoNoticeEntry.Notice);
                    send = true;
                }

                if (autoNoticeEntry.Receiver.ToLower() == "all" || !string.Equals(autoNoticeEntry.Receiver,
                        sharedObjectsAgentSession.SessionData.Charname,
                        StringComparison.CurrentCultureIgnoreCase)) continue;
                sharedObjectsAgentSession.SendNotice(autoNoticeEntry.Notice);
                send = true;
            }

            if (send)
            {
                context.AutoNotice.Remove(autoNoticeEntry);
            }
        }

        context.SaveChanges();
    }
}