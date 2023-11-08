using PacketLibrary.VSRO188.Agent.Enums;

namespace API.Session;

public abstract class ICharInfo
{
    public uint serverTime;
    public uint refObjId;
    public byte scale;
    public byte curLevel;
    public byte maxLevel;
    public ulong expOffset;
    public uint sExpOffset;
    public ulong remainGold;
    public uint remainSkillPoint;
    public ushort remainStatPoint;
    public byte remainHwanCount;
    public uint gatheredExpPoint;
    public uint hp;
    public uint mp;
    public byte autoInverstExp;
    public byte dailyPk;
    public ushort totalPk;
    public uint pkPenaltyPoint;
    public byte hwanLevel;
    public PVPCape pvpCape;
    public uint uniqueCharId;
    public LifeState lifeState;
    public byte unkbyte0;
    public byte motionState;
    public BodyState bodyState;
    public float walkSpeed;
    public float runSpeed;
    public float hwanSpeed;
    public string name;
    public string jobName;
    public Job jobType;
    public byte jobLevel;
    public uint jobExp;
    public uint jobContribution;
    public uint jobReward;
    public PvpState pvpState;
    public bool transportFlag;
    public BattleState inCombat;
    public uint transportUniqueId;
    public byte pvpFlag;
    public ulong guideFlag;
    public uint jid;
    public byte gmFlag;
}