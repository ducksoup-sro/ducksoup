using API;
using API.Command;
using API.Database.Services;
using API.ServiceFactory;

namespace DuckSoup.Library.Commands.Auth;

public class AuthChangePasswordCommand : Command
{
    private IUserService _service;

    public AuthChangePasswordCommand() : base("changepassword", "auth changepassword <user> <new password>", "Changes the password of the user and invalidates the current token.", new []{"passwd"})
    {
        
    }

    public override void Execute(string[]? args)
    {
        _service ??= ServiceFactory.Load<IUserService>(typeof(IUserService));

        if (args == null || args.Length < 2 || args[0].Replace(" ", "") == "")
        {
            Global.Logger.InfoFormat("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }
    }
}