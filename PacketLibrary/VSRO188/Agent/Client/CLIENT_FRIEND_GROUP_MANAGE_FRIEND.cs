using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_FRIEND_GROUP_MANAGE_FRIEND : Packet
{
    public CLIENT_FRIEND_GROUP_MANAGE_FRIEND() : base(0x7312, false, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server
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
        return new CLIENT_FRIEND_GROUP_MANAGE_FRIEND();
    }
}