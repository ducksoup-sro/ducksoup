using API;
using API.Database.SRO_VT_SHARD;
using API.Objects;
using API.Objects.Cos;
using API.Objects.Inventory;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Cos : ICos
{
    public uint Id { get; set; }
    public uint UniqueId { get; init; }
    public IMovement Movement { get; }
    public IState State { get; }
    public _RefObjCommon RefObjCommon { get; }
    public _RefObjChar RefObjChar { get; }
    public ObjectCountry Race { get; }
    public ObjectGender Gender { get; }
    public IPosition Position { get; }
    public bool IsInDungeon { get; }
    public virtual void Deserialize(Packet packet)
    {
        throw new System.NotImplementedException();
    }

    public uint OwnerUniqueId { get; set; }
    public string Name { get; set; }
    public byte Level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Settings { get; set; }
    public long Experience { get; set; }
    public BadStatus BadEffect { get; set; }
    public IInventoryItemCollection Inventory { get; set; }
}