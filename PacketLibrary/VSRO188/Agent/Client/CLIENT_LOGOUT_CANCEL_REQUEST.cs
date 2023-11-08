using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT_CANCEL
public class CLIENT_LOGOUT_CANCEL_REQUEST : Packet
{
    public CLIENT_LOGOUT_CANCEL_REQUEST() : base(0x7006)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        // empty
    }

    public override async Task<Packet> Build()
    {
        Reset();
        return this;
    }

    public static Task<Packet> of()
    {
        return new CLIENT_LOGOUT_CANCEL_REQUEST
        {
        }.Build();
    }
}