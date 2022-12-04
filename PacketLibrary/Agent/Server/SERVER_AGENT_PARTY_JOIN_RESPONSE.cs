using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// No wiki entry, 02. December 2022
public class SERVER_AGENT_PARTY_JOIN_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB067;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public uint OwnUserJID;
    
    public Task Read(Packet packet)
    {
        // TODO :: sro_client.OnJoinPartyAck
        Result = packet.ReadUInt8();
        OwnUserJID = packet.ReadUInt32();
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        response.WriteUInt32(OwnUserJID);
        return response;
    }

    public static Packet of(uint userJID)
    {
        return new SERVER_AGENT_PARTY_JOIN_RESPONSE
        {
            Result = 1,
            OwnUserJID = userJID
        }.Build();
    }
}

