using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedPlayerGuild
{
    public uint Id;
    public bool IsFriendly;
    public uint LastCrestRev;
    public SpawnedPlayerGuildMember Member;
    public string Name;
    public SpawnedPlayerUnion Union;

    internal static SpawnedPlayerGuild FromPacket(Packet packet)
    {
        var result = new SpawnedPlayerGuild();
        packet.TryRead(out result.Id)
            .TryRead(out var nickname);
        result.Member = new SpawnedPlayerGuildMember
        {
            Nickname = nickname
        };

        packet.TryRead(out result.LastCrestRev)
            .TryRead<uint>(out var unionId)
            .TryRead<uint>(out var unionLastCrestRev);
        result.Union = new SpawnedPlayerUnion
        {
            Id = unionId,
            LastCrestRev = unionLastCrestRev
        };

        packet.TryRead(out result.IsFriendly)
            .TryRead(out result.Member.FortSiegeAuthority);

        return result;
    }
}