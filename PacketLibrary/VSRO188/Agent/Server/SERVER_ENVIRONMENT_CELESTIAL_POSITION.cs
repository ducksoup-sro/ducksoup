using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

public class SERVER_ENVIRONMENT_CELESTIAL_POSITION : Packet
{
    public uint CharacterUniqueId;
    public byte Hour; // 0-23
    public byte Minute; //0-59
    public ushort Moonphase; // 0-30

    public SERVER_ENVIRONMENT_CELESTIAL_POSITION() : base(0x3020)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out CharacterUniqueId);
        TryRead(out Moonphase);
        TryRead(out Hour);
        TryRead(out Minute);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(CharacterUniqueId);
        TryWrite(Moonphase);
        TryWrite(Hour);
        TryWrite(Minute);
        return this;
    }

    public static Task<Packet> of(uint characterUniqueId, ushort moonphase, byte hour, byte minute)
    {
        return new SERVER_ENVIRONMENT_CELESTIAL_POSITION
        {
            CharacterUniqueId = characterUniqueId,
            Moonphase = moonphase,
            Hour = hour,
            Minute = minute
        }.Build();
    }
}