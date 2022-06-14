using PacketLibrary.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-confirm-response
public class SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xA323;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public uint MaxAttempts { get; set; }
    public uint CurAttempts { get; set; }
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if(Result == 0x02)
        {
            MaxAttempts = packet.ReadUInt32(); // 4   uint    MaxAttempts
            CurAttempts = packet.ReadUInt32(); // 4   uint    CurAttempts
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result); // 1   byte    result
        if(Result == 0x02)
        {
            response.WriteUInt32(MaxAttempts); // 4   uint    MaxAttempts
            response.WriteUInt32(CurAttempts); // 4   uint    CurAttempts
        }
        
        return response;
    }

    public static Packet of(byte result, uint maxAttempts, uint curAttempts)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE()
        {
            Result = result,
            MaxAttempts = maxAttempts,
            CurAttempts = curAttempts
        }.Build();
    }
    
    public static Packet of(uint maxAttempts, uint curAttempts)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE()
        {
            Result = 0x2,
            MaxAttempts = maxAttempts,
            CurAttempts = curAttempts
        }.Build();
    }
    
    public static Packet of()
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE()
        {
            Result = 0x1,
        }.Build();
    }
}

