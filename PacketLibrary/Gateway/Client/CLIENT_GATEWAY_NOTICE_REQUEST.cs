using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_NOTICE#request
public class CLIENT_GATEWAY_NOTICE_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6104;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public byte ContentID { get; set; }
    
    public Task Read(Packet packet)
    {
        ContentID = packet.ReadUInt8(); // 1   byte    Content.ID

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(ContentID);

        return response;
    }

    public static Packet of(byte contentId)
    {
        return new CLIENT_GATEWAY_NOTICE_REQUEST
        {
            ContentID = contentId
        }.Build();
    }
}

