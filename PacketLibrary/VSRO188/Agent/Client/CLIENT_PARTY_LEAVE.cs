using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_LEAVE
public class CLIENT_PARTY_LEAVE : Packet
{
    public CLIENT_PARTY_LEAVE() : base(0x7061)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        // Empty
    }

    public override async Task<Packet> Build()
    {
        Reset();
        return this;
    }

    public static Task<Packet> of()
    {
        return new CLIENT_PARTY_LEAVE
        {
            
        }.Build();
    }
}