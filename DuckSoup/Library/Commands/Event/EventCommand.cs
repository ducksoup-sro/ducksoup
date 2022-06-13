using System.Linq;
using API.Command;

namespace DuckSoup.Library.Commands.Event;

public class EventCommand : Command
{
    public EventCommand() : base("event", "event <subcommand>", "none", new[] {"ec"})
    {
            var helpCommand = new HelpCommand(SubCommands);
            SubCommands.Add(new EventListCommand());
            SubCommands.Add(new EventLoadCommand());
            SubCommands.Add(new EventUnloadCommand());
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