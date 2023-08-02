using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Skill;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// Partially from: https://github.com/SDClowen/RSBot/
public class State
{
    public LifeState LifeState;
    public MotionState MotionState;
    public MovementType MovementType;
    public BodyState BodyState;
    public PvpState PvpState;
    public BattleState BattleState = BattleState.InPeace;
    public ScrollState ScrollState = ScrollState.Cancel;
    public PVPCape PvpCape;
    public float WalkSpeed;
    public float RunSpeed;
    public float BerzerkSpeed;
    public List<SkillInfo> ActiveBuffs = new();
    public void Deserialize(Packet packet)
    {
        packet.TryRead<LifeState>(out LifeState)
            .TryRead<byte>(out var unk0)
            .TryRead<MotionState>(out MotionState)
            .TryRead<BodyState>(out BodyState)
            .TryRead<float>(out WalkSpeed)
            .TryRead<float>(out RunSpeed)
            .TryRead<float>(out BerzerkSpeed)
            .TryRead<byte>(out var buffCount);
            
        for (var i = 0; i < buffCount; i++)
        {
            packet.TryRead<uint>(out var id)
                .TryRead<uint>(out var token);

            var buff = new SkillInfo(id, token);
            if (buff.Record == null)
                continue;

            if (buff.Record.ParamsContains(1701213281))
                packet.TryRead<bool>(out var isCreator);

            ActiveBuffs.Add(buff);
        }
    }
}