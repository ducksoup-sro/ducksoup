using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Cos
{
    public BadStatus BadEffect;
    public long Experience;
    public ObjectGender Gender;
    public int Health;
    public uint Id;
    public InventoryItemCollection Inventory;
    public bool IsInDungeon;
    public byte Level;
    public int MaxHealth;
    public Movement Movement;
    public string Name;

    public uint OwnerUniqueId;
    public Position Position;
    public ObjectCountry Race;
    public _RefObjChar RefObjChar;
    public _RefObjCommon RefObjCommon;
    public int Settings;
    public State State;
    public uint UniqueId;

    public virtual void Deserialize(Packet packet)
    {
        throw new NotImplementedException();
    }
}