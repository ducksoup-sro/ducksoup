using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#ping-response
public class SERVER_GATEWAY_SHARD_LIST_PING_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA106;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public byte FarmID { get; set; }
    public uint IPAddress { get; set; }
    public byte ErrorCode { get; set; }

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if (Result == 0x01)
        {
            FarmID = packet.ReadUInt8(); // 1   byte    Farm.ID
            IPAddress = packet.ReadUInt32(); // 4   uint    IPAddress //IPv4
        }
        else
        {
            ErrorCode = packet.ReadUInt8(); // 1   byte    errorCode
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        if (Result == 0x01)
        {
            response.WriteUInt8(FarmID);
            response.WriteUInt32(IPAddress); 
        }
        else
        {
            response.WriteUInt8(ErrorCode);
        }

        return response;
    }

    public static Packet of(byte result, byte farmId, uint ipAddress, byte errorCode)
    {
        return new SERVER_GATEWAY_SHARD_LIST_PING_RESPONSE()
        {
            Result = result,
            FarmID = farmId,
            IPAddress = ipAddress,
            ErrorCode = errorCode
        }.Build();
    }
}