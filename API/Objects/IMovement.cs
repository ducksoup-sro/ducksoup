using SilkroadSecurityAPI;

namespace API.Session;

// https://github.com/SDClowen/RSBot/
public interface IMovement
{
    MovementType Type { get; set; }
    bool Moving { get; set; }
    bool HasDestination { get; set; }
    IPosition Destination { get; set; }
    bool HasSource { get; set; }
    IPosition Source { get; set; }
    bool HasAngle { get; set; }
    float Angle { get; set; }
}