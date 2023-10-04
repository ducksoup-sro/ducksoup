using API.Command;
using API.Server;
using API.ServiceFactory;
using Serilog;

namespace DuckSoup.Library.Commands.Server;

public class ServerStopCommand : Command
{
    private readonly IServerManager _serverManager;

    public ServerStopCommand() : base("stop", "stop <id>", "Stops a given server", new[] { "close" })
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
        var isNumber = int.TryParse(args[0], out id);
        if (isNumber == false)
        {
            ExecuteHelpCommand();
            return;
        }

        // var temp = _serverManager.Servers.Where(asyncServer => asyncServer.Service.ServiceId == id).ToList();
        // foreach (var asyncServer in temp)
        // {
        //     _serverManager.Stop(asyncServer.Service);
        // }
        // temp.Clear();
        Log.Information("Server with the ID {0} was stopped and removed", id);
    }
}