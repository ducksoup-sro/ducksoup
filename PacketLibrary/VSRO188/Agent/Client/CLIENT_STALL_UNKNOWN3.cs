using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_STALL_UNKNOWN3 : Packet
{
    public CLIENT_STALL_UNKNOWN3() : base(0x7160)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


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
        return new CLIENT_STALL_UNKNOWN3();
    }
}