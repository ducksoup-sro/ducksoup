using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent;

public class SERVER_INVENTORY_ENTITY_EQUIP_TIMER_STOP : IPacketStructure
{
    public static ushort MsgId => 0x3042;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public Task Read(Packet packet)
    {
        /*
            [S -> C][3042]
            F2 A7 04 00                                       ................ EntityId
            00                                                ................ action or something, big switch 
            -> 0 timer
            -> 2 pvp
         */
        throw new NotImplementedException();
    }

    public Packet Build()
    {
        throw new NotImplementedException();
    }
    
    public static Packet of()
    {
        throw new NotImplementedException();
    }
}