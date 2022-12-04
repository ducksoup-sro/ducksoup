using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Client;

public class CLIENT_AGENT_PARTY_MATCHING_LIST_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x706C;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public byte PageIndex;

    public Task Read(Packet packet)
    {
        PageIndex = packet.ReadUInt8();
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(PageIndex);
        return response;
    }

    public static Packet of(byte pageIndex)
    {
        return new CLIENT_AGENT_PARTY_MATCHING_LIST_REQUEST
        {
            PageIndex = pageIndex
        }.Build();
    }
}