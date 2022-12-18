using API;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedPlayerGuild
{
    public string Name { get; set; }
    public uint Id { get; set; }
    public SpawnedPlayerGuildMember Member { get; set; }
    public SpawnedPlayerUnion Union { get; set; }
    public uint LastCrestRev { get; set; }
    public bool IsFriendly { get; set; }
    internal static SpawnedPlayerGuild FromPacket(Packet packet)
    {
        var result = new SpawnedPlayerGuild
        {
            Id = packet.ReadUInt32(),
            Member = new SpawnedPlayerGuildMember
            {
                Nickname = packet.ReadAscii()
            },
            LastCrestRev = packet.ReadUInt32(),
            Union = new SpawnedPlayerUnion
            {
                Id = packet.ReadUInt32(),
                LastCrestRev = packet.ReadUInt32()
            }
        };

        result.IsFriendly = packet.ReadBool();
        result.Member.FortSiegeAuthority = (FortSiegeAuthority)packet.ReadUInt8();
        
        return result;
    }
}