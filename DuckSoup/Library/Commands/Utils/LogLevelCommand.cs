using API;
using API.Command;
using Serilog;
using Serilog.Events;

namespace DuckSoup.Library.Commands.Utils;

public class LogLevelCommand : Command
{
    public LogLevelCommand() : base("loglevel", "loglevel <0-5, default 2>", "Changes the loglevel")
    {

    }

    public override void Execute(string[]? args)
    {
        if (args == null || args.Length < 1 || args[0].Replace(" ", "") == "")
        {
            Log.Information("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }

        if (!int.TryParse(args[0], out int level))
        {
            Log.Information("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }

        if (level < 0 || level > 7)
        {
            Log.Information("The Syntax for the following command is: {0}", GetSyntax());
            return;
        }

        LogEventLevel eventLevel = (LogEventLevel)level;
        Helper.LoggingLevelSwitch.MinimumLevel = eventLevel;

        Log.Information("Log level switched to {0} until the next restart", eventLevel);
    }
}