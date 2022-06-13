using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Chat;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT
public class SERVER_AGENT_CHAT_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xB025;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public ChatErrorCode ErrorCode { get; set; }
    public ChatType ChatType { get; set; }
    public byte ChatIndex { get; set; }
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if(Result == 0x2)
        {
            ErrorCode = (ChatErrorCode) packet.ReadUInt16(); // 2   ushort  errorCode    
        }
        ChatType = (ChatType) packet.ReadUInt8(); // 1   byte    chatType
        ChatIndex = packet.ReadUInt8(); // 1   byte    chatIndex

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        if(Result == 0x02)
        {
            response.WriteUInt16(ErrorCode);
        }
        response.WriteUInt8(ChatType);
        response.WriteUInt8(ChatIndex);

        return response;
    }

    public static async Task<Packet> of(byte result, ChatErrorCode errorCode, ChatType chatType, byte chatIndex)
    {
        return await Task.Run(() => new SERVER_AGENT_CHAT_RESPONSE
        {
            Result  = result,
            ErrorCode  = errorCode,
            ChatType  = chatType,
            ChatIndex  = chatIndex,
        }.Build());
    }
    
    public static async Task<Packet> of(byte result, ChatType chatType, byte chatIndex)
    {
        return await Task.Run(() => new SERVER_AGENT_CHAT_RESPONSE
        {
            Result  = result,
            ChatType  = chatType,
            ChatIndex  = chatIndex,
        }.Build());
    }
}

