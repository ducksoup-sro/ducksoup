using API.Command;
using API.Server;
using API.ServiceFactory;

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
        // foreach (var asyncServer in _serverManager.Servers)
        // {
        //     Log.Information("Id: {0} - Name: {1} - Started {2} - Type: {3} ",asyncServer.Service.ServiceId,
        //         asyncServer.Service.Name,
        //         asyncServer.Started,
        //         asyncServer.Service.ServerType);
        // }
    }
}