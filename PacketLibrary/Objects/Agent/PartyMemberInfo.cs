using API;
using API.Enums;
using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Agent;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/PartyMemberInfo
public class PartyMemberInfo
{
    public PartyEnums.PartyMemberInfoFlag MemberInfoFlag;
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
        MemberInfoFlag = (PartyEnums.PartyMemberInfoFlag) packet.ReadUInt8(); // 1   byte    memberInfoFlag
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.JID))
        {
            JID = packet.ReadInt32();  // 4   int     memberInfo.JID
        }
        
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.NameRefObjID))
        {
            Name = packet.ReadAscii(); // 2   ushort  memberInfo.Name.Length
            //    *   string  memberInfo.Name
            RefObjID = packet.ReadUInt32(); //4   uint    memberInfo.RefObjID
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Level))
        {
            Level = packet.ReadUInt8(); // 1 byte memberInfo.Level
        }
        
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Vitality))
        {
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            Vitality = packet.ReadUInt8(); // 1   byte    memberInfo.Vitality // in 10% intervals
        }
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Position))
        {
            RID = packet.ReadUInt16(); // 2   ushort  memberInfo.RID
            if((RID & 0x8000) != 0) // IsDungeon
            {
                DungeonX = packet.ReadInt32(); // 4   int     memberInfo.X
                DungeonY = packet.ReadInt32(); // 4   int     memberInfo.Y
                DungeonZ = packet.ReadInt32(); // 4   int     memberInfo.Z
            }
            else
            {
                X = packet.ReadInt16(); // 2   short   memberInfo.X
                Y = packet.ReadInt16(); // 2   short   memberInfo.Y
                Z = packet.ReadInt16(); // 2   short   memberInfo.Z
            }
            WorldId = packet.ReadUInt16(); // 2   ushort  memberInfo.WorldID
            LayerId = packet.ReadUInt16(); // 2   ushort  memberInfo.LayerID
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Guild))
        {
            GuildName = packet.ReadAscii(); // 2   ushort  memberInfo.Guild.Name.Length
            // *   string  memberInfo.Guild.Name
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.JobState))
        {
            JobState = (Job) packet.ReadUInt8(); // 1   byte    memberInfo.JobState
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Mastery))
        {
            PrimaryMastery = packet.ReadUInt32(); // 4   uint    memberInfo.PrimaryMastery
            SecondaryMastery = packet.ReadUInt32(); // 4   uint    memberInfo.SecondaryMastery
        }

        return Task.CompletedTask;
    }

    public Packet Build(Packet response)
    {
        // b0ykoe
        // we should set the MemberInfoFlag to all
        MemberInfoFlag = (PartyEnums.PartyMemberInfoFlag) 0xFF;
        
        response.WriteUInt8(MemberInfoFlag); // 1   byte    memberInfoFlag
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.JID))
        {
            response.WriteInt32(JID);  // 4   int     memberInfo.JID
        }
        
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.NameRefObjID))
        {
            response.WriteAscii(Name); // 2   ushort  memberInfo.Name.Length
            //    *   string  memberInfo.Name
            response.WriteUInt32(RefObjID); //4   uint    memberInfo.RefObjID
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Level))
        {
            response.WriteUInt8(Level); // 1 byte memberInfo.Level
        }
        
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Vitality))
        {
            // (MSB)                       (LSB)
            // | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
            // |       HP      |       MP      |
            response.WriteUInt8(Vitality); // 1   byte    memberInfo.Vitality // in 10% intervals
        }
        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Position))
        {
            response.WriteUInt16(RID); // 2   ushort  memberInfo.RID
            if((RID & 0x8000) != 0) // IsDungeon
            {
                response.WriteInt32(DungeonX); // 4   int     memberInfo.X
                response.WriteInt32(DungeonY); // 4   int     memberInfo.Y
                response.WriteInt32(DungeonZ); // 4   int     memberInfo.Z
            }
            else
            {
                response.WriteInt16(X); // 2   short   memberInfo.X
                response.WriteInt16(Y); // 2   short   memberInfo.Y
                response.WriteInt16(Z); // 2   short   memberInfo.Z
            }
            response.WriteUInt16(WorldId); // 2   ushort  memberInfo.WorldID
            response.WriteUInt16(LayerId); // 2   ushort  memberInfo.LayerID
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Guild))
        {
            response.WriteAscii(GuildName); // 2   ushort  memberInfo.Guild.Name.Length
            // *   string  memberInfo.Guild.Name
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.JobState))
        {
            response.WriteUInt8(JobState); // 1   byte    memberInfo.JobState
        }

        if(MemberInfoFlag.HasFlag(PartyEnums.PartyMemberInfoFlag.Mastery))
        {
            response.WriteUInt32(PrimaryMastery); // 4   uint    memberInfo.PrimaryMastery
            response.WriteUInt32(SecondaryMastery); // 4   uint    memberInfo.SecondaryMastery
        }

        return response;
    }
}