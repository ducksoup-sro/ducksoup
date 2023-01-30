using API;
using API.Command;
using API.ServiceFactory;
using API.Services;

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
        var username = args[0];
        var user = _service.GetUser(username);
        
        if (user == null)
        {
            Global.Logger.InfoFormat("Username {0} does not exist", username);
            return;
        }
        
        _service.RemoveUser(user);
        
        if (_service.GetUser(username) == null)
        {
            Global.Logger.InfoFormat("User {0} was successfully deleted", username);
            return;
        }

        Global.Logger.ErrorFormat("There was a error deleting the user {0}", username);
    }
}