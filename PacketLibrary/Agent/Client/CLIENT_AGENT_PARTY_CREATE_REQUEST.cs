using API;
using API.Enums;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATE
public class CLIENT_AGENT_PARTY_CREATE_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7060;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint GID;
    public PartyEnums.PartySettingsFlag PartySettings;

    public Task Read(Packet packet)
    {
        GID = packet.ReadUInt32(); // 4   uint    GID             // GID of player you want to create the party with.
        PartySettings =
            (PartyEnums.PartySettingsFlag) packet.ReadUInt8(); // 1   byte partySettings // see PartySettingsFlag

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(GID);
        response.WriteUInt8(PartySettings);
        return response;
    }

    public static Packet of(uint gid, PartyEnums.PartySettingsFlag partySettings)
    {
        return new CLIENT_AGENT_PARTY_CREATE_REQUEST
        {
            GID = gid,
            PartySettings = partySettings
        }.Build();
    }
}