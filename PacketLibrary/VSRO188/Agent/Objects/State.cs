using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Skill;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// Partially from: https://github.com/SDClowen/RSBot/
public class State
{
    public List<SkillInfo> ActiveBuffs = new List<SkillInfo>();
    public BattleState BattleState = BattleState.InPeace;
    public float BerzerkSpeed;
    public BodyState BodyState;
    public LifeState LifeState;
    public MotionState MotionState;
    public MovementType MovementType;
    public PVPCape PvpCape;
    public PvpState PvpState;
    public float RunSpeed;
    public ScrollState ScrollState = ScrollState.Cancel;
    public float WalkSpeed;

    public static State FromPacket(Packet packet)
    {
        State state = new State();
        state.Deserialize(packet);
        return state;
    }

    public void Deserialize(Packet packet)
    {
        packet.TryRead(out LifeState)
            .TryRead<byte>(out byte unk0)
            .TryRead(out MotionState)
            .TryRead(out BodyState)
            .TryRead(out WalkSpeed)
            .TryRead(out RunSpeed)
            .TryRead(out BerzerkSpeed)
            .TryRead<byte>(out byte buffCount);

        for (int i = 0; i < buffCount; i++)
        {
            packet.TryRead<uint>(out uint id)
                .TryRead<uint>(out uint token);

            SkillInfo buff = new SkillInfo(id, token);
            if (buff.Record == null)
                continue;

            if (buff.Record.ParamsContains(1701213281))
                packet.TryRead<bool>(out bool isCreator);

            ActiveBuffs.Add(buff);
        }
    }

    public float GetSpeed()
    {
        float speed = MovementType switch
        {
            MovementType.Walking => WalkSpeed,
            MovementType.Running => RunSpeed,
            _ => WalkSpeed
        };

        if (BodyState == BodyState.Berserk)
        {
            speed = BerzerkSpeed;
        }

        return speed;
    }
}