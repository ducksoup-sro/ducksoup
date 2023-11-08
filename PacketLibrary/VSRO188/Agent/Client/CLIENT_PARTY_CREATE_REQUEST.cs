using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATE
public class CLIENT_PARTY_CREATE_REQUEST : Packet
{
    public uint GID;
    public PartySettingsFlag PartySettings;

    public CLIENT_PARTY_CREATE_REQUEST() : base(0x7060)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        TryRead(out GID);
        TryRead(out PartySettings);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(GID);
        TryWrite(PartySettings);
        return this;
    }

    public static Task<Packet> of(uint gid, PartySettingsFlag partySettings)
    {
        return new CLIENT_PARTY_CREATE_REQUEST
        {
            GID = gid,
            PartySettings = partySettings
        }.Build();
    }
}