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

    public void OnServerStart(IFakeServer server);

    public List<Command.Command> RegisterCommands();

    /// <summary>Called when the dashboard triggers "reload settings". Override in plugin to re-read config.</summary>
    public void InitSettings() { }
}