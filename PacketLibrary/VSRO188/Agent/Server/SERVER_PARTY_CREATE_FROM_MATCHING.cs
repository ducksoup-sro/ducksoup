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
        TryRead(out PartyInfoFlag);
        TryRead(out ID);
        if (PartyInfoFlag.HasFlag(PartyInfoFlag.Options))
        {
            TryRead(out LeaderJID);
            TryRead(out PartySettingsFlag);
        }

        if (PartyInfoFlag.HasFlag(PartyInfoFlag.MemberList))
        {
            TryRead(out MemberCount);
            for (var i = 0; i < MemberCount; i++) MemberInfos.Add(new PartyMemberInfo(this));
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(PartyInfoFlag);
        TryWrite(ID);
        if (PartyInfoFlag.HasFlag(PartyInfoFlag.Options))
        {
            TryWrite(LeaderJID);
            TryWrite(PartySettingsFlag);
        }

        if (PartyInfoFlag.HasFlag(PartyInfoFlag.MemberList))
        {
            TryWrite(MemberCount);
            MemberInfos.ForEach(partyMemberInfo => partyMemberInfo.Build(this));
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_PARTY_CREATE_FROM_MATCHING();
    }
}