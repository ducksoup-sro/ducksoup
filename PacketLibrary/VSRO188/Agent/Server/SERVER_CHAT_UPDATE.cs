using PacketLibrary.VSRO188.Agent.Enums.Chat;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT_UPDATE
public class SERVER_CHAT_UPDATE : Packet
{
    public ChatType ChatType;
    public string Message;
    public string SenderName;
    public uint SenderUniqueId;

    public SERVER_CHAT_UPDATE() : base(0x3026)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out ChatType);
        switch (ChatType)
        {
            case ChatType.Notice:
                break;
            case ChatType.All:
            case ChatType.AllGM:
            case ChatType.NPC:
                TryRead(out SenderUniqueId);
                break;
            case ChatType.PM:
            case ChatType.Party:
            case ChatType.Guild:
            case ChatType.Global:
            case ChatType.Stall:
            case ChatType.Union:
            case ChatType.Accademy:
                TryRead(out SenderName);
                break;
        }
        TryRead(out Message);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(ChatType);
        switch (ChatType)
        {
            case ChatType.Notice:
                break;
            case ChatType.All:
            case ChatType.AllGM:
            case ChatType.NPC:
                TryWrite(SenderUniqueId);
                break;
            case ChatType.PM:
            case ChatType.Party:
            case ChatType.Guild:
            case ChatType.Global:
            case ChatType.Stall:
            case ChatType.Union:
            case ChatType.Accademy:
                TryWrite(SenderName);
                break;
        }
        TryWrite(Message);
        return this;
    }

    public static Task<Packet> of(ChatType chatType, uint senderUniqueId, string message)
    {
        return new SERVER_CHAT_UPDATE
        {
            ChatType = chatType,
            SenderUniqueId = senderUniqueId,
            Message = message
        }.Build();
    }

    public static Task<Packet> of(ChatType chatType, string senderName, string message)
    {
        return new SERVER_CHAT_UPDATE
        {
            ChatType = chatType,
            SenderName = senderName,
            Message = message
        }.Build();
    }

    public static async Task<Packet> of(ChatType chatType, string message)
    {
        return await new SERVER_CHAT_UPDATE
        {
            ChatType = chatType,
            Message = message
        }.Build();
    }
}