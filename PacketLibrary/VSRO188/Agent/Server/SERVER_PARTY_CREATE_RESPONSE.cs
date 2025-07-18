using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATE
public class SERVER_PARTY_CREATE_RESPONSE : Packet
{
    public PartyErrorCode ErrorCode;
    public uint JID;
    public byte Result;

    public SERVER_PARTY_CREATE_RESPONSE() : base(0xB060)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead<byte>(out Result);
        switch (Result)
        {
            case 0x01:
                TryRead<uint>(out JID);
                break;
            case 0x2:
                TryRead<PartyErrorCode>(out ErrorCode);
                break;
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>(Result);
        switch (Result)
        {
            case 0x01:
                TryWrite<uint>(JID);
                break;
            case 0x2:
                TryWrite<ushort>((ushort)ErrorCode);
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