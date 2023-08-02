using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-challenge
public class SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE : Packet
{
    public ushort ImageCompressed;
    public byte[] ImageCompressedData;

    public byte ImageFlag;
    public ushort ImageHeight;
    public ushort ImageRemain;
    public ushort ImageUncompressed;
    public ushort ImageWidth;

    public SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE() : base(0x2322)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out ImageFlag)
            .TryRead(out ImageRemain)
            .TryRead(out ImageCompressed)
            .TryRead(out ImageUncompressed)
            .TryRead(out ImageWidth)
            .TryRead(out ImageHeight);
        ImageCompressedData = new byte[RemainingRead()];
        for (var i = 0; i < RemainingRead(); i++) TryRead(out ImageCompressedData[i]);
        // TODO :: check imageCompressedData - might be inserted wrongly
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(ImageFlag);
        TryWrite(ImageRemain);
        TryWrite(ImageCompressed);
        TryWrite(ImageUncompressed);
        TryWrite(ImageWidth);
        TryWrite(ImageHeight);
        foreach (var b in ImageCompressedData) TryWrite(b);
        return this;
    }

    public static Packet of(byte imageFlag, ushort imageRemain, ushort imageCompressed,
        ushort imageUncompressed, ushort imageWidth, ushort imageHeight, byte[] imageCompressedData)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE
        {
            ImageFlag = imageFlag,
            ImageRemain = imageRemain,
            ImageCompressed = imageCompressed,
            ImageUncompressed = imageUncompressed,
            ImageWidth = imageWidth,
            ImageHeight = imageHeight,
            ImageCompressedData = imageCompressedData
        };
    }
}