using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_CHAT_RESTRICT
public class SERVER_AGENT_CHAT_RESTRICT : IPacketStructure
{
    public static ushort MsgId => 0x302D;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Restriction { get; set; } // 1	byte	restriction //in seconds

    public Task Read(Packet packet)
    {
        Restriction = packet.ReadUInt8();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Restriction);

        return response;
    }

    public static async Task<Packet> of(byte restriction)
    {
        return await Task.Run(() =>
            new SERVER_AGENT_CHAT_RESTRICT
            {
                Restriction = restriction
            }.Build());
    }
}