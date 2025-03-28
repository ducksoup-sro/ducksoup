using System.Linq;
using API.Command;
using API.Server;
using API.ServiceFactory;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DuckSoup.Library.Commands.Server;

public class ServerListCommand : Command
{
    private readonly IServerManager _serverManager;

    public ServerListCommand() : base("list", "list", "Shows all loaded Servers", new[] { "ls" })
    {
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));
    }

    public override void Execute(string[] args)
    {
        
        using var context = new API.Database.Context.DuckSoup();
        var services = context.Services.Include(b => b.LocalMachine_Machine)
            .Include(b => b.RemoteMachine_Machine).Include(b => b.SpoofMachine_Machine).ToList();

        foreach (var service in services)
        {
            var started = _serverManager.Servers.Any(server => server.Service.ServiceId == service.ServiceId);
            
            Log.Information("Id: {0} - Name: {1} - Started {2} - Type: {3} ",
                service.ServiceId,
                service.Name,
                started,
                service.ServerType);
        }
    }
}