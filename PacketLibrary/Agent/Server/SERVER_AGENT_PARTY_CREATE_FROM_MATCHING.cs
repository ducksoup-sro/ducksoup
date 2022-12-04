using System.Reflection;
using API.Enums;
using PacketLibrary.Enums;
using PacketLibrary.Objects.Agent;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_CREATED_FROM_MATCHING 
public class SERVER_AGENT_PARTY_CREATE_FROM_MATCHING : IPacketStructure
{
    public static ushort MsgId => 0x3065;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public PartyEnums.PartyInfoFlag PartyInfoFlag;
    public int ID;
    public int LeaderJID;
    public PartyEnums.PartySettingsFlag PartySettingsFlag;
    public byte MemberCount;
    public List<PartyMemberInfo> MemberInfos = new List<PartyMemberInfo>();
    public Task Read(Packet packet)
    {
        PartyInfoFlag = (PartyEnums.PartyInfoFlag) packet.ReadUInt8(); // 1   byte    partyInfoFlag
        ID = packet.ReadInt32(); // 4   int     partyInfo.ID
        if(PartyInfoFlag.HasFlag(PartyEnums.PartyInfoFlag.Options))
        {
            LeaderJID = packet.ReadInt32();  // 4   int     partyInfo.LeaderJID
            PartySettingsFlag = (PartyEnums.PartySettingsFlag) packet.ReadUInt8();  // 1   byte    partyInfo.Settings  //see PartySettingsFlag
        }
        
        if(PartyInfoFlag.HasFlag(PartyEnums.PartyInfoFlag.MemberList))
        {
            MemberCount = packet.ReadUInt8(); // 1   byte    partyInfo.memberCount
            for (var i = 0; i < MemberCount; i++)
            {
                MemberInfos.Add(new PartyMemberInfo(packet));
            }
        }

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);
        response.WriteUInt8(PartyInfoFlag);
        response.WriteInt32(ID);
        if(PartyInfoFlag.HasFlag(PartyEnums.PartyInfoFlag.Options))
        {
            response.WriteInt32(LeaderJID);
            response.WriteUInt8(PartySettingsFlag);
        }
        
        if(PartyInfoFlag.HasFlag(PartyEnums.PartyInfoFlag.MemberList))
        {
            response.WriteUInt8(MemberCount);
            foreach (var partyMemberInfo in MemberInfos)
            {
                response = partyMemberInfo.Build(response);
            }
        }
        return response;
    }

    public static Packet ofOptions(int id, int leaderJID, PartyEnums.PartySettingsFlag partySettingsFlag)
    {
        return new SERVER_AGENT_PARTY_CREATE_FROM_MATCHING
        {
            PartyInfoFlag = PartyEnums.PartyInfoFlag.Options,
            ID = id,
            LeaderJID = leaderJID,
            PartySettingsFlag = partySettingsFlag
        }.Build();
    }
    
    public static Packet ofMemberList(int id, byte memberCount, List<PartyMemberInfo> memberInfos)
    {
        return new SERVER_AGENT_PARTY_CREATE_FROM_MATCHING
        {
            PartyInfoFlag = PartyEnums.PartyInfoFlag.MemberList,
            ID = id,
            MemberCount = memberCount,
            MemberInfos = memberInfos
        }.Build();
    }
}

