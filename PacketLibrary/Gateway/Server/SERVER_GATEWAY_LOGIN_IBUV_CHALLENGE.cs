using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-challenge
public class SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE : IPacketStructure
{
    public static ushort MsgId => 0x2322;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte ImageFlag { get; set; }
    public ushort ImageRemain { get; set; }
    public ushort ImageCompressed { get; set; }
    public ushort ImageUncompressed { get; set; }
    public ushort ImageWidth { get; set; }
    public ushort ImageHeight { get; set; }
    public byte[] ImageCompressedData { get; set; }

    public Task Read(Packet packet)
    {
        ImageFlag = packet.ReadUInt8(); // 1   byte    image.Flag
        ImageRemain = packet.ReadUInt16(); // 2   ushort  image.remain	//in bytes
        ImageCompressed = packet.ReadUInt16(); // 2   ushort  image.compressed //in bytes
        ImageUncompressed = packet.ReadUInt16(); // 2   ushort  image.uncompressed //in bytes
        ImageWidth = packet.ReadUInt16(); // 2   ushort  image.width //200
        ImageHeight = packet.ReadUInt16(); // 2   ushort  image.height //64
        ImageCompressedData = packet.ReadUInt8Array(packet.RemainingRead()); //     *   byte[]  image.compressedData

        // TODO :: check imageCompressedData - might be inserted wrongly
        
        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(ImageFlag); // 1   byte    image.Flag
        response.WriteUInt16(ImageRemain); // 2   ushort  image.remain	//in bytes
        response.WriteUInt16(ImageCompressed); // 2   ushort  image.compressed //in bytes
        response.WriteUInt16(ImageUncompressed); // 2   ushort  image.uncompressed //in bytes
        response.WriteUInt16(ImageWidth); // 2   ushort  image.width //200
        response.WriteUInt16(ImageHeight); // 2   ushort  image.height //64
        response.WriteUInt8Array(ImageCompressedData); //     *   byte[]  image.compressedData

        return response;
    }

    public static Packet of(byte imageFlag, ushort imageRemain, ushort imageCompressed,
        ushort imageUncompressed, ushort imageWidth, ushort imageHeight, byte[] imageCompressedData)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CHALLENGE()
        {
            ImageFlag = imageFlag,
            ImageRemain = imageRemain,
            ImageCompressed = imageCompressed,
            ImageUncompressed = imageUncompressed,
            ImageWidth = imageWidth,
            ImageHeight = imageHeight,
            ImageCompressedData = imageCompressedData
        }.Build();
    }
}