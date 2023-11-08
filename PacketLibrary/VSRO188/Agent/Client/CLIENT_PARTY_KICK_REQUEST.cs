using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_KICK
public class CLIENT_PARTY_KICK_REQUEST : Packet
{
    public uint MemberJid;

    public CLIENT_PARTY_KICK_REQUEST() : base(0x7063)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out MemberJid);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(MemberJid);
        return this;
    }

    public static Task<Packet> of(uint memberJid)
    {
        return new CLIENT_PARTY_KICK_REQUEST
        {
            MemberJid = memberJid
        }.Build();
    }
}