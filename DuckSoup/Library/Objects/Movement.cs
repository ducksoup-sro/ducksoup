using API;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects;

// https://github.com/SDClowen/RSBot/
public class Movement : IMovement
{
    public MovementType Type { get; set; }
    public bool Moving { get; set; }
    public bool HasDestination { get; set; }
    public IPosition Destination { get; set; }
    public bool HasSource { get; set; }
    public IPosition Source { get; set; }
    public bool HasAngle { get; set; }
    public float Angle { get; set; }

    public static IMovement MotionFromPacket(Packet packet)
    {
        
            var result = new Movement
            {
                HasDestination = packet.ReadBool()
            };

            if (result.HasDestination)
            {
                result.Destination = Position.FromPacketConditional(packet, false);
            }
            else
            {
                packet.ReadUInt8(); //0 = Spinning, 1 = Sky-/Key-walking
                result.HasAngle = true;
                result.Angle = packet.ReadUInt16();
            }

            result.HasSource = packet.ReadBool();
            if (result.HasSource)
            {
                result.Source = new()
                {
                    Region = new Region(packet.ReadUInt16())
                };

                if (result.Source.Region.IsDungeon)
                {
                    result.Source.XOffset = packet.ReadInt32() / 10f;
                    result.Source.ZOffset = packet.ReadFloat();
                    result.Source.YOffset = packet.ReadInt32() / 10f;
                }
                else
                {
                    result.Source.XOffset = packet.ReadInt16() / 10f;
                    result.Source.ZOffset = packet.ReadFloat();
                    result.Source.YOffset = packet.ReadInt16() / 10f;
                }
            }

            return result;
        
    }

    public static IMovement FromPacket(Packet packet)
    {
        var result = new Movement
        {
            Source = Position.FromPacket(packet),
            HasDestination = packet.ReadBool(),
            Type = (MovementType) packet.ReadUInt8()
        };

        if (result.HasDestination)
        {
            result.Destination = Position.FromPacketConditional(packet, false);
        }
        else
        {
            packet.ReadUInt8(); //0 = Spinning, 1 = Sky-/Key-walking
            result.HasAngle = true;
            result.Angle = packet.ReadInt16();
        }

        return result;
    }
}