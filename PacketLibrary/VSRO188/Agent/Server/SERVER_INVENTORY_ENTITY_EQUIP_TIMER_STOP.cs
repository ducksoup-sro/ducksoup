using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_INVENTORY_ENTITY_EQUIP_TIMER_STOP : Packet
{
    public SERVER_INVENTORY_ENTITY_EQUIP_TIMER_STOP() : base(0x3042)
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
        return new SERVER_INVENTORY_ENTITY_EQUIP_TIMER_STOP();
    }
}