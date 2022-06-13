using System.Collections.Generic;
using System.Linq;
using API.Command;

namespace DuckSoup.Library.Commands.Plugin;

public class PluginCommand : Command
{
    public PluginCommand() : base("plugin", "plugin <subcommand>", "none", new[] {"pl"})
    {
        var helpCommand = new HelpCommand(SubCommands);
        SubCommands.Add(new PluginListCommand());
        SubCommands.Add(new PluginLoadCommand());
        SubCommands.Add(new PluginUnloadCommand());
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