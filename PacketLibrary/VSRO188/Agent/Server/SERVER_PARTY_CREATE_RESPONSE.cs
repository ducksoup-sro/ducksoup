using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATE
public class SERVER_PARTY_CREATE_RESPONSE : Packet
{
    public byte Result;
    public uint JID;
    public PartyErrorCode ErrorCode;

    public SERVER_PARTY_CREATE_RESPONSE() : base(0xB060)
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
                TryRead(out JID);
                break;
            case 0x2:
                TryRead(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Result);
        switch (Result)
        {
            case 0x01:
                TryWrite(JID);
                break;
            case 0x2:
                TryWrite(ErrorCode);
                break;
        }

        return this;
    }

    public static Task<Packet> of(uint jid)
    {
        return new SERVER_PARTY_CREATE_RESPONSE
        {
            Result = 0x01,
            JID = jid
        }.Build();
    }

    public static Task<Packet> of(PartyErrorCode errorCode)
    {
        return new SERVER_PARTY_CREATE_RESPONSE
        {
            Result = 0x02,
            ErrorCode = errorCode
        }.Build();
    }
}