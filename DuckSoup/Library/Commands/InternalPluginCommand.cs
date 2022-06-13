using System.Collections.Generic;
using System.Linq;
using API.Command;

namespace DuckSoup.Library.Commands;

public class InternalPluginCommand : Command
{
    public InternalPluginCommand(string? name, string? syntax, string? description, IEnumerable<string>? aliases = null) : base(name, syntax, description, aliases)
    {
        var helpCommand = new HelpCommand(SubCommands);
    }

    public void AddCommands(List<Command> commands)
    {
        SubCommands?.AddRange(commands);
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