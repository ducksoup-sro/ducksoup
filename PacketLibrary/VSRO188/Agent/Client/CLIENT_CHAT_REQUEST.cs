using PacketLibrary.VSRO188.Agent.Enums.Chat;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT
public class CLIENT_CHAT_REQUEST : Packet
{
    public byte ChatIndex; // 1   byte    chatIndex

    public ChatType ChatType; // 1   byte    chatType
    public string Message; // 2   ushort  message.Length //     *   string  message
    public string? Receiver; //2   ushort  reciver.Length //    *   string  reciver

    public CLIENT_CHAT_REQUEST() : base(0x7025)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out ChatType);
        TryRead(out ChatIndex);
        if (ChatType == ChatType.PM) TryRead(out Receiver);
        TryRead(out Message);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        
        TryWrite(ChatType);
        TryWrite(ChatIndex);
        if (ChatType == ChatType.PM) TryWrite(Receiver);
        TryWrite(Message);
        return this;
    }

    public static Packet of(ChatType chatType, byte chatIndex, string receiver, string message)
    {
        return new CLIENT_CHAT_REQUEST
        {
            ChatType = chatType,
            ChatIndex = chatIndex,
            Receiver = receiver,
            Message = message
        };
    }

    public static Packet of(ChatType chatType, byte chatIndex, string message)
    {
        return new CLIENT_CHAT_REQUEST
        {
            ChatType = chatType,
            ChatIndex = chatIndex,
            Message = message
        };
    }
}