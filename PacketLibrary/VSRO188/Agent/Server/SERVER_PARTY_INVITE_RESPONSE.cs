using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_INVITE
public class SERVER_PARTY_INVITE_RESPONSE : Packet
{
    public PartyErrorCode ErrorCode;
    public byte Result;

    public SERVER_PARTY_INVITE_RESPONSE() : base(0xB062)
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

    public static Task<Packet> of(PartyErrorCode errorCode)
    {
        return new SERVER_PARTY_INVITE_RESPONSE
        {
            Result = 0x02,
            ErrorCode = errorCode
        }.Build();
    }
}