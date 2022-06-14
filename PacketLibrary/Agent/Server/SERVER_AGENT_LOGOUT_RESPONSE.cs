using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Logout;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT
public class SERVER_AGENT_LOGOUT_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xb005;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public byte Countdown { get; set; }
    public LogoutMode LogoutMode { get; set; }
    public LogoutErrorCode LogoutErrorCode { get; set; }
    
    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if(Result == 1)
        {
            Countdown = packet.ReadUInt8(); // 1   byte    Countdown   //in seconds
            LogoutMode = (LogoutMode) packet.ReadUInt8(); // 1   byte    LogoutMode
        }
        else if(Result == 2)
        {
            LogoutErrorCode = (LogoutErrorCode) packet.ReadUInt16(); // 2 ushort errorCode
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(Result);
        if(Result == 1)
        {
            response.WriteUInt8(Countdown);
            response.WriteUInt8(LogoutMode);
        }
        else if(Result == 2)
        {
            response.WriteUInt16(LogoutErrorCode);
        }

        return response;
    }

    public static Packet of(byte countdown, LogoutMode logoutMode)
    {
        return new SERVER_AGENT_LOGOUT_RESPONSE
        {
            Result  = 0x1,
            Countdown = countdown,
            LogoutMode = logoutMode
        }.Build();
    }
    
    public static Packet of(LogoutErrorCode logoutErrorCode)
    {
        return new SERVER_AGENT_LOGOUT_RESPONSE
        {
            Result  = 0x2,
            LogoutErrorCode = logoutErrorCode
        }.Build();
    }
}

