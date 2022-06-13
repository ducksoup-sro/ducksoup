using System;
using System.Collections.Generic;
using System.Linq;
using API;
using API.Command;
using API.Exceptions;
using API.ServiceFactory;
using DuckSoup.Library.Commands.Event;
using DuckSoup.Library.Commands.Plugin;
using DuckSoup.Library.Commands.Server;

namespace DuckSoup.Library.Commands;

public class CommandManager : ICommandManager
{
    private bool _stopped;

    public CommandManager()
    {
        ServiceFactory.Register<ICommandManager>(typeof(ICommandManager), this);

        _commands = new List<Command>();
        _helpCommand = new HelpCommand(_commands);
        _commands.Add(new ServerCommand());
        _commands.Add(new PluginCommand());
        _commands.Add(new EventCommand());
        _commands.Add(new StopCommand());
    }

    public List<Command> _commands { get; private set; }
    public Command _helpCommand { get; private set; }

    public void StartCommandLoop()
    {
        Global.Logger.Info("Enter `help` to see all commands!");
        while (!_stopped)
        {
            if (_commands == null)
            {
                throw new DisposedException(nameof(CommandManager));
            }
            
            var consoleInput = Console.ReadLine();
            ExecuteCommand(consoleInput);
        }
    }

    public void ExecuteCommand(string input)
    {
        var removeList = new List<Command>();

        var split = input?.Split(" ");

        if (split == null || split.Length == 0 || split[0] == "")
        {
            _helpCommand.Execute(null);
            return;
        }
            
        var commandFound = false;
        foreach (var command in _commands)
        {
            if (command.GetName() == null || command.GetAliases() == null)
            {
                removeList.Add(command);
                continue;
            }

            if (!command.GetName()!.ToLower().Equals(split[0].ToLower()) &&
                !command.GetAliases()!.Contains(split[0].ToLower()))
            {
                continue;
            }
                
            command.Execute(split.Skip(1).ToArray());
            commandFound = true;
            break;
        }

        foreach (var command in removeList)
        {
            _commands.Remove(command);
        }
            
        removeList.Clear();
            
        if (!commandFound)
        {
            _helpCommand.Execute(null);
        }
    }

    public void Dispose()
    {
        _stopped = true;
        _commands = null;
        _helpCommand = null;
    }
}