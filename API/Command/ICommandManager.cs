using LanguageExt.Common;
using Void = LanguageExt.Pipes.Void;

namespace API.Command;

public interface ICommandManager : IDisposable
{
    List<Command> _commands { get; }
    Command _helpCommand { get; }

    Result<Void> StartCommandLoop();
    void ExecuteCommand(string input);
}