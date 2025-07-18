using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_OnB117 : Packet
{
    public SERVER_OnB117() : base(0xB117)
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
        return new SERVER_OnB117();
    }
}