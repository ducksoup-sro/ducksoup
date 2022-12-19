using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public interface ISpawnedEntity
{
    uint Id { get; set; }
    uint UniqueId { get; }
    IMovement Movement { get; }
    IState State { get; }
    C_RefObjCommon RefObjCommon { get; }
    C_RefObjChar RefObjChar { get; }
    ObjectCountry Race { get; }
    ObjectGender Gender { get; }
    IPosition Position { get; }
    bool IsInDungeon { get; }

    public void Deserialize(Packet packet);
}