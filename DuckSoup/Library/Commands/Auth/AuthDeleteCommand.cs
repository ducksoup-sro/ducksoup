using API;
using API.Command;
using API.Database.Services;
using API.ServiceFactory;

namespace DuckSoup.Library.Commands.Auth;

public class AuthDeleteCommand : Command
{
    private IUserService _service;

    public AuthDeleteCommand() : base("delete", "auth delete <username>", "Removes the user from the database.", new []{"rm"})
    {
    }

    public override void Execute(string[]? args)
    {
        _service ??= ServiceFactory.Load<IUserService>(typeof(IUserService));

        if (args == null || args.Length < 1 || args[0].Replace(" ", "") == "")
        {
            Global.Logger.InfoFormat("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }
    }
}