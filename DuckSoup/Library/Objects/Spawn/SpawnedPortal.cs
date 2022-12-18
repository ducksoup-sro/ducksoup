using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public sealed class SpawnedPortal : SpawnedBionic
{
    public SpawnedPortal(uint objId) 
        : base(objId) { }
    public string OwnerName;
    public uint OwnerUniqueId;
    
    internal static SpawnedPortal FromPacket(Packet packet, uint characterId)
    {
        var result = new SpawnedPortal(characterId)
        {
            UniqueId = packet.ReadUInt32(),
            Movement =
            {
                Source = Objects.Position.FromPacket(packet)
            }
        };
        
        packet.ReadUInt8(); //unkByte0
        var unkByte1 = packet.ReadUInt8();
        packet.ReadUInt8(); //unkByte2
        var unkByte3 = packet.ReadUInt8();

        if (unkByte3 == 1)
        {
            //Regular portal
            packet.ReadUInt32(); //unkUINT0
            packet.ReadUInt32(); //unkUINT1
        }
        else if (unkByte3 == 6)
        {
            //Dimension hole
            result.OwnerName = packet.ReadAscii();
            result.OwnerUniqueId = packet.ReadUInt32();
        }

        if (unkByte1 == 1)
        {
            packet.ReadUInt32(); //unkUInt3
            packet.ReadUInt8(); //unkByte5
        }

        return result;
    }
}