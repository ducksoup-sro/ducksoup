using PacketLibrary.VSRO188.Agent.Enums;

namespace API.Session;

public abstract class ICharInfo
{
    public uint ServerTime;
    public uint RefObjId;
    public byte Scale;
    public byte CurLevel;
    public byte MaxLevel;
    public ulong ExpOffset;
    public uint SExpOffset;
    public ulong RemainGold;
    public uint RemainSkillPoint;
    public ushort RemainStatPoint;
    public byte RemainHwanCount;
    public uint GatheredExpPoint;
    public uint Hp;
    public uint Mp;
    public byte AutoInverstExp;
    public byte DailyPk;
    public ushort TotalPk;
    public uint PkPenaltyPoint;
    public byte HwanLevel;
    public PVPCape PvpCape;
    public uint UniqueCharId;
    public LifeState LifeState;
    public byte Unkbyte0;
    public byte MotionState;
    public BodyState BodyState;
    public float WalkSpeed;
    public float RunSpeed;
    public float HwanSpeed;
    public string CharName;
    public string JobName;
    public Job JobType;
    public byte JobLevel;
    public uint JobExp;
    public uint JobContribution;
    public uint JobReward;
    public PvpState PvpState;
    public bool TransportFlag;
    public BattleState InCombat;
    public uint TransportUniqueId;
    public byte PvpFlag;
    public ulong GuideFlag;
    public uint Jid;
    public byte GmFlag;
}