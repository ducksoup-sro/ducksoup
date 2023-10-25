using LanguageExt;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Skill;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// Partially from: https://github.com/SDClowen/RSBot/
public class State
{
    public List<SkillInfo> ActiveBuffs = new();
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
        var state = new State();
        state.Deserialize(packet);
        return state;
    }
    
    public void Deserialize(Packet packet)
    {
        packet.TryRead(out LifeState)
            .TryRead<byte>(out var unk0)
            .TryRead(out MotionState)
            .TryRead(out BodyState)
            .TryRead(out WalkSpeed)
            .TryRead(out RunSpeed)
            .TryRead(out BerzerkSpeed)
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