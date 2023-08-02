using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedPlayerGuild
{
    public string Name;
    public uint Id;
    public SpawnedPlayerGuildMember Member;
    public SpawnedPlayerUnion Union;
    public uint LastCrestRev;
    public bool IsFriendly;

    internal static SpawnedPlayerGuild FromPacket(Packet packet)
    {
        var result = new SpawnedPlayerGuild();
        packet.TryRead<uint>(out result.Id)
            .TryRead(out var nickname);
        result.Member = new SpawnedPlayerGuildMember
        {
            Nickname = nickname
        };

        packet.TryRead<uint>(out result.LastCrestRev)
            .TryRead<uint>(out var unionId)
            .TryRead<uint>(out var unionLastCrestRev);
        result.Union = new SpawnedPlayerUnion
        {
            Id = unionId,
            LastCrestRev = unionLastCrestRev
        };

        packet.TryRead<bool>(out result.IsFriendly)
            .TryRead <FortSiegeAuthority>(out result.Member.FortSiegeAuthority);
        
        return result;
    }
}