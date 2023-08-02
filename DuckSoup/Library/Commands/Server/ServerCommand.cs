using System.Linq;
using API.Command;

namespace DuckSoup.Library.Commands.Server;

public class ServerCommand : Command
{
    public ServerCommand() : base("server", "server <subcommand>", "none", new []{"ser"})
    {
        var helpCommand = new HelpCommand(SubCommands);
        SubCommands.Add(new ServerListCommand());
        SubCommands.Add(new ServerStartCommand());
        SubCommands.Add(new ServerStopCommand());
    }

    public override void Execute(string[]? args)
    {
        if (args == null || args.Length == 0 || args[0] == "")
        {
            ExecuteHelpCommand();
            return;
        }

        foreach (var command in SubCommands.Where(command =>
                     command.GetName().ToLower().Equals(args[0].ToLower()) ||
                     command.GetAliases().Contains(args[0].ToLower())))
        {
            command.Execute(args.Skip(1).ToArray());
            return;
        }

        ExecuteHelpCommand();
    }
}