using PacketLibrary.Enums;
using PacketLibrary.Enums.Agent.Logout;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_LOGOUT_CANCEL
public class SERVER_AGENT_LOGOUT_CANCEL_RESPONSE : IPacketStructure
{
    public static ushort MsgId => 0xb006;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public byte Result { get; set; }
    public LogoutErrorCode LogoutErrorCode { get; set; }

    public Task Read(Packet packet)
    {
        Result = packet.ReadUInt8(); // 1   byte    result
        if (Result == 2)
        {
            LogoutErrorCode = (LogoutErrorCode) packet.ReadUInt16(); // 2   ushort  errorCode
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);

        response.WriteUInt8(Result);
        if (Result == 2)
        {
            response.WriteUInt16(LogoutErrorCode);
        }

        return response;
    }

    public static Packet of(byte result)
    {
        return new SERVER_AGENT_LOGOUT_CANCEL_RESPONSE
        {
            Result = result,
        }.Build();
    }

    public static Packet of(LogoutErrorCode logoutErrorCode)
    {
        return new SERVER_AGENT_LOGOUT_CANCEL_RESPONSE
        {
            Result = 0x2,
            LogoutErrorCode = logoutErrorCode
        }.Build();
    }
}