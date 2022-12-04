using log4net.Core;
using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_MATCHING_JOIN
public class SERVER_AGENT_PARTY_MATCHING_JOIN_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB06D;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public ushort JoinResult;
    public ushort ErrorCode;
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        switch (Result)
        {
            case 1:
                JoinResult = packet.ReadUInt16();  // 2   ushort    joinResult
                break;
            case 2:
                ErrorCode = packet.ReadUInt16();  // 2	ushort	errorCode 
                //ErrorCodes:
                //11292 = Cannot find corresponding party.
                break;
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result); // 1   byte    result
        switch (Result)
        {
            case 1:
                response.WriteUInt16(JoinResult);  // 2   ushort    joinResult
                break;
            case 2:
                response.WriteUInt16(ErrorCode);  // 2	ushort	errorCode 
                //ErrorCodes:
                //11292 = Cannot find corresponding party.
                break;
        }
        return response;
    }

    public static Packet ofJoinResult(ushort joinResult)
    {
        return new SERVER_AGENT_PARTY_MATCHING_JOIN_RESPONSE
        {
            Result = 1,
            JoinResult = joinResult
        }.Build();
    }

    public static Packet ofErrorCode(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_MATCHING_JOIN_RESPONSE
        {
            Result = 2,
            ErrorCode = errorCode
        }.Build();
    }
}

