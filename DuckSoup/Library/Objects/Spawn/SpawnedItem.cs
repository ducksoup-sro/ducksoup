using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.ServiceFactory;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Spawn;

// https://github.com/SDClowen/RSBot/
public class SpawnedItem : SpawnedEntity
{
    public byte OptLevel;
    public string OwnerName;
    public uint Amount;
    public bool HasOwner;
    public uint OwnerJID;
    public ObjectRarity Rarity;
    public _RefObjItem RefObjItem => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjItem.First(i => i.Value.Link == Id).Value;
    public _RefObjCommon RefObjCommon => ServiceFactory.Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon[(int) Id];
    internal static SpawnedItem FromPacket(Packet packet, uint itemId)
    {
        var result = new SpawnedItem { Id = itemId };

        if (result.RefObjCommon.TypeID2 == 1) // isEquip
            result.OptLevel = packet.ReadUInt8();
        else if (result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 5 && result.RefObjCommon.TypeID4 == 0) // isGold
            result.Amount = packet.ReadUInt32();
        else if ((result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 9) || (result.RefObjCommon.TypeID2 == 3 && result.RefObjCommon.TypeID3 == 8)) // isQuest || isTrading
            result.OwnerName = packet.ReadAscii();

        result.UniqueId = packet.ReadUInt32();
        result.Movement.Source = Objects.Position.FromPacket(packet);
        result.HasOwner = packet.ReadBool();

        if (result.HasOwner)
            result.OwnerJID = packet.ReadUInt32();

        result.Rarity = (ObjectRarity)packet.ReadUInt8();

        return result;
    }
}