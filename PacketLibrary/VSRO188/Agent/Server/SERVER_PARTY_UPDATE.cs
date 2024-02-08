using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Party;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_UPDATE
public class SERVER_PARTY_UPDATE : Packet
{
    public PartyErrorCode ErrorCode;
    public PartyLeaveType LeaveType;
    public PartyMemberInfo MemberInfo;
    public PartyUpdateType PartyUpdateType;
    public uint UserJID;

    public SERVER_PARTY_UPDATE() : base(0x3864)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead(out PartyUpdateType);
        switch (PartyUpdateType)
        {
            case PartyUpdateType.Dismissed:
                TryRead(out ErrorCode);
                break;
            case PartyUpdateType.Joined:
                MemberInfo = new PartyMemberInfo(this);
                break;
            case PartyUpdateType.Leave:
                TryRead(out UserJID);
                TryRead(out LeaveType);
                break;
            case PartyUpdateType.Member:
                TryRead(out UserJID);
                MemberInfo = new PartyMemberInfo(this);
                break;
            case PartyUpdateType.Leader:
                TryRead(out UserJID);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>((byte)PartyUpdateType);
        switch (PartyUpdateType)
        {
            case PartyUpdateType.Dismissed:
                TryWrite<byte>((byte)ErrorCode);
                break;
            case PartyUpdateType.Joined:
                MemberInfo.Build(this);
                break;
            case PartyUpdateType.Leave:
                TryWrite<uint>(UserJID);
                TryWrite<byte>((byte)LeaveType);
                break;
            case PartyUpdateType.Member:
                TryWrite<uint>(UserJID);
                MemberInfo.Build(this);
                break;
            case PartyUpdateType.Leader:
                TryWrite<uint>(UserJID);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_UPDATE();
    }
}