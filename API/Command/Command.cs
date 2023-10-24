using API.Exceptions;
using LanguageExt.Common;
using Void = LanguageExt.Pipes.Void;

namespace API.Command;

public abstract class Command : IDisposable
{
    protected Command(string? name, string? syntax, string? description, IEnumerable<string>? aliases = null)
    {
        SubCommands = new List<Command>();
        Name = name;
        Syntax = syntax;
        Description = description;
        Aliases = new List<string>();
        if (aliases != null) Aliases.AddRange(aliases);
    }

    protected List<Command>? SubCommands { get; set; }
    private string? Name { get; set; }
    private string? Syntax { get; set; }
    private string? Description { get; set; }
    private List<string>? Aliases { get; set; }

    public void Dispose()
    {
        if (SubCommands == null) throw new DisposedException(nameof(Command));

        foreach (var subCommand in SubCommands) subCommand.Dispose();

        SubCommands = null;
        Name = null;
        Syntax = null;
        Description = null;
        Aliases = null;
    }

    public abstract void Execute(string[]? args);

    public List<Command>? GetSubCommands()
    {
        return SubCommands;
    }

    public Result<bool> HasSubCommands()
    {
        if (SubCommands == null) return new Result<bool>(new DisposedException(nameof(Command)));

        return SubCommands.Count != 0;
    }

    public string? GetName()
    {
        return Name;
    }

    public string? GetSyntax()
    {
        return Syntax;
    }

    public List<string>? GetAliases()
    {
        return Aliases;
    }

    public string? GetDescription()
    {
        return Description;
    }

    protected Result<Void> ExecuteHelpCommand()
    {
        if (SubCommands == null) return new Result<Void>(new DisposedException(nameof(Command)));

        foreach (var subCommand in SubCommands.Where(subCommand => subCommand.GetName()!.ToLower().Equals("help")))
            subCommand.Execute(null);

        return new Result<Void>();
    }
}