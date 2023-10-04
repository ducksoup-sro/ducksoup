using API.Command;

namespace DuckSoup.Library.Commands;

public class StopCommand : Command
{
    public StopCommand() : base("stop", "stop", "Stops the filter", new[] { "exit" })
    {
    }

    public override void Execute(string[]? args)
    {
        Program.Stop();
    }
}