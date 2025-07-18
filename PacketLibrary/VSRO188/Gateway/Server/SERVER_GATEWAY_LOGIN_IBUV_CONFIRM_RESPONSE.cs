using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_LOGIN#ibuv-confirm-response
public class SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE : Packet
{
    public uint CurAttempts;
    public uint MaxAttempts;

    public byte Result;

    public SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE() : base(0xA323)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x02)
            TryRead(out MaxAttempts)
                .TryRead(out CurAttempts);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        if (Result == 0x02)
        {
            TryWrite(MaxAttempts);
            TryWrite(CurAttempts);
        }

        return this;
    }

    public static Packet of(byte result, uint maxAttempts, uint curAttempts)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE
        {
            Result = result,
            MaxAttempts = maxAttempts,
            CurAttempts = curAttempts
        };
    }

    public static Packet of(uint maxAttempts, uint curAttempts)
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE
        {
            Result = 0x2,
            MaxAttempts = maxAttempts,
            CurAttempts = curAttempts
        };
    }

    public static Packet of()
    {
        return new SERVER_GATEWAY_LOGIN_IBUV_CONFIRM_RESPONSE
        {
            Result = 0x1
        };
    }
}