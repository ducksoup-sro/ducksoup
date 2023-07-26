using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_GUILD_MERCENARY_TERMINATE : Packet
{
    public CLIENT_GUILD_MERCENARY_TERMINATE() : base(0x725A, false, false)
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
        return new CLIENT_GUILD_MERCENARY_TERMINATE();
    }
}