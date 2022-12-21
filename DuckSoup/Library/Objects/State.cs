using System.Collections.Generic;
using API;
using API.Session;
using DuckSoup.Library.Objects.Skill;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Session;

// Partially from: https://github.com/SDClowen/RSBot/
public class State : IState
{
    public LifeState? LifeState { get; set; }
    public MotionState? MotionState { get; set; }
    public MovementType? MovementType { get; set; }
    public BodyState? BodyState { get; set; }
    public PvpState? PvpState { get; set; }
    public BattleState? BattleState { get; set; } = API.BattleState.InPeace;
    public ScrollState? ScrollState { get; set; } = API.ScrollState.Cancel;
    public float? WalkSpeed { get; set; }
    public float? RunSpeed { get; set; }
    public float? BerzerkSpeed { get; set; }
    public List<SkillInfo> ActiveBuffs { get; } = new();
    public void Deserialize(Packet packet)
    {
        LifeState = (LifeState)packet.ReadUInt8();
        packet.ReadUInt8(); //unkByte0
        MotionState = (MotionState)packet.ReadUInt8();
        BodyState = (BodyState)packet.ReadUInt8();
        WalkSpeed = packet.ReadFloat();
        RunSpeed = packet.ReadFloat();
        BerzerkSpeed = packet.ReadFloat();

        var buffCount = packet.ReadUInt8();
        for (var i = 0; i < buffCount; i++)
        {
            var id = packet.ReadUInt32();
            var token = packet.ReadUInt32();

            var buff = new SkillInfo(id, token);
            if (buff.Record == null)
                continue;

            if (buff.Record.ParamsContains(1701213281))
                packet.ReadBool(); //IsCreator

            ActiveBuffs.Add(buff);
        }
    }
}