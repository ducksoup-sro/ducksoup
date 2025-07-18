using PacketLibrary.VSRO188.Agent.Enums.Logout;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT_CANCEL
public class SERVER_LOGOUT_CANCEL_RESPONSE : Packet
{
    public LogoutErrorCode ErrorCode;
    public byte Result;

    public SERVER_LOGOUT_CANCEL_RESPONSE() : base(0xb006)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x02) TryRead(out ErrorCode);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        if (Result == 0x02) TryWrite(ErrorCode);
        return this;
    }

    public static Task<Packet> of(LogoutErrorCode errorCode)
    {
        return new SERVER_LOGOUT_CANCEL_RESPONSE
        {
            Result = 0x02,
            ErrorCode = errorCode
        }.Build();
    }
}