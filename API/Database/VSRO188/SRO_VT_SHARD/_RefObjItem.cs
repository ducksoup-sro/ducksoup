namespace API.Database.VSRO188.SRO_VT_SHARD;

public class _RefObjItem : global::Database.VSRO188.SRO_VT_SHARD._RefObjItem
{
    private _RefObjCommon? _refObjCommon;

    public _RefObjCommon GetRefObjCommon
    {
        get
        {
            return _refObjCommon ??= ServiceFactory.ServiceFactory
                .Load<ISharedObjects>(typeof(ISharedObjects)).RefObjCommon
                .First(c => c.Value.Link == ID).Value;
        }
    }

    public bool IsGold => IsStackable && GetRefObjCommon.TypeID3 == 5 && GetRefObjCommon.TypeID4 == 0;
    public bool IsEquip => GetRefObjCommon.TypeID2 == 1;
    public bool IsAvatar => IsEquip && GetRefObjCommon.TypeID3 is 13 or 14;
    public bool IsJobEquip => GetRefObjCommon.TypeID2 == 4;
    public bool IsFellowEquip => GetRefObjCommon.TypeID2 == 5;
    public bool IsJobOutfit => IsEquip && GetRefObjCommon.TypeID3 == 7 && GetRefObjCommon.TypeID4 is not 4 or 5;
    public bool IsStackable => GetRefObjCommon.TypeID2 == 3;
    public bool IsTrading => IsStackable && GetRefObjCommon.TypeID3 == 8;
    public bool IsNormalTrading => IsTrading && GetRefObjCommon.TypeID4 == 1;
    public bool IsSpecialTrading => IsTrading && GetRefObjCommon.TypeID4 == 2;
    public bool IsSpecialtyGoodBox => IsTrading && GetRefObjCommon.TypeID4 == 3;
    public bool IsQuest => IsStackable && GetRefObjCommon.TypeID3 == 9;
    public bool IsAmmunition => IsStackable && GetRefObjCommon.TypeID3 == 4;
    public bool IsPet => GetRefObjCommon.TypeID2 == 2 && GetRefObjCommon.TypeID3 == 1;
    public bool IsGrowthPet => IsPet && GetRefObjCommon.TypeID4 == 1;
    public bool IsGrabPet => IsPet && GetRefObjCommon.TypeID4 == 2;
    public bool IsFellowPet => IsPet && GetRefObjCommon.TypeID4 == 3;
    public bool IsTransmonster => GetRefObjCommon.TypeID2 == 2 && GetRefObjCommon.TypeID3 == 2;
    public bool IsMagicCube => GetRefObjCommon.TypeID2 == 2 && GetRefObjCommon.TypeID3 == 3;
    public bool IsSkill => IsStackable && GetRefObjCommon.TypeID3 == 13 && GetRefObjCommon.TypeID4 == 1;
    public bool IsPotion => IsStackable && GetRefObjCommon.TypeID3 == 1;
    public bool IsHpPotion => IsPotion && GetRefObjCommon.TypeID4 == 1;
    public bool IsMpPotion => IsPotion && GetRefObjCommon.TypeID4 == 2;
    public bool IsAllPotion => IsPotion && GetRefObjCommon.TypeID4 == 3;
    public bool IsUniversalPill => IsStackable && GetRefObjCommon.TypeID3 == 2 && GetRefObjCommon.TypeID4 == 6;
    public bool IsPurificationPill => IsStackable && GetRefObjCommon.TypeID3 == 2 && GetRefObjCommon.TypeID4 == 1;
    public bool IsAbnormalPotion => IsStackable && GetRefObjCommon.TypeID3 == 2 && GetRefObjCommon.TypeID4 == 9;
    public bool IsCosHpPotion => IsPotion && GetRefObjCommon.TypeID4 == 4 && Param2 == 0;
    public bool IsFellowHpPotion => IsPotion && GetRefObjCommon.TypeID4 == 4 && Param2 != 0;
    public bool IsCosRevivalPotion => IsPotion && GetRefObjCommon.TypeID4 == 6;
    public bool IsHwanPotion => IsPotion && GetRefObjCommon.TypeID4 == 8;
    public bool IsHgpPotion => IsPotion && GetRefObjCommon.TypeID4 == 9 && Param1 == 10;
    public bool IsPet2SatietyPotion => IsPotion && GetRefObjCommon.TypeID4 == 9 && Param1 > 10;
    public bool IsRepairKit => IsPotion && GetRefObjCommon.TypeID4 == 10;

    public bool IsArmor =>
        IsEquip && GetRefObjCommon.TypeID3 == 1 || GetRefObjCommon.TypeID3 is 2 or 3 or 9 or 10 or 11;

    public bool IsShield => IsEquip && GetRefObjCommon.TypeID3 == 4;
    public bool IsAccessory => IsEquip && GetRefObjCommon.TypeID3 == 5 || GetRefObjCommon.TypeID3 == 12;
    public bool IsWeapon => IsEquip && GetRefObjCommon.TypeID3 == 6;
    public int Degree => (ItemClass - 1) / 3 + 1;
    public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0
}