using System.Collections.Generic;
using System.Linq;
using API;
using API.Database.SRO_VT_SHARD;
using API.Objects;
using API.Objects.Inventory;
using API.Objects.Inventory.Item;
using DuckSoup.Library.Objects.Inventory.Item;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public class InventoryItem : IInventoryItem
{
    public uint ItemId { get; set; }
    public byte Slot { get; set; }
    public IRentInfo Rental { get; set; }
    private _RefObjItem? _refObjItem;

    _RefObjItem? Record
    {
        get
        {
            return _refObjItem ??= API.ServiceFactory.ServiceFactory
                .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .First(c => c.Value.ID == ItemId).Value.GetRefObjItem();
        }
    }
    
    public byte OptLevel { get; set; }
    public IItemAttributesInfo Attributes { get; set; }
    public uint Durability { get; set; }
    public List<IMagicOptionInfo> MagicOptions { get; set; }
    public List<IBindingOption> BindingOptions { get; set; }
    public ushort Amount { get; set; }
    public InventoryItemState State { get; set; }
    public IInventoryItemCosInfo Cos { get; set; }
    
    public static IInventoryItem FromPacket(Packet packet, byte destinationSlot = 0xFE)
    {
        var item = new InventoryItem
        {
            MagicOptions = new List<IMagicOptionInfo>(),
            BindingOptions = new List<IBindingOption>(),
            Amount = 1,
            Slot = destinationSlot
        };

        if (destinationSlot == 0xFE)
        {
            item.Slot = packet.ReadUInt8();
        }

        item.Rental = RentInfo.FromPacket(packet);
        item.ItemId = packet.ReadUInt32();
        var record = item.Record;
        if (record == null)
        {
            return null;
        }

        //         public bool IsEquip => TypeID2 == 1;
        //         public bool IsFellowEquip => TypeID2 == 5;
        //         public bool IsJobEquip => TypeID2 == 4;
        //         public bool IsPet => TypeID2 == 2 && TypeID3 == 1;
        //         public bool IsTransmonster => TypeID2 == 2 && TypeID3 == 2;

        if (record.IsEquip || record.IsFellowEquip || record.IsJobEquip)
        {
            item.OptLevel = packet.ReadUInt8();
            item.Attributes = new ItemAttributesesInfo(packet.ReadUInt64());
            item.Durability = packet.ReadUInt32();;

            //Read magic options for the item
            var magicOptionsAmount = packet.ReadUInt8();

            for (var iMagicOption = 0; iMagicOption < magicOptionsAmount; iMagicOption++)
            {
                item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));
            }
            
            //Read sockets & advanced elixirs
            var bindingCount = 2;

            for (var bindingIndex = 0; bindingIndex < bindingCount; bindingIndex++)
            {
                var bindingType = (BindingOptionType) packet.ReadUInt8();
                var bindingAmount = packet.ReadUInt8();
                for (var iSocketAmount = 0; iSocketAmount < bindingAmount; iSocketAmount++)
                    item.BindingOptions.Add(BindingOption.FromPacket(packet, bindingType));
            }
            
        }
        else if (record.IsPet)
        {
            item.State = (InventoryItemState) packet.ReadUInt8();
            item.Amount = 1;

            if (item.State != InventoryItemState.Inactive)
            {
                item.Cos.Id = packet.ReadUInt32();; //RefCharID
                item.Cos.Name = packet.ReadAscii(); //Name

                if (record.GetRefObjCommon.TypeID4 == 2)
                    item.Cos.Rental = RentInfo.FromPacket(packet);
                
                var buffCount = packet.ReadUInt8();
                for (int i = 0; i < buffCount; i++)
                {
                    var buffType = packet.ReadUInt8();
                    if (buffType == 0 || buffType == 20 || buffType == 6)
                    {
                        var itemId = packet.ReadUInt32();; // buffType: 0 => skillId ? 20 => itemId
                        var leftTime = packet.ReadUInt32();;
                    }

                    if (buffType == 5)
                    {
                        var itemId = packet.ReadUInt32();;
                        var leftTime = packet.ReadUInt32();;
                        var leftTime2 = packet.ReadUInt32();;
                        var unk2 = packet.ReadUInt8();
                    }
                }
            }
        }
        else if (record.IsTransmonster)
        {
            item.Cos.Id = packet.ReadUInt32();; //Monster ObjectId
        }
        else if (record.IsMagicCube)
        {
            item.Amount = (ushort) packet.ReadUInt32();; //Quantity
        }
        else if (record.IsNormalTrading || record.IsSpecialTrading)
        {
            item.Amount = packet.ReadUInt16();; //Quantity
            var ownerName = packet.ReadAscii();
        }
        else if (record.IsSpecialtyGoodBox)
        {
            item.Amount = (ushort) packet.ReadUInt32();; //Quantity
        }
        else if (record.IsStackable) //ITEM_ETC
        {
            item.Amount = packet.ReadUInt16();

            if (record.GetRefObjCommon.TypeID3 == 11) //Magic/Attr stone
            {
                if (record.GetRefObjCommon.TypeID4 == 1 || record.GetRefObjCommon.TypeID4 == 2)
                    packet.ReadUInt8();
            }
            else if (record.GetRefObjCommon.TypeID3 == 14 && record.GetRefObjCommon.TypeID4 == 2)
            {
                //ITEM_MALL_GACHA_CARD_WIN
                //ITEM_MALL_GACHA_CARD_LOSE
                var magParamCount = packet.ReadUInt8();
                for (var i = 0; i < magParamCount; i++)
                {
                    packet.ReadUInt32();;
                    packet.ReadUInt32();;
                }
            }
        }

        return item;
    }
    
    public ITypeIdFilter GetFilter()
    {
        throw new System.NotImplementedException();
    }
}