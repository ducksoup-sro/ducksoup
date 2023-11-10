using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_ENVIRONMENT_CELESTIAL_UPDATE
public class SERVER_ENVIRONMENT_CELESTIAL_UPDATE : Packet
{
    public ushort Moonphase; // 0-30
    public byte Hour; // 0-23
    public byte Minute; // 0-59
    
    public SERVER_ENVIRONMENT_CELESTIAL_UPDATE() : base(0x3027)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out Moonphase);
        TryRead(out Hour);
        TryRead(out Minute);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Moonphase);
        TryWrite(Hour);
        TryWrite(Minute);
        return this;
    }

    public static Task<Packet> of(ushort moonphase, byte hour, byte minute)
    {
        return new SERVER_ENVIRONMENT_CELESTIAL_UPDATE
        {
            Moonphase = moonphase,
            Hour = hour,
            Minute = minute
        }.Build();
    }
}