using PacketLibrary.Enums;
using PacketLibrary.Objects.Gateway;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_NOTICE#response
public class SERVER_GATEWAY_NOTICE_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA104;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Count { get; set; }
    public List<Notice> Notices = new();
    
    public Task Read(Packet packet)
    {
        Count = packet.ReadUInt8();
        for (int i = 0; i < Count; i++)
        {
            Notices.Add(new Notice(packet));
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Count);
        foreach (var notice in Notices)
        {
            notice.build(response);
        }
        
        return response;
    }

    public static Packet of()
    {
        throw new NotImplementedException();
    }
}

