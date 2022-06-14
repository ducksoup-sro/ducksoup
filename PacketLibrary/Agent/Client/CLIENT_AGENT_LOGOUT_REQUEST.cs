using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Logout;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT
public class CLIENT_AGENT_LOGOUT_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7005;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public LogoutMode LogoutMode { get; set; }
    
    public Task Read(Packet packet)
    {
        LogoutMode = (LogoutMode) packet.ReadUInt8();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(LogoutMode); // 1   byte    LogoutMode

        return response;
    }

    public static async Task<Packet> of(LogoutMode logoutMode)
    {
        return await Task.Run(() => new CLIENT_AGENT_LOGOUT_REQUEST()
        {
            LogoutMode = logoutMode,
        }.Build());
    }
}

