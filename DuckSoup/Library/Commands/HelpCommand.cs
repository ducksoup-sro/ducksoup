using System.Collections.Generic;
using System.Linq;
using API.Command;
using Serilog;

namespace DuckSoup.Library.Commands;

public class HelpCommand : Command
{
    public HelpCommand(List<Command> subCommands) : base("help", "help", "Shows the help page", new[] { "h", "hilfe" })
    {
        SubCommands = subCommands;
        subCommands.Insert(0, this);
    }

    public override void Execute(string[]? args)
    {
        foreach (var subCommand in SubCommands)
            if (subCommand.HasSubCommands() && !subCommand.GetName().Equals("help"))
            {
                var sublist = "";
                foreach (var command in subCommand.GetSubCommands())
                {
                    sublist += command.GetName();

                    if (command != subCommand.GetSubCommands().Last()) sublist += ", ";
                }

                Log.Information("Command: {0} - Syntax: {1} - Aliases: ({2}) | SubCommands: {3}", subCommand.GetName(),
                    subCommand.GetSyntax(), string.Join(", ", subCommand.GetAliases()), sublist);
            }
            else
            {
                Log.Information("Command: {0} - Syntax: {1} - Aliases: ({2}) | Description: {3}", subCommand.GetName(),
                    subCommand.GetSyntax(), string.Join(", ", subCommand.GetAliases()), subCommand.GetDescription());
            }
    }
}