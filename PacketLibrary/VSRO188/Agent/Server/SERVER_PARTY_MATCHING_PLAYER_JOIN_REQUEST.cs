using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST : Packet
{
    public SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST() : base(0x706D, false, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client
;


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
        return new SERVER_PARTY_MATCHING_PLAYER_JOIN_REQUEST();
    }
}