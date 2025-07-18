using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_SHARD_LIST#ping-response
public class SERVER_GATEWAY_SHARD_LIST_PING_RESPONSE : Packet
{
    public byte ErrorCode; // 1   byte    errorCode
    public byte FarmID; // 1   byte    Farm.ID
    public uint IPAddress; // 4   uint    IPAddress //IPv4


    public byte Result; // 1   byte    result

    public SERVER_GATEWAY_SHARD_LIST_PING_RESPONSE() : base(0xA107)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x01)
        {
            TryRead(out FarmID);
            TryRead(out IPAddress);
        }
        else
        {
            TryRead(out ErrorCode);
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();

        TryWrite(Result);
        if (Result == 0x01)
        {
            TryWrite(FarmID);
            TryWrite(IPAddress);
        }
        else
        {
            TryWrite(ErrorCode);
        }

        return this;
    }

    public static Packet of(byte result, byte farmId, uint ipAddress, byte errorCode)
    {
        return new SERVER_GATEWAY_SHARD_LIST_PING_RESPONSE
        {
            Result = result,
            FarmID = farmId,
            IPAddress = ipAddress,
            ErrorCode = errorCode
        };
    }
}