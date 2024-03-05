using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Party;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATED_FROM_MATCHING
public class SERVER_PARTY_CREATE_FROM_MATCHING : Packet
{
    public int ID;
    public int LeaderJID;
    public byte MemberCount;
    public List<PartyMemberInfo> MemberInfos = new();
    public PartyInfoFlag PartyInfoFlag;
    public PartySettingsFlag PartySettingsFlag;

    public SERVER_PARTY_CREATE_FROM_MATCHING() : base(0x3065)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;

    public override PacketDirection ToDirection => PacketDirection.Client;


    public override async Task Read()
    {
        TryRead<PartyInfoFlag>(out PartyInfoFlag);
        TryRead<int>(out ID);
        if (PartyInfoFlag.HasFlag(PartyInfoFlag.Options))
        {
            TryRead<int>(out LeaderJID);
            TryRead<PartySettingsFlag>(out PartySettingsFlag);
        }

        if (PartyInfoFlag.HasFlag(PartyInfoFlag.MemberList))
        {
            TryRead<byte>(out MemberCount);
            for (var i = 0; i < MemberCount; i++) MemberInfos.Add(new PartyMemberInfo(this));
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite<byte>((byte)PartyInfoFlag);
        TryWrite<int>(ID);
        if (PartyInfoFlag.HasFlag(PartyInfoFlag.Options))
        {
            TryWrite<int>(LeaderJID);
            TryWrite<byte>((byte)PartySettingsFlag);
        }

        if (PartyInfoFlag.HasFlag(PartyInfoFlag.MemberList))
        {
            TryWrite<byte>(MemberCount);
            MemberInfos.ForEach(partyMemberInfo => partyMemberInfo.Build(this));
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_CREATE_FROM_MATCHING();
    }
}