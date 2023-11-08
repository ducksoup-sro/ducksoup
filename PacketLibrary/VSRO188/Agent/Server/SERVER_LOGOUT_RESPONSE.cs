using PacketLibrary.VSRO188.Agent.Enums.Logout;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT
public class SERVER_LOGOUT_RESPONSE : Packet
{
    public byte Result;
    public byte Countdown;
    public LogoutMode LogoutMode;
    public LogoutErrorCode ErrorCode;
    
    public SERVER_LOGOUT_RESPONSE() : base(0xb005)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out Result);
        switch (Result)
        {
            case 0x01:
                TryRead(out Countdown);
                TryRead(out LogoutMode);
                break;
            case 0x2:
                TryRead(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result); switch (Result)
        {
            case 0x01:
                TryWrite(Countdown);
                TryWrite(LogoutMode);
                break;
            case 0x2:
                TryWrite(ErrorCode);
                break;
        }
            

        return this;
    }

    public static Task<Packet> of(byte countdown, LogoutMode logoutMode)
    {
        return new SERVER_LOGOUT_RESPONSE
        {
            Result = 0x01,
            Countdown = countdown,
            LogoutMode = logoutMode
        }.Build();
    }
    
    public static Task<Packet> of(LogoutErrorCode errorCode)
    {
        return new SERVER_LOGOUT_RESPONSE
        {
            Result = 0x02,
            ErrorCode = errorCode
        }.Build();
    }
}