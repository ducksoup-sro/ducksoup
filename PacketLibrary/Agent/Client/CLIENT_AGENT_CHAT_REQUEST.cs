using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Chat;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT
public class CLIENT_AGENT_CHAT_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x7025;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public ChatType ChatType { get; set; }
    public byte ChatIndex { get; set; }
    public string? Receiver { get; set; }
    public string Message { get; set; }
    
    public Task Read(Packet packet)
    {
        ChatType = (ChatType) packet.ReadUInt8(); // 1   byte    chatType
        ChatIndex = packet.ReadUInt8(); // 1   byte    chatIndex
        if(ChatType == ChatType.PM)
        {
            //2   ushort  reciver.Length
            //    *   string  reciver
            Receiver = packet.ReadAscii();
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
        response.WriteUInt8(ChatIndex);
        if(ChatType == ChatType.PM)
        {
            response.WriteAscii(Receiver);
        }
        response.WriteAscii(Message);

        return response;
    }

    public static Packet of(ChatType chatType, byte chatIndex, string receiver, string message)
    {
        return new CLIENT_AGENT_CHAT_REQUEST
        {
            ChatType = chatType,
            ChatIndex = chatIndex,
            Receiver = receiver,
            Message = message
        }.Build();
    }
    
    public static Packet of(ChatType chatType, byte chatIndex, string message)
    {
        return new CLIENT_AGENT_CHAT_REQUEST
        {
            ChatType = chatType,
            ChatIndex = chatIndex,
            Message = message
        }.Build();
    }
}

