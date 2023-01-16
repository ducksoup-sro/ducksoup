namespace API.Objects;

// https://github.com/SDClowen/RSBot/
public interface IPosition
{
    IRegion Region { get; set; }
    float XOffset { get; set; }
    float YOffset { get; set; }
    float ZOffset { get; set; }
    float X { get; }
    float Y { get; }
    float XSectorOffset { get; }
    float YSectorOffset { get; }
    short Angle { get; set; }
    short WorldId { get; set; }
    short LayerId { get; set; }
}