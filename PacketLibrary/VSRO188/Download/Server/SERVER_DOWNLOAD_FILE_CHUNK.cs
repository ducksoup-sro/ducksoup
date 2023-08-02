using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Download.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class SERVER_DOWNLOAD_FILE_CHUNK : Packet
{
    public SERVER_DOWNLOAD_FILE_CHUNK() : base(0x1001)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public byte[] Data { get; set; } //*    byte[]  data       //4090 bytes of data or rest of the file

    public override async Task Read()
    {
        Data = GetBytes();
    }

    public override async Task<Packet> Build()
    {
        Reset();
        foreach (var b in Data) TryWrite(b);
        return this;
    }

    public static Packet of(byte[] data)
    {
        return new SERVER_DOWNLOAD_FILE_CHUNK
        {
            Data = data
        };
    }
}