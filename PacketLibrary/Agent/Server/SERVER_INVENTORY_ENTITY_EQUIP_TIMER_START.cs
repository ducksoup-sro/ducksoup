using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent;

public class SERVER_INVENTORY_ENTITY_EQUIP_TIMER_START : IPacketStructure
{
    public static ushort MsgId => 0x3041;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;
    
    public Task Read(Packet packet)
    {
        /*
            [S -> C][3041]
            F2 A7 04 00                                       ................ EntityId
            02                                                ................ Flag? checks always for 2 in client
            02                                                ................ Seems to add different kind of effect
            -> 1 seems to add a icon above, pvp
            -> 2 seems to be just the timer
            0A                                                ................ Seems to be always read as byte
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