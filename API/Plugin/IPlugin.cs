#region

#endregion

#region

using API.Server;

#endregion

namespace API.Plugin;

public interface IPlugin : IDisposable
{
    public string Name { get; }
    public string Version { get; }
    public string Author { get; }
    public ServerType ServerType { get; }

    public void OnEnable();
    public void OnServerStart(IAsyncServer server);
    public List<Command.Command> RegisterCommands();
}