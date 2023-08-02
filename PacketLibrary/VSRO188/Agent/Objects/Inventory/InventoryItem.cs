using Database.VSRO188;
using Database.VSRO188.SRO_VT_SHARD;
using PacketLibrary.VSRO188.Agent.Enums;
using PacketLibrary.VSRO188.Agent.Objects.Inventory.Item;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects.Inventory;

// https://github.com/SDClowen/RSBot/
public class InventoryItem
{
    public uint ItemId;
    public byte Slot;
    public RentInfo Rental;
    private _RefObjItem? _refObjItem;

    public _RefObjItem? Record
    {
        get
        {
            return _refObjItem ??= Cache.GetRefObjItemAsync((int) ItemId).Result;
        }
    }
    
    public byte OptLevel;
    public ItemAttributesInfo Attributes;
    public uint Durability;
    public List<MagicOptionInfo> MagicOptions;
    public List<BindingOption> BindingOptions;
    public ushort Amount;
    public InventoryItemState State;
    public InventoryItemCosInfo Cos;
    
    public static InventoryItem FromPacket(Packet packet, byte destinationSlot = 0xFE)
    {
        var item = new InventoryItem
        {
            MagicOptions = new List<MagicOptionInfo>(),
            BindingOptions = new List<BindingOption>(),
            Amount = 1,
            Slot = destinationSlot
        };

        if (destinationSlot == 0xFE)
        {
            packet.TryRead<byte>(out item.Slot);
        }

        item.Rental = RentInfo.FromPacket(packet);
        packet.TryRead<uint>(out item.ItemId);
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
            packet.TryRead<byte>(out item.OptLevel)
                .TryRead<ulong>(out var attributes)
                .TryRead<uint>(out item.Durability)
                .TryRead<byte>(out var magicOptionsAmount);
            item.Attributes = new ItemAttributesInfo(attributes);

            //Read magic options for the item
            for (var iMagicOption = 0; iMagicOption < magicOptionsAmount; iMagicOption++)
            {
                item.MagicOptions.Add(MagicOptionInfo.FromPacket(packet));
            }
            
            //Read sockets & advanced elixirs
            var bindingCount = 2;

            for (var bindingIndex = 0; bindingIndex < bindingCount; bindingIndex++)
            {
                packet.TryRead<BindingOptionType>(out var bindingType)
                    .TryRead<byte>(out var bindingAmount);
                for (var iSocketAmount = 0; iSocketAmount < bindingAmount; iSocketAmount++)
                {
                    item.BindingOptions.Add(BindingOption.FromPacket(packet, bindingType));
                }
            }
            
        }
        else if (record.IsPet)
        {
            packet.TryRead<InventoryItemState>(out item.State);
            item.Amount = 1;

            if (item.State != InventoryItemState.Inactive)
            {
                packet.TryRead<uint>(out item.Cos.Id)
                    .TryRead(out item.Cos.Name);

                if (record.GetRefObjCommon.TypeID4 == 2)
                    item.Cos.Rental = RentInfo.FromPacket(packet);

                packet.TryRead<byte>(out var buffCount);
                for (int i = 0; i < buffCount; i++)
                {
                    packet.TryRead<byte>(out var buffType);
                    if (buffType == 0 || buffType == 20 || buffType == 6)
                    {
                        packet.TryRead<uint>(out var itemId) // buffType: 0 => skillId ? 20 => itemId
                            .TryRead<uint>(out var leftTime);
                    }

                    if (buffType == 5)
                    {
                        packet.TryRead<uint>(out var itemId)
                            .TryRead<uint>(out var leftTime)
                            .TryRead<uint>(out var leftTime2)
                            .TryRead<byte>(out var unk2);
                    }
                }
            }
        }
        else if (record.IsTransmonster)
        {
            packet.TryRead<uint>(out item.Cos.Id);
        }
        else if (record.IsMagicCube)
        {
            packet.TryRead<uint>(out var amount); // Quantity
            item.Amount = (ushort) amount; //Quantity
        }
        else if (record.IsNormalTrading || record.IsSpecialTrading)
        {
            packet.TryRead<ushort>(out item.Amount)
                .TryRead(out var ownerName);
        }
        else if (record.IsSpecialtyGoodBox)
        {
            packet.TryRead<ushort>(out item.Amount); // Quantity
        }
        else if (record.IsStackable) //ITEM_ETC
        {
            packet.TryRead<ushort>(out item.Amount);

            if (record.GetRefObjCommon.TypeID3 == 11) //Magic/Attr stone
            {
                if (record.GetRefObjCommon.TypeID4 == 1 || record.GetRefObjCommon.TypeID4 == 2)
                {
                    packet.TryRead<byte>(out var unk0);
                }
            }
            else if (record.GetRefObjCommon.TypeID3 == 14 && record.GetRefObjCommon.TypeID4 == 2)
            {
                //ITEM_MALL_GACHA_CARD_WIN
                //ITEM_MALL_GACHA_CARD_LOSE
                packet.TryRead<byte>(out var magParamCount);
                for (var i = 0; i < magParamCount; i++)
                {
                    packet.TryRead<uint>(out var unk1)
                        .TryRead<uint>(out var unk2);
                }
            }
        }

        return item;
    }
    
    public TypeIdFilter GetFilter()
    {
        throw new NotImplementedException();
    }
}