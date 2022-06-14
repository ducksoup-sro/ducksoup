using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Download.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class SERVER_DOWNLOAD_FILE_COMPLETE : IPacketStructure
{
    public static ushort MsgId => 0xA004;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; } // 1   byte    result

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);

        return response;
    }

    public static Packet of(byte result)
    {
        return new SERVER_DOWNLOAD_FILE_COMPLETE
        {
            Result = result
        }.Build();
    }
}