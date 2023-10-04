namespace API.Command;

public interface ICommandManager : IDisposable
{
    List<Command> _commands { get; }
    Command _helpCommand { get; }

    void StartCommandLoop();
    void ExecuteCommand(string input);
}