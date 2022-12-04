using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_DELETE
public class SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB06B;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public uint MatchingID;
    public ushort ErrorCode;
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        switch (Result)
        {
            case 1:
                MatchingID = packet.ReadUInt32();  //     4   uint    Party.MatchingID
                break;
            case 2:
                ErrorCode = packet.ReadUInt16();  //     2	ushort	errorCode
                break;
        }
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        switch (Result)
        {
            case 1:
                response.WriteUInt32(MatchingID);
                break;
            case 2:
                response.WriteUInt16(ErrorCode);
                break;
        }
        return response;
    }

    public static Packet of(uint matchingId)
    {
        return new SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE
        {
            Result = 1,
            MatchingID = matchingId
        }.Build();
    }

    public static Packet of(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_MATCHING_DELETE_RESPONSE
        {
            Result = 2,
            ErrorCode = errorCode
        }.Build();
    }
}

