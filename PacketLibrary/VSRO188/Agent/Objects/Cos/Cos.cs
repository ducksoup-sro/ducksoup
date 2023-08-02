using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Inventory;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Cos;

// https://github.com/SDClowen/RSBot/
public class Cos
{
    public uint Id;
    public uint UniqueId;
    public Movement Movement;
    public State State;
    public _RefObjCommon RefObjCommon;
    public _RefObjChar RefObjChar;
    public ObjectCountry Race;
    public ObjectGender Gender;
    public Position Position;
    public bool IsInDungeon;

    public virtual void Deserialize(Packet packet)
    {
        throw new NotImplementedException();
    }

    public uint OwnerUniqueId;
    public string Name;
    public byte Level;
    public int Health;
    public int MaxHealth;
    public int Settings;
    public long Experience;
    public BadStatus BadEffect;
    public InventoryItemCollection Inventory;
}