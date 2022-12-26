using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.Objects;
using API.Objects.Spawn;
using API.ServiceFactory;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedEntity : ISpawnedEntity
{
    public uint UniqueId { get; set; }
    public uint Id { get; set; }
    public IMovement Movement { get; } = new Movement();
    public IState State { get; } = new State();
    public C_RefObjCommon RefObjCommon => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon[(int) Id];
    public C_RefObjChar RefObjChar => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjChar.FirstOrDefault(c => c.Value.Link == Id).Value;
    public ObjectCountry Race => (ObjectCountry) RefObjCommon.Country;
    public ObjectGender Gender => (ObjectGender) RefObjChar.CharGender;
    public IPosition Position => Movement.Source;
    public bool IsInDungeon => Movement.Source.Region.IsDungeon;
    
    public void Deserialize(Packet packet)
    {
        throw new System.NotImplementedException();
    }
}