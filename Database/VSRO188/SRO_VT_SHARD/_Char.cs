namespace Database.VSRO188.SRO_VT_SHARD;

public partial class _Char
{
    public int CharID { get; set; }

    public byte Deleted { get; set; }

    public int RefObjID { get; set; }

    public string CharName16 { get; set; } = null!;

    public string NickName16 { get; set; } = null!;

    public byte Scale { get; set; }

    public byte CurLevel { get; set; }

    public byte MaxLevel { get; set; }

    public long ExpOffset { get; set; }

    public int SExpOffset { get; set; }

    public short Strength { get; set; }

    public short Intellect { get; set; }

    public long RemainGold { get; set; }

    public int RemainSkillPoint { get; set; }

    public short RemainStatPoint { get; set; }

    public byte RemainHwanCount { get; set; }

    public int GatheredExpPoint { get; set; }

    public int HP { get; set; }

    public int MP { get; set; }

    public short LatestRegion { get; set; }

    public float PosX { get; set; }

    public float PosY { get; set; }

    public float PosZ { get; set; }

    public int AppointedTeleport { get; set; }

    public byte AutoInvestExp { get; set; }

    public int InventorySize { get; set; }

    public byte DailyPK { get; set; }

    public short TotalPK { get; set; }

    public int PKPenaltyPoint { get; set; }

    public int TPP { get; set; }

    public int PenaltyForfeit { get; set; }

    public int JobPenaltyTime { get; set; }

    public byte JobLvl_Trader { get; set; }

    public int Trader_Exp { get; set; }

    public byte JobLvl_Hunter { get; set; }

    public int Hunter_Exp { get; set; }

    public byte JobLvl_Robber { get; set; }

    public int Robber_Exp { get; set; }

    public int? GuildID { get; set; }

    public DateTime LastLogout { get; set; }

    public short TelRegion { get; set; }

    public float TelPosX { get; set; }

    public float TelPosY { get; set; }

    public float TelPosZ { get; set; }

    public short DiedRegion { get; set; }

    public float DiedPosX { get; set; }

    public float DiedPosY { get; set; }

    public float DiedPosZ { get; set; }

    public short WorldID { get; set; }

    public short TelWorldID { get; set; }

    public short DiedWorldID { get; set; }

    public byte HwanLevel { get; set; }
    
    public _RefObjCommon? _refObjCommon;

    public _RefObjCommon RefObjCommon
    {
        get
        {
            if (_refObjCommon != null)
            {
                return _refObjCommon;
            }

            _refObjCommon = Cache.GetRefObjCommonAsync(RefObjID).Result;
            return _refObjCommon;
        }
    }

    private _RefObjChar? _refObjChar;
    
    public _RefObjChar? RefObjChar
    {
         get
        {
            if (_refObjChar != null)
            {
                return _refObjChar;
            }

            _refObjChar = Cache.GetRefObjCharAsync(RefObjID).Result;
            return _refObjChar;
        }
    }

    public bool IsMale()
    {
        return RefObjChar.CharGender == 1;
    }
        
    public bool IsFemale()
    {
        return RefObjChar.CharGender == 0;
    }
}
