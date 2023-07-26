using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_ITEM_BOX_LOG : Packet
{
    public CLIENT_ITEM_BOX_LOG() : base(0x7559, false, false)
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
        return new CLIENT_ITEM_BOX_LOG();
    }
}