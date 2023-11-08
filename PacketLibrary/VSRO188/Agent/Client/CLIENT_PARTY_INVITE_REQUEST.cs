using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_INVITE
public class CLIENT_PARTY_INVITE_REQUEST : Packet
{
    public uint GID;

    public CLIENT_PARTY_INVITE_REQUEST() : base(0x7062)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out GID);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(GID);
        return this;
    }

    public static Task<Packet> of(uint gid)
    {
        return new CLIENT_PARTY_INVITE_REQUEST
        {
            GID = gid
        }.Build();
    }
}