using API;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public interface ISpawnedBionic : ISpawnedEntity
{
    bool AttackingPlayer { get; }
    int Health { get; set; }
    BadStatus BadEffect { get; set; }
    uint TargetId { get; set; }
    
    bool HasHealth => Health > 0;

    void ParseBionicDetails(Packet packet);
}