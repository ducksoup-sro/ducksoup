using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_CHARACTER_DATA_BEGIN : Packet
{
    public SERVER_CHARACTER_DATA_BEGIN() : base(0x34A5)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        //empty
    }

    public override async Task<Packet> Build()
    {
        //empty
        return this;
    }

    public static Packet of()
    {
        return new SERVER_CHARACTER_DATA_BEGIN();
    }
}