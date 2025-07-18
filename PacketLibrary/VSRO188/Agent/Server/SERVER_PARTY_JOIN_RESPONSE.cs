using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// TODO :: Where the fuck is this being used?
// None	0xB067	sro_client.OnJoinPartyAck
// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/Agent-packets
public class SERVER_PARTY_JOIN_RESPONSE : Packet
{
    public SERVER_PARTY_JOIN_RESPONSE() : base(0xB067)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        //throw new NotImplementedException();
    }

    public override async Task<Packet> Build()
    {
        //throw new NotImplementedException();

        //Reset();

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_JOIN_RESPONSE();
    }
}