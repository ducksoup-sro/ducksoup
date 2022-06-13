using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Download.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class CLIENT_DOWNLOAD_FILE_REQUEST : IPacketStructure
{
    public static ushort MsgId => 0x6004;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Client;
    public PacketDirection ToDirection => PacketDirection.Server;

    public uint Id { get; set; } // 4   uint    ID
    public uint Unk2 { get; set; } //4   uint    unk2
    //Drew: "Might be the high word of the id, that's just not implemented"

    public Task Read(Packet packet)
    {
        Id = packet.ReadUInt32();
        Unk2 = packet.ReadUInt32();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt32(Id);
        response.WriteUInt32(Unk2);

        return response;
    }

    public static async Task<Packet> of(uint id, uint unk2)
    {
        return await Task.Run(() => new CLIENT_DOWNLOAD_FILE_REQUEST
        {
            Id = id,
            Unk2 = unk2
        }.Build());
    }
}