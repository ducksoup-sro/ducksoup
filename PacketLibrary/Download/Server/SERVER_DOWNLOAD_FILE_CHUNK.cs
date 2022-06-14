using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Download.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class SERVER_DOWNLOAD_FILE_CHUNK : IPacketStructure
{
    public static ushort MsgId => 0x1001;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte[] Data { get; set; } //*    byte[]  data       //4090 bytes of data or rest of the file

    public Task Read(Packet packet)
    {
        Data = packet.GetBytes();

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8Array(Data);

        return response;
    }

    public static Packet of(byte[] data)
    {
        return new SERVER_DOWNLOAD_FILE_CHUNK
        {
            Data = data
        }.Build();
    }
}