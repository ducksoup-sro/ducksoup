using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
public class Movement
{
    public MovementType Type;
    public bool Moving;
    public bool HasDestination;
    public Position Destination;
    public bool HasSource;
    public Position Source;
    public bool HasAngle;
    public float Angle;

    public static Movement MotionFromPacket(Packet packet)
    {

        packet.TryRead<bool>(out var hasDestination);
            var result = new Movement
            {
                HasDestination = hasDestination
            };

            if (result.HasDestination)
            {
                result.Destination = Position.FromPacketConditional(packet, false);
            }
            else
            {
                packet.TryRead<byte>(out var unk1); //0 = Spinning, 1 = Sky-/Key-walking
                packet.TryRead<ushort>(out var angle);
                
                result.HasAngle = true;
                result.Angle = angle;
            }

            packet.TryRead<bool>(out result.HasSource);
            if (result.HasSource)
            {
                packet.TryRead<ushort>(out var regionId);
                result.Source = new Position
                {
                    Region = new Region(regionId)
                };

                if (result.Source.Region.IsDungeon)
                {
                    packet.TryRead<int>(out var sourceXOffset)
                        .TryRead<float>(out var sourceZOffset)
                        .TryRead<int>(out var sourceYOffset);

                    result.Source.XOffset = sourceXOffset / 10f;
                    result.Source.ZOffset = sourceZOffset;
                    result.Source.YOffset = sourceYOffset / 10f;
                }
                else
                {
                    packet.TryRead<short>(out var sourceXOffset)
                        .TryRead<float>(out var sourceZOffset)
                        .TryRead<short>(out var sourceYOffset);

                    result.Source.XOffset = sourceXOffset / 10f;
                    result.Source.ZOffset = sourceZOffset;
                    result.Source.YOffset = sourceYOffset / 10f;
                }
            }

            return result;
        
    }

    public static Movement FromPacket(Packet packet)
    {
        packet.TryRead<bool>(out var hasDestination)
            .TryRead<MovementType>(out var movementType);
        
        var result = new Movement
        {
            Source = Position.FromPacket(packet),
            HasDestination = hasDestination,
            Type = movementType
        };


        if (result.HasDestination)
        {
            result.Destination = Position.FromPacketConditional(packet, false);
        }
        else
        {
            packet.TryRead<byte>(out var unk1); //0 = Spinning, 1 = Sky-/Key-walking
            result.HasAngle = true;
            packet.TryRead<float>(out result.Angle);
        }

        return result;
    }
}