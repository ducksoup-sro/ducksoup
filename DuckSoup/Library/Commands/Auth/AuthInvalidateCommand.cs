using API;
using API.Command;
using API.Database.Services;
using API.Event;
using API.ServiceFactory;

namespace DuckSoup.Library.Commands.Auth;

public class AuthInvalidateCommand : Command
{
    private IUserService _service;

    public AuthInvalidateCommand() : base("invalidate", "auth invalidate <username>", "Invalidates (logs out) the given user.", new []{"inv"})
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