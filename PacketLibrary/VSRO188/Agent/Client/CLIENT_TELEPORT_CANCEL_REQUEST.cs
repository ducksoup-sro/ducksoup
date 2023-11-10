using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_TELEPORT_CANCEL_REQUEST : Packet
{
    public CLIENT_TELEPORT_CANCEL_REQUEST() : base(0x705B)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        //Empty
    }

    public override async Task<Packet> Build()
    {
        Reset();
        return this;
    }

    public static Task<Packet> of()
    {
        return new CLIENT_TELEPORT_CANCEL_REQUEST
        {
            
        }.Build();
    }
}