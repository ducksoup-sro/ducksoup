using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedEntity
{
    public uint Id;
    public Movement Movement = new();
    public State State = new();
    public uint UniqueId;
    public _RefObjCommon RefObjCommon => Cache.GetRefObjCommonAsync((int)Id).Result;
    public _RefObjChar RefObjChar => Cache.GetRefObjCharAsync(c => c.Link == Id).Result;
    public ObjectCountry Race => (ObjectCountry)RefObjCommon.Country;
    public ObjectGender Gender => (ObjectGender)RefObjChar.CharGender;
    public Position Position => Movement.Source;
    public bool IsInDungeon => Movement.Source.Region.IsDungeon;

    public virtual void Deserialize(Packet packet)
    {
        throw new NotImplementedException();
    }
}