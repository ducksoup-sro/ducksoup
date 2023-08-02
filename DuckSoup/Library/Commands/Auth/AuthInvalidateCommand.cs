using API;
using API.Command;
using API.ServiceFactory;
using API.Services;

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
        var username = args[0];
        var user = _service.GetUser(username);
        if (user == null)
        {
            Global.Logger.InfoFormat("Username {0} does not exist", username);
            return;
        }
        var oldTokenVersion = user.tokenVersion;

        user.tokenVersion += 1;
        _service.AddUser(user);
        user = _service.GetUser(username);
        
        if (user != null && user.tokenVersion == (oldTokenVersion + 1))
        {
            Global.Logger.InfoFormat("User {0}[{1}] was successfully invalidated", user.username, user.userId);
            return;
        }

        Global.Logger.ErrorFormat("There was a error invalidating the user {0}", username);
    }
}