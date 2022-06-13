using API;
using API.Command;
using API.Database;
using API.Plugin;
using API.Server;
using API.ServiceFactory;
using API.Session;
using SilkroadSecurityAPI;

namespace Plugin.ReplaceCaptcha;

public class ReplaceCaptcha : IPlugin
{
    private bool RemoveCaptcha { get; set; }
    private string ReplacementCaptcha { get; set; } = "";
    private IServerManager? ServerManager { get; set; }

    private void InitSettings()
    {
        RemoveCaptcha = bool.Parse(DatabaseHelper.GetSettingOrDefault("RemoveCaptcha", false.ToString()));
        ReplacementCaptcha = DatabaseHelper.GetSettingOrDefault("ReplacementCaptcha", "0");
    }
    
    public void Dispose()
    {
        ServerManager?.UnregisterModuleHandler(ServerType, 0x2322, SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE);
        ServerManager = null!;
        RemoveCaptcha = false;
        ReplacementCaptcha = null!;
    }

    public string Name => "ReplaceCaptcha";
    public string Version => "1.0.0";
    public string Author => "b0ykoe";
    public ServerType ServerType => ServerType.GatewayServer;
    public void OnEnable()
    {
        InitSettings();
        ServerManager = ServiceFactory.Load<IServerManager>(typeof(IServerManager));
        ServerManager?.RegisterModuleHandler(ServerType, 0x2322, SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE);
    }

    public void OnServerStart(IAsyncServer server)
    {
        server.PacketHandler.RegisterModuleHandler(0x2322, SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE);
        InitSettings();
    }

    public List<Command> RegisterCommands()
    {
        return new List<Command>();
    }
    
    private async Task<PacketResult> SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE(Packet packet, ISession session)
    {
        // if remove captcha is not enabled return nothing
        if (!RemoveCaptcha) return new PacketResult();

        // create new packet, write it the captcha code, send it to the server and block the packet to the client
        var removePacket = new Packet(0x6323, false);
        removePacket.WriteAscii(ReplacementCaptcha);
        await session.SendToServer(removePacket);
        return new PacketResult(PacketResultType.Block);
    }
}