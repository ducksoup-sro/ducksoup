using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_AUTH
public class SERVER_AUTH_RESPONSE : Packet
{
    public AuthenticationErrorCode AuthenticationErrorCode;
    public byte Result;

    public SERVER_AUTH_RESPONSE() : base(0xA103)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x02) TryRead(out AuthenticationErrorCode);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        if (Result == 0x02) TryWrite(AuthenticationErrorCode);
        return this;
    }

    public static Task<Packet> of()
    {
        return new SERVER_AUTH_RESPONSE().Build();
    }
}