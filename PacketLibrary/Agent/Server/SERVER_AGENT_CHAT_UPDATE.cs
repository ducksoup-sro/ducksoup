using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Chat;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT_UPDATE
public class SERVER_AGENT_CHAT_UPDATE : IPacketStructure
{
    public static ushort MsgId => 0x3026;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public ChatType ChatType { get; set; }
    public uint SenderUniqueId { get; set; }
    public string SenderName { get; set; }
    public string Message { get; set; }
    
    
    public Task Read(Packet packet)
    {
        ChatType = (ChatType) packet.ReadUInt8(); // 1   byte    chatType
        switch (ChatType)
        {
            case ChatType.Notice:
                break;
            case ChatType.All:
            case ChatType.AllGM:
            case ChatType.NPC:
                SenderUniqueId = packet.ReadUInt32();  // 4   uint    message.Sender.UniqueID
                break;
            case ChatType.PM:
            case ChatType.Party:
            case ChatType.Guild:
            case ChatType.Global:
            case ChatType.Stall:
            case ChatType.Union:
            case ChatType.Accademy:
                // 2   ushort  message.Sender.Name.Length
                //     *   string  message.Sender.Name
                SenderName = packet.ReadAscii();
                break;
            default:
                break;
        }
        // 2   ushort  message.Length
        //     *   string  message
        Message = packet.ReadAscii();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(ChatType);
        switch (ChatType)
        {
            case ChatType.Notice:
                break;
            case ChatType.All:
            case ChatType.AllGM:
            case ChatType.NPC:
                 response.WriteUInt32(SenderUniqueId);
                 break;
            case ChatType.PM:
            case ChatType.Party:
            case ChatType.Guild:
            case ChatType.Global:
            case ChatType.Stall:
            case ChatType.Union:
            case ChatType.Accademy:
                response.WriteAscii(SenderName);
                break;
            default:
                break;
        }
        response.WriteAscii(Message);

        return response;
    }

    public static Packet of(ChatType chatType, uint senderUniqueId, string message)
    {
        return new SERVER_AGENT_CHAT_UPDATE
        {
            ChatType = chatType,
            SenderUniqueId = senderUniqueId,
            Message = message
        }.Build();
    }
    
    public static Packet of(ChatType chatType, string senderName, string message)
    {
        return new SERVER_AGENT_CHAT_UPDATE
        {
            ChatType = chatType,
            SenderName = senderName,
            Message = message
        }.Build();
    }
    
    public static Packet of(ChatType chatType, string message)
    {
        return new SERVER_AGENT_CHAT_UPDATE
        {
            ChatType = chatType,
            Message = message
        }.Build();
    }
}

