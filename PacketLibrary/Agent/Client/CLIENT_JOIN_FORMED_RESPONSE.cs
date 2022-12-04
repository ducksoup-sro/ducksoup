using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_PLAYER_JOIN
public class CLIENT_JOIN_FORMED_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0x306E;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint RequestID;
    public uint UserJID;
    public byte RequestResponse;

    public Task Read(Packet packet)
    {
        RequestID = packet.ReadUInt32(); // 4   uint    RequestID
        UserJID = packet.ReadUInt32(); // 4   uint    UserJID
        RequestResponse = packet.ReadUInt8(); // 1   byte    RequestResponse // 0 = Deny, 1 = Accept
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(RequestID);
        response.WriteUInt32(UserJID);
        response.WriteUInt8(RequestResponse);
        return response;
    }

    public static Packet of(uint requestId, uint userJID, byte requestResponse)
    {
        return new CLIENT_JOIN_FORMED_RESPONSE
        {
            RequestID = requestId,
            UserJID = userJID,
            RequestResponse = requestResponse
        }.Build();
    }
}