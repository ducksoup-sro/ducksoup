using API;
using API.Command;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using API.Services;

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
        var username = args[0];
        var user = _service.GetUser(username);
        _service.CreatePassword(args[1], out var passwordHash, out var passwordSalt);

        if (user == null)
        {
            Global.Logger.InfoFormat("Username {0} does not exist", username);
            return;
        }

        user.passwordSalt = passwordSalt;
        user.passwordHash = passwordHash;
        user.tokenVersion += 1;
        
        _service.AddUser(user);
        user = _service.GetUser(username);
        if (user != null && _service.VerifyPassword(args[1], user.passwordHash, user.passwordSalt))
        {
            Global.Logger.InfoFormat("User's {0}[{1}] password was successfully changed and invalidated.", user.username, user.userId);
            return;
        }

        Global.Logger.ErrorFormat("There was a error chaing password on the user {0}", username);
    }
}