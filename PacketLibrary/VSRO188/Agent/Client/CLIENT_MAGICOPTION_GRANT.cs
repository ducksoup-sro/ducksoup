using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_MAGICOPTION_GRANT : Packet
{
    public CLIENT_MAGICOPTION_GRANT() : base(0x34A9)
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
        return new CLIENT_MAGICOPTION_GRANT();
    }
}