using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_PATCH#request
public class CLIENT_GATEWAY_PATCH_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6100;
    public static bool Encrypted => true;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public byte ContentId { get; set; }
    public string ModuleName { get; set; }
    public uint Version { get; set; }

    public Task Read(Packet packet)
    {
        ContentId = packet.ReadUInt8(); // 1   byte    Conent.ID
        // 2   ushort  Module.Name.Length
        //     *   string  Module.Name
        ModuleName = packet.ReadAscii();
        Version = packet.ReadUInt32(); // 4   uint    Version

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(ContentId);
        response.WriteAscii(ModuleName);
        response.WriteUInt32(Version);

        return response;
    }

    public static Packet of(byte contentId, string moduleName, uint version)
    {
        return new CLIENT_GATEWAY_PATCH_REQUEST()
        {
            ContentId = contentId,
            ModuleName = moduleName,
            Version = version
        }.Build();
    }
}