using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_INVITE
public class SERVER_AGENT_PARTY_INVITE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB062;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result;
    public ushort ErrorCode;
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if(Result == 2)
        {
            ErrorCode = packet.ReadUInt16(); // 2   ushort  errorCode
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        if(Result == 2)
        {
             response.WriteUInt16(ErrorCode);
        }

        return response;
    }

    public static Packet of()
    {
        return new SERVER_AGENT_PARTY_INVITE_RESPONSE
        {
            Result = 1
        }.Build();
    }
    
    public static Packet of(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_INVITE_RESPONSE
        {
            Result = 2,
            ErrorCode = errorCode
        }.Build();
    }
}

