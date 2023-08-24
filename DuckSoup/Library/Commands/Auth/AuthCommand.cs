using System.Linq;
using API;
using API.Command;
using API.ServiceFactory;
using API.Services;

namespace DuckSoup.Library.Commands.Auth;

public class AuthCommand : Command
{
    public AuthCommand() : base("auth", " <subcommand>", "none")
    {
        var helpCommand = new HelpCommand(SubCommands);
        SubCommands.Add(new AuthInvalidateCommand());
        SubCommands.Add(new AuthRegisterCommand());
        SubCommands.Add(new AuthChangePasswordCommand());
        SubCommands.Add(new AuthChangeRoleCommand());
        SubCommands.Add(new AuthDeleteCommand());
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