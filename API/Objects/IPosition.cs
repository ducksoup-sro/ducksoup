namespace API.Objects;

// https://github.com/SDClowen/RSBot/
public class IPosition
{
    public IRegion Region { get; set; }
    public float XOffset { get; set; }
    public float YOffset { get; set; }
    public float ZOffset { get; set; }
    public short Angle { get; set; }
    public short WorldId { get; set; }
    public short LayerId { get; set; }
}