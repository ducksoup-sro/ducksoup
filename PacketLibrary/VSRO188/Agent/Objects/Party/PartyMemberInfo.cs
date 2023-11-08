using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Party;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMemberInfo
{
    public PartyMemberInfoFlag MemberInfoFlag;
    public int JID;
    public string Name;
    public uint RefObjID;
    public byte Level;
    public byte Vitality;
    public ushort RID;
    public int DungeonX;
    public int DungeonY;
    public int DungeonZ;
    public short X;
    public short Y;
    public short Z;
    public ushort WorldId;
    public ushort LayerId;
    public string GuildName;
    public Job JobState;
    public uint PrimaryMastery;
    public uint SecondaryMastery;

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
        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JID))
        {
            packet.TryRead(out JID);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.NameRefObjID))
        {
            packet.TryRead(out Name)
                .TryRead(out RefObjID);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Level))
        {
            packet.TryRead(out Level);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Vitality))
        {
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            packet.TryRead(out Vitality);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Position))
        {
            packet.TryRead(out RID);
            if ((RID & 0x8000) != 0) // IsDungeon
            {
                packet.TryRead(out DungeonX)
                    .TryRead(out DungeonY)
                    .TryRead(out DungeonZ);
            }
            else
            {
                packet.TryRead(out X)
                    .TryRead(out Y)
                    .TryRead(out Z);
            }

            packet.TryRead(out WorldId)
                .TryRead(out LayerId);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Guild))
        {
            packet.TryRead(out GuildName);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JobState))
        {
            packet.TryRead(out JobState);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Mastery))
        {
            packet.TryRead(out PrimaryMastery)
                .TryRead(out SecondaryMastery);
        }

        return Task.CompletedTask;
    }

    public Packet Build(Packet packet)
    {
        // b0ykoe
        // we should set the MemberInfoFlag to all
        MemberInfoFlag = (PartyMemberInfoFlag)0xFF;

        packet.TryWrite(MemberInfoFlag);
        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JID))
        {
            packet.TryWrite(JID);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.NameRefObjID))
        {
            packet.TryWrite(Name)
                .TryWrite(RefObjID);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Level))
        {
            packet.TryWrite(Level);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Vitality))
        {
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            packet.TryWrite(Vitality);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Position))
        {
            packet.TryWrite(RID);
            if ((RID & 0x8000) != 0) // IsDungeon
            {
                packet.TryWrite(DungeonX)
                    .TryWrite(DungeonY)
                    .TryWrite(DungeonZ);
            }
            else
            {
                packet.TryWrite(X)
                    .TryWrite(Y)
                    .TryWrite(Z);
            }

            packet.TryWrite(WorldId)
                .TryWrite(LayerId);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Guild))
        {
            packet.TryWrite(GuildName);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.JobState))
        {
            packet.TryWrite(JobState);
        }

        if (MemberInfoFlag.HasFlag(PartyMemberInfoFlag.Mastery))
        {
            packet.TryWrite(PrimaryMastery)
                .TryWrite(SecondaryMastery);
        }

        return packet;
    }
}