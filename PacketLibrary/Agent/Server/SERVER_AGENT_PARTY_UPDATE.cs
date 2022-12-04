using System.Reflection;
using API.Enums;
using log4net.Core;
using PacketLibrary.Enums;
using PacketLibrary.Objects.Agent;
using SilkroadSecurityAPI;

namespace PacketLibrary.Agent.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/AGENT_PARTY_UPDATE
public class SERVER_AGENT_PARTY_UPDATE : IPacketStructure
{
    public static ushort MsgId => 0x3864;
    public static bool Encrypted => false;
    public static bool Massive => false;
    public PacketDirection FromDirection => PacketDirection.Server;
    public PacketDirection ToDirection => PacketDirection.Client;

    public PartyEnums.PartyUpdateType PartyUpdateType;
    public ushort ErrorCode;
    public PartyMemberInfo MemberInfo;
    public uint UserJID;
    public PartyEnums.PartyLeaveType LeaveType;

    public Task Read(Packet packet)
    {
        PartyUpdateType = (PartyEnums.PartyUpdateType) packet.ReadUInt8(); // 1   byte    partyUpdateType
        switch (PartyUpdateType)
        {
            case PartyEnums.PartyUpdateType.Dismissed:
                ErrorCode = packet.ReadUInt16();  // 2   ushort  errorCode
                //ErrorCodes:
                //11 = The party is dismissed.
                break;
            case PartyEnums.PartyUpdateType.Joined:
                MemberInfo = new PartyMemberInfo(packet); // *   PartyMemberInfo memberInfo
                break;
            case PartyEnums.PartyUpdateType.Leave:
                UserJID = packet.ReadUInt32(); // 4   uint    memberInfo.JID
                LeaveType = (PartyEnums.PartyLeaveType) packet.ReadUInt8(); // 1   byte    leaveType
                break;
            case PartyEnums.PartyUpdateType.Member:
                UserJID = packet.ReadUInt32(); // 4   uint            memberInfo.JID
                MemberInfo = new PartyMemberInfo(packet); //     *   PartyMemberInfo memberInfo  // updated memberInfo
                break;
            case PartyEnums.PartyUpdateType.Leader:
                UserJID = packet.ReadUInt32(); // 4   uint    memberInfo.ID
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }    

        return Task.CompletedTask;
    }

    public Packet Build()
    {
        var response = new Packet(MsgId, Encrypted, Massive);

        response.WriteUInt8(PartyUpdateType);
        switch (PartyUpdateType)
        {
            case PartyEnums.PartyUpdateType.Dismissed:
                response.WriteUInt16(ErrorCode);
                break;
            case PartyEnums.PartyUpdateType.Joined:
                MemberInfo = new PartyMemberInfo(response);
                break;
            case PartyEnums.PartyUpdateType.Leave:
                response.WriteUInt32(UserJID);
                response.WriteUInt8(LeaveType);
                break;
            case PartyEnums.PartyUpdateType.Member:
                response.WriteUInt32(UserJID);
                response = MemberInfo.Build(response);
                break;
            case PartyEnums.PartyUpdateType.Leader:
                response.WriteUInt32(UserJID); // 4   uint    memberInfo.ID
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }    

        return response;
    }

    public static Packet ofDismissed(ushort errorCode)
    {
        return new SERVER_AGENT_PARTY_UPDATE
        {
        PartyUpdateType = PartyEnums.PartyUpdateType.Dismissed,
        ErrorCode = errorCode
        }.Build();
    }
    
    public static Packet ofJoined(PartyMemberInfo memberInfo)
    {
        return new SERVER_AGENT_PARTY_UPDATE
        {
            PartyUpdateType = PartyEnums.PartyUpdateType.Joined,
            MemberInfo = memberInfo
        }.Build();
    }
    
    public static Packet ofLeave(uint userJID, PartyEnums.PartyLeaveType leaveType)
    {
        return new SERVER_AGENT_PARTY_UPDATE
        {
            PartyUpdateType = PartyEnums.PartyUpdateType.Leave,
            UserJID = userJID,
            LeaveType = leaveType
        }.Build();
    }
    
    public static Packet ofMember(uint userJID, PartyMemberInfo memberInfo)
    {
        return new SERVER_AGENT_PARTY_UPDATE
        {
            PartyUpdateType = PartyEnums.PartyUpdateType.Member,
            UserJID = userJID,
            MemberInfo = memberInfo
        }.Build();
    }
    
    public static Packet ofLeader(uint userJID)
    {
        return new SERVER_AGENT_PARTY_UPDATE
        {
            PartyUpdateType = PartyEnums.PartyUpdateType.Leader,
            UserJID = userJID
            
        }.Build();
    }
}

