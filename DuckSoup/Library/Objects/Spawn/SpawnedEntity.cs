using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using API.Session;
using DuckSoup.Library.Session;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedEntity
{
    public uint UniqueId { get; set; }
    public uint Id { get; set; }
    public State State { get; } = new();
    public C_RefObjCommon RefObjCommon => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon[(int) Id];
    public C_RefObjChar RefObjChar => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjChar.FirstOrDefault(c => c.Value.Link == Id).Value;

    public ObjectCountry Race => (ObjectCountry) RefObjCommon.Country;

    public ObjectGender Gender => (ObjectGender) RefObjChar.CharGender;

    public Movement Movement = new Movement();
    public IPosition Position => Movement.Source;

    public bool IsInDungeon => Movement.Source.Region.IsDungeon;
}