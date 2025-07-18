using System.Collections.Generic;
using System.Linq;
using API.Command;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DuckSoup.Library.Commands.Server;

public class ServerListCommand : Command
{
    private readonly IServerManager _serverManager;

    public ServerListCommand() : base("list", "list", "Shows all loaded Servers", new[]
    {
        "ls"
    })
    {
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));
    }

    public override void Execute(string[] args)
    {

        using API.Database.Context.DuckSoup context = new API.Database.Context.DuckSoup();
        List<Service> services = context.Services.Include(b => b.LocalMachine_Machine)
            .Include(b => b.RemoteMachine_Machine).Include(b => b.SpoofMachine_Machine).ToList();

        foreach (Service service in services)
        {
            bool started = _serverManager.Servers.Any(server => server.Service.ServiceId == service.ServiceId);

            Log.Information("Id: {0} - Name: {1} - Started {2} - Type: {3} ",
                service.ServiceId,
                service.Name,
                started,
                service.ServerType);
        }
    }
}