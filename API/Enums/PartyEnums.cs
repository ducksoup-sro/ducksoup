﻿namespace API.Enums;

public class PartyEnums
{
    [Flags]
    public enum PartyInfoFlag : byte
    {
        Options = 1,
        MemberList = 2,
    }
    
    public enum PartyLeaveType : byte
    {
        //UIIT_MSG_PARTY_LOGOUT
        //[%s] has been disconnected.
        Disconnected = 1,

        //UIIT_MSG_PARTY_SECEDE
        //[%s] has left the party.
        Left = 2,

        //LEAVE_PARTY_SERVER_MIGRATION %X
        ServerMigration = 3,

        //UIIT_MSG_PARTY_BOOTED
        //[%s] is banned from the party.
        Banned = 4,
    }
    
    public enum PartyMatchingJoinResult : ushort
    {
        Denied = 1,
        Accepted = 2,
        TimedOut = 3,
    }
    
    public enum PartyUpdateType : byte
    {
        Dismissed = 1,
        Joined = 2,
        Leave = 3,
        Member = 6,
        Leader = 9 // vsro
    }
    
    [Flags]
    public enum PartyMemberInfoFlag : byte
    {
        NameRefObjID = 1,
        Level = 2,
        Vitality = 4, // HP & MP
        Mastery = 8,
        JID = 16,
        Position = 32,
        Guild = 64,
        JobState = 128,
    }
    
    public enum PartyPurposeType : byte
    {
        Hunting = 0,
        Quest = 1,
        Trader = 2,
        Thief = 3
    }
    
    [Flags]
    public enum PartySettingsFlag : byte
    {
        None = 0,
        ExpShare = 1,
        ItemShare = 2,
        InviteWithoutMaster = 4,    
    }
}