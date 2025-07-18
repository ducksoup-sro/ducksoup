using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGUT_SUCCESS
public class SERVER_LOGOUT_SUCCESS : Packet
{
    public SERVER_LOGOUT_SUCCESS() : base(0x300a)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        // empty
    }

    public override async Task<Packet> Build()
    {
        Reset();
        return this;
    }

    public static Packet of()
    {
        return new SERVER_LOGOUT_SUCCESS();
    }
}