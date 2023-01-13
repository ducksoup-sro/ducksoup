using System;
using System.Collections.Generic;

namespace API.Database.SRO_VT_SHARD;

public partial class _RefObjItem
{
    public int ID { get; set; }

    public int MaxStack { get; set; }

    public byte ReqGender { get; set; }

    public int ReqStr { get; set; }

    public int ReqInt { get; set; }

    public byte ItemClass { get; set; }

    public int SetID { get; set; }

    public float Dur_L { get; set; }

    public float Dur_U { get; set; }

    public float PD_L { get; set; }

    public float PD_U { get; set; }

    public float PDInc { get; set; }

    public float ER_L { get; set; }

    public float ER_U { get; set; }

    public float ERInc { get; set; }

    public float PAR_L { get; set; }

    public float PAR_U { get; set; }

    public float PARInc { get; set; }

    public float BR_L { get; set; }

    public float BR_U { get; set; }

    public float MD_L { get; set; }

    public float MD_U { get; set; }

    public float MDInc { get; set; }

    public float MAR_L { get; set; }

    public float MAR_U { get; set; }

    public float MARInc { get; set; }

    public float PDStr_L { get; set; }

    public float PDStr_U { get; set; }

    public float MDInt_L { get; set; }

    public float MDInt_U { get; set; }

    public byte Quivered { get; set; }

    public byte Ammo1_TID4 { get; set; }

    public byte Ammo2_TID4 { get; set; }

    public byte Ammo3_TID4 { get; set; }

    public byte Ammo4_TID4 { get; set; }

    public byte Ammo5_TID4 { get; set; }

    public byte SpeedClass { get; set; }

    public byte TwoHanded { get; set; }

    public short Range { get; set; }

    public float PAttackMin_L { get; set; }

    public float PAttackMin_U { get; set; }

    public float PAttackMax_L { get; set; }

    public float PAttackMax_U { get; set; }

    public float PAttackInc { get; set; }

    public float MAttackMin_L { get; set; }

    public float MAttackMin_U { get; set; }

    public float MAttackMax_L { get; set; }

    public float MAttackMax_U { get; set; }

    public float MAttackInc { get; set; }

    public float PAStrMin_L { get; set; }

    public float PAStrMin_U { get; set; }

    public float PAStrMax_L { get; set; }

    public float PAStrMax_U { get; set; }

    public float MAInt_Min_L { get; set; }

    public float MAInt_Min_U { get; set; }

    public float MAInt_Max_L { get; set; }

    public float MAInt_Max_U { get; set; }

    public float HR_L { get; set; }

    public float HR_U { get; set; }

    public float HRInc { get; set; }

    public float CHR_L { get; set; }

    public float CHR_U { get; set; }

    public int Param1 { get; set; }

    public string Desc1_128 { get; set; } = null!;

    public int Param2 { get; set; }

    public string Desc2_128 { get; set; } = null!;

    public int Param3 { get; set; }

    public string Desc3_128 { get; set; } = null!;

    public int Param4 { get; set; }

    public string Desc4_128 { get; set; } = null!;

    public int Param5 { get; set; }

    public string Desc5_128 { get; set; } = null!;

    public int Param6 { get; set; }

    public string Desc6_128 { get; set; } = null!;

    public int Param7 { get; set; }

    public string Desc7_128 { get; set; } = null!;

    public int Param8 { get; set; }

    public string Desc8_128 { get; set; } = null!;

    public int Param9 { get; set; }

    public string Desc9_128 { get; set; } = null!;

    public int Param10 { get; set; }

    public string Desc10_128 { get; set; } = null!;

    public int Param11 { get; set; }

    public string Desc11_128 { get; set; } = null!;

    public int Param12 { get; set; }

    public string Desc12_128 { get; set; } = null!;

    public int Param13 { get; set; }

    public string Desc13_128 { get; set; } = null!;

    public int Param14 { get; set; }

    public string Desc14_128 { get; set; } = null!;

    public int Param15 { get; set; }

    public string Desc15_128 { get; set; } = null!;

    public int Param16 { get; set; }

    public string Desc16_128 { get; set; } = null!;

    public int Param17 { get; set; }

    public string Desc17_128 { get; set; } = null!;

    public int Param18 { get; set; }

    public string Desc18_128 { get; set; } = null!;

    public int Param19 { get; set; }

    public string Desc19_128 { get; set; } = null!;

    public int Param20 { get; set; }

    public string Desc20_128 { get; set; } = null!;

    public byte MaxMagicOptCount { get; set; }

    public byte ChildItemCount { get; set; }

    public int Link { get; set; }
    
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
        public bool IsArmor => IsEquip && GetRefObjCommon.TypeID3 == 1 || GetRefObjCommon.TypeID3 is 2 or 3 or 9 or 10 or 11;
        public bool IsShield => IsEquip && GetRefObjCommon.TypeID3 == 4;
        public bool IsAccessory => IsEquip && GetRefObjCommon.TypeID3 == 5 || GetRefObjCommon.TypeID3 == 12;
        public bool IsWeapon => IsEquip && GetRefObjCommon.TypeID3 == 6;
        public int Degree => (ItemClass - 1) / 3 + 1;
        public int DegreeOffset => ItemClass - 3 * ((ItemClass - 1) / 3) - 1; //sro_client.sub_8BA6E0
}
