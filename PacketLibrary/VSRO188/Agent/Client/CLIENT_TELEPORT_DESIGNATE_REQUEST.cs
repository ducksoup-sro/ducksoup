using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_TELEPORT_DESIGNATE_REQUEST : Packet
{
    public uint TeleportId;
    
    public CLIENT_TELEPORT_DESIGNATE_REQUEST() : base(0x7059)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out TeleportId);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(TeleportId);
        return this;
    }

    public static Task<Packet> of(uint teleportId)
    {
        return new CLIENT_TELEPORT_DESIGNATE_REQUEST
        {
            TeleportId = teleportId
        }.Build();
    }
}