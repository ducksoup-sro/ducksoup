using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT_RESTRICT
public class SERVER_CHAT_RESTRICT : Packet
{
    public byte Restriction;

    public SERVER_CHAT_RESTRICT() : base(0x302D)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Restriction);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Restriction);
        return this;
    }

    public static Task<Packet> of(byte restriction)
    {
        return new SERVER_CHAT_RESTRICT
        {
            Restriction = restriction
        }.Build();
    }
}