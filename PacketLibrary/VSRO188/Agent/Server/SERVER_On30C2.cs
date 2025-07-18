using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_On30C2 : Packet
{
    public SERVER_On30C2() : base(0x30C2)
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

        //Reset();

        return this;
    }

    public static Packet of()
    {
        return new SERVER_On30C2();
    }
}