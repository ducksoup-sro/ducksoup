using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedItem : SpawnedEntity
{
    public byte OptLevel;
    public string OwnerName;
    public uint Amount;
    public bool HasOwner;
    public uint OwnerJID;
    public ObjectRarity Rarity;

    public _RefObjItem RefObjItem => Cache.GetRefObjItemAsync(i => i.Link == Id).Result;

    public _RefObjCommon RefObjCommon => Cache.GetRefObjCommonAsync((int)Id).Result;
    

    internal static SpawnedItem FromPacket(Packet packet, uint itemId)
    {
        var result = new SpawnedItem { Id = itemId };

        if (result.RefObjCommon.TypeID2 == 1)
        {
            // isEquip
            packet.TryRead<byte>(out result.OptLevel);
        }
        else if (result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 5 &&
                 result.RefObjCommon.TypeID4 == 0)
        {
            // isGold
            packet.TryRead<uint>(out result.Amount);
        }
        else if ((result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 9) ||
                 (result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 8)) // isQuest || isTrading
        {
            packet.TryRead(out result.OwnerName);
        }

        packet.TryRead<uint>(out result.UniqueId);
        result.Movement.Source = Position.FromPacket(packet);
        packet.TryRead<bool>(out result.HasOwner);


        if (result.HasOwner)
        {
            packet.TryRead<uint>(out result.OwnerJID);
        }

        packet.TryRead<ObjectRarity>(out result.Rarity);

        return result;
    }
}