using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Download.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class SERVER_DOWNLOAD_FILE_COMPLETE : Packet
{
    public byte Result; // 1   byte    result

    public SERVER_DOWNLOAD_FILE_COMPLETE() : base(0xA004)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        return this;
    }

    public static Packet of(byte result)
    {
        return new SERVER_DOWNLOAD_FILE_COMPLETE
        {
            Result = result
        };
    }
}