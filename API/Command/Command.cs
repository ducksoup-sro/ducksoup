using API.Exceptions;

namespace API.Command;

public abstract class Command : IDisposable
{
    protected List<Command>? SubCommands { get; set; }
    private string? Name { get; set; }
    private string? Syntax { get; set; }
    private string? Description { get; set; }
    private List<string>? Aliases { get; set; }

    protected Command(string? name, string? syntax, string? description, IEnumerable<string>? aliases = null)
    {
        SubCommands = new List<Command>(); 
        Name = name;
        Syntax = syntax;
        Description = description;
        Aliases = new List<string>();
        if (aliases != null) Aliases.AddRange(aliases);
    }

    public abstract void Execute(string[]? args);

    public List<Command>? GetSubCommands()
    {
        return SubCommands;
    }

    public bool HasSubCommands()
    {
        if (SubCommands == null)
        {
            throw new DisposedException(nameof(Command));
        }

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

    protected void ExecuteHelpCommand()
    {
        if (SubCommands == null)
        {
            throw new DisposedException(nameof(Command));
        }
        
        foreach (var subCommand in SubCommands.Where(subCommand => subCommand.GetName()!.ToLower().Equals("help")))
        {
            subCommand.Execute(null);
        }
    }

    public void Dispose()
    {
        if (SubCommands == null)
        {
            throw new DisposedException(nameof(Command));
        }

        foreach (var subCommand in SubCommands)
        {
            subCommand.Dispose();
        }

        SubCommands = null;
        Name = null;
        Syntax = null;
        Description = null;
        Aliases = null;
    }
}