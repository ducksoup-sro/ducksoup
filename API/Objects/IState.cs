using SilkroadSecurityAPI;

namespace API.Session;

// Partially from: https://github.com/SDClowen/RSBot/
public interface IState
{
    LifeState? LifeState { get; set; }
    MotionState? MotionState { get; set; }
    MovementType? MovementType { get; set; }
    BodyState? BodyState { get; set; }
    PvpState? PvpState { get; set; }
    BattleState BattleState { get; set; }
    ScrollState ScrollState { get; set; }
    PVPCape PvpCape { get; set; }
    float? WalkSpeed { get; set; }
    float? RunSpeed { get; set; }
    float? BerzerkSpeed { get; set; }
    void Deserialize(Packet packet);
}