using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_PARTY_MATCHING_LIST_RESPONSE : Packet
{
    public SERVER_PARTY_MATCHING_LIST_RESPONSE() : base(0xB06C)
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

        Reset();

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_MATCHING_LIST_RESPONSE();
    }
}