using PacketLibrary.VSRO188.Agent.Enums.Logout;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT
public class CLIENT_LOGOUT_REQUEST : Packet
{
    public LogoutMode LogoutMode;

    public CLIENT_LOGOUT_REQUEST() : base(0x7005)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out LogoutMode);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(LogoutMode);
        return this;
    }

    public static Task<Packet> of(LogoutMode logoutMode)
    {
        return new CLIENT_LOGOUT_REQUEST
        {
            LogoutMode = logoutMode
        }.Build();
    }
}