using api.Extensions;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects;

namespace API.Session;

public class ICharInfo
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
    
    #region entityData
    public long LastPositionUpdate;
    public Position CurPosition;
    public Position TargetPosition = new Position(0, 0);
    
    public uint UniqueCharId;
    public LifeState LifeState;
    public byte Unkbyte0;
    public MotionState MotionState;
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
    #endregion

    // Todo :: 
    [Obsolete("It's not completed and not tested, do not use yet")]
    public Position GetCalcPosition
    {
        get
        {
            if (TargetPosition.IsEmpty())
            {
                return CurPosition;
            }
            
            var time = (DateTime.UtcNow.ToUnixTimeMilliseconds() - LastPositionUpdate) / 1000.0; // Convert to seconds
            var speed = RunSpeed;

            double dx = TargetPosition.X - CurPosition.X;
            double dy = TargetPosition.Y - CurPosition.Y;
            var distance = CurPosition.DistanceTo(TargetPosition);

            // Ensure there is a distance to move
            if (distance == 0)
            {
                TargetPosition = new Position(0, 0);
                return CurPosition;
            }

            var dirX = dx / distance;
            var dirY = dy / distance;

            var newX = CurPosition.X + dirX * (speed / 10.0f) * time;
            var newY = CurPosition.Y + dirY * (speed / 10.0f) * time;

            var newPosition = new Position((float)newX, (float)newY);
            if (CurPosition.DistanceTo(newPosition) > distance)
            {
                CurPosition = TargetPosition;
                TargetPosition = new Position(0, 0);
                return CurPosition;
            }
            
            return newPosition;
        }
    }
}