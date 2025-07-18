using System.Collections.Generic;
using System.Linq;
using API.Command;
using API.Database.DuckSoup;
using API.Server;
using API.ServiceFactory;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DuckSoup.Library.Commands.Server;

public class ServerStartCommand : Command
{
    private readonly IServerManager _serverManager;

    public ServerStartCommand() : base("start", "start <id>", "Starts a server", new[]
    {
        "create, load"
    })
    {
        _serverManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));
    }

    public override void Execute(string[]? args)
    {
        if (args.Length == 0)
        {
            ExecuteHelpCommand();
            return;
        }

        int id;
        bool isNumber = int.TryParse(args[0], out id);
        if (isNumber == false)
        {
            ExecuteHelpCommand();
            return;
        }

        IAsyncServer server = null;
        // foreach (var asyncServer in _serverManager.Servers.Where(asyncServer => asyncServer.Service.ServiceId == id))
        // {
        //     server = asyncServer;
        // }
        //
        // if (server != null)
        // {
        //     server.Start();
        //     Log.Information("Server with the ID {0} started", id);
        //     return;
        // }

        using API.Database.Context.DuckSoup service = new API.Database.Context.DuckSoup();
        List<Service> services = service.Services.Where(s => s.ServiceId == id).Include(b => b.LocalMachine_Machine)
            .Include(b => b.RemoteMachine_Machine).Include(b => b.SpoofMachine_Machine).ToList();

        if (services.Count == 0)
        {
            Log.Information("Server with the ID {0} was not found", id);
            return;
        }

        _serverManager.AddServer(services.First());
        _serverManager.Start(services.First());
        Log.Information("Server with the ID {0} was started", id);
    }
}