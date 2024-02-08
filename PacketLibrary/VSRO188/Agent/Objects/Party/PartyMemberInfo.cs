using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Party;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMemberInfo
{
    public int DungeonX;
    public int DungeonY;
    public int DungeonZ;
    public string GuildName;
    public int JID;
    public Job JobState;
    public ushort LayerId;
    public byte Level;
    public PartyMemberInfoFlag MemberInfoFlag;
    public string Name;
    public uint PrimaryMastery;
    public uint RefObjID;
    public ushort RID;
    public uint SecondaryMastery;
    public byte Vitality;
    public ushort WorldId;
    public short X;
    public short Y;
    public short Z;

    public PartyMemberInfo()
    {
    }

    public PartyMemberInfo(Packet packet)
    {
        Read(packet);
    }

    public Task Read(Packet packet)
    {
        packet.TryRead(out MemberInfoFlag);
        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JID)) packet.TryRead(out JID);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.NameRefObjID))
            packet.TryRead(out Name)
                .TryRead(out RefObjID);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Level)) packet.TryRead(out Level);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Vitality))
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            packet.TryRead(out Vitality);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Position))
        {
            packet.TryRead(out RID);
            if ((RID & 0x8000) != 0) // IsDungeon
                packet.TryRead(out DungeonX)
                    .TryRead(out DungeonY)
                    .TryRead(out DungeonZ);
            else
                packet.TryRead(out X)
                    .TryRead(out Y)
                    .TryRead(out Z);

            packet.TryRead(out WorldId)
                .TryRead(out LayerId);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Guild)) packet.TryRead(out GuildName);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JobState)) packet.TryRead(out JobState);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Mastery))
            packet.TryRead(out PrimaryMastery)
                .TryRead(out SecondaryMastery);

        return Task.CompletedTask;
    }

    public Packet Build(Packet packet)
    {
        // b0ykoe
        // we should set the MemberInfoFlag to all
        MemberInfoFlag = (PartyMemberInfoFlag)0xFF;

        packet.TryWrite<byte>((byte)MemberInfoFlag);
        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JID)) packet.TryWrite<int>(JID);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.NameRefObjID))
            packet.TryWrite(Name)
                .TryWrite<uint>(RefObjID);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Level)) packet.TryWrite<byte>(Level);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Vitality))
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            packet.TryWrite<byte>(Vitality);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Position))
        {
            packet.TryWrite<ushort>(RID);
            if ((RID & 0x8000) != 0) // IsDungeon
                packet.TryWrite<int>(DungeonX)
                    .TryWrite<int>(DungeonY)
                    .TryWrite<int>(DungeonZ);
            else
                packet.TryWrite<short>(X)
                    .TryWrite<short>(Y)
                    .TryWrite<short>(Z);

            packet.TryWrite<ushort>(WorldId)
                .TryWrite<ushort>(LayerId);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Guild)) packet.TryWrite(GuildName);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JobState)) packet.TryWrite<byte>((byte)JobState);

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Mastery))
            packet.TryWrite<uint>(PrimaryMastery)
                .TryWrite<uint>(SecondaryMastery);

        return packet;
    }
}