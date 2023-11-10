using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_TELEPORT_USE
public class CLIENT_TELEPORT_USE_REQUEST : Packet
{
    public uint NpcUniqueId;
    public byte TeleportType;
    public uint RefTeleportId;
    public byte UnkByte0;
    public byte GuideTeleportType;
    
    public CLIENT_TELEPORT_USE_REQUEST() : base(0x705A)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out NpcUniqueId);
        TryRead(out TeleportType);
        switch (TeleportType)
        {
            case 0x02:
                TryRead(out RefTeleportId);
                break;
            case 0x03:
                TryRead(out UnkByte0);
                break;
            case 0x05:
                TryRead(out GuideTeleportType);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(NpcUniqueId);
        TryWrite(TeleportType);
        switch (TeleportType)
        {
            case 0x02:
                TryWrite(RefTeleportId);
                break;
            case 0x03:
                TryWrite(UnkByte0);
                break;
            case 0x05:
                TryWrite(GuideTeleportType);
                break;
        }
        return this;
    }

    public static Packet of()
    {
        return new CLIENT_TELEPORT_USE_REQUEST();
    }
}