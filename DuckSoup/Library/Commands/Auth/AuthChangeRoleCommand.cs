﻿using System;
using API;
using API.Command;
using API.Enums;
using API.Event;
using API.ServiceFactory;
using API.Services;

namespace DuckSoup.Library.Commands.Auth;

public class AuthChangeRoleCommand : Command
{
    private IUserService _service;

    public AuthChangeRoleCommand() : base("changepassword", "auth role <username> <role>", "Changes the role of the given user.", new []{"role"})
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
        var role = args[1];
        
        var user = _service.GetUser(username);
        if (user == null)
        {
            Global.Logger.InfoFormat("Username {0} does not exist", username);
            return;
        }
        var oldRole = user.Role;
        
        UserRole? userRole = null;
        foreach (var name in Enum.GetNames(typeof(UserRole)))
        {
            if (!role.ToUpper().Equals(name))
            {
                continue;
            }
            userRole = (UserRole?) Enum.Parse(typeof(UserRole), name);
        }

        if (userRole == null)
        {
            Global.Logger.InfoFormat("Role {0} does not exist", role);
            return;
        }
        
        user.Role = (UserRole) userRole;
        
        _service.AddUser(user);
        user = _service.GetUser(username);

        if (user != null && user.Role == userRole)
        {
            Global.Logger.InfoFormat("User {0}[{1}] has changed its role from {2} to {3}", user.username, user.userId, oldRole, user.Role);
            return;
        }
        
        Global.Logger.ErrorFormat("There was a error changing roles on the user {0}", username);
    }
}