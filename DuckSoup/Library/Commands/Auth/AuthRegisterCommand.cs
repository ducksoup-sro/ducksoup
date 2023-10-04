using API.Command;
using API.Database.DuckSoup;
using API.ServiceFactory;
using API.Services;
using Serilog;

namespace DuckSoup.Library.Commands.Auth;

public class AuthRegisterCommand : Command
{
    private IUserService _service;

    public AuthRegisterCommand() : base("register", "auth register <username> <password>", "Registers a new user.",
        new[] { "reg" })
    {
    }

    public override void Execute(string[]? args)
    {
        _service ??= ServiceFactory.Load<IUserService>(typeof(IUserService));

        if (args == null || args.Length < 2 || args[0].Replace(" ", "") == "")
        {
            Log.Information("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }

        var username = args[0];
        _service.CreatePassword(args[1], out var passwordHash, out var passwordSalt);

        if (_service.GetUser(username) != null)
        {
            Log.Information("Username {0} already exists", username);
            return;
        }

        var user = new User
        {
            username = username,
            passwordHash = passwordHash,
            passwordSalt = passwordSalt,
            tokenVersion = 0
        };
        _service.AddUser(user);
        user = _service.GetUser(username);

        if (user != null)
        {
            Log.Information("User {0}[{1}] was successfully created", user.username, user.userId);
            return;
        }

        Log.Error("There was a error creating the user {0}", username);
    }
}