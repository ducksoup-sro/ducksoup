using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_CHARACTER_DATA : Packet
{
    public SERVER_CHARACTER_DATA() : base(0x3013, false, true)
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
        return new SERVER_CHARACTER_DATA();
    }
}