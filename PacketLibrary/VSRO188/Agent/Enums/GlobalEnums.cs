namespace PacketLibrary.VSRO188.Agent.Enums;

public enum ObjectCountry : byte
{
    Chinese = 0,
    Europe = 1,
    Islam = 2,
    Unassigned = 3
}

public enum ObjectGender : byte
{
    Female = 0,
    Male = 1,
    Neutral = 2
}

public enum SpawnInfoType : byte
{
    Spawn = 0x01,
    Despawn = 0x02
}

public enum MovementType : byte
{
    Walking = 0,
    Running = 1,
    None = 0xFF // b0ykoe - this does not really exist
}

public enum MovementAction : byte
{
    Spinning = 0,
    KeyWalking = 1
}

public enum LifeState : byte
{
    Unknown = 0,
    Alive = 1,
    Dead = 2
}

public enum MotionState : byte
{
    StandUp = 0,
    Walking = 2,
    Running = 3,
    Sitting = 4
}

public enum BodyState : byte
{
    None = 0,
    Berserk = 1,
    Untouchable = 2,
    GameMasterInvincible = 3,
    GameMasterUntouchable = 4,
    GameMasterInvisible = 5,
    Stealth = 6,
    Invisible = 7
}

public enum FortSiegeAuthority
{
    None = 0,
    Commander = 1,
    DeputyCommander = 2,
    FortressWarAdministrator = 4,
    ProductionAdministrator = 8,
    TrainingAdministrator = 16,
    MilitaryEngineer = 32
}

[Flags]
public enum ObjectRarity : byte
{
    ClassA = 0, //ITEM=White         MOB=General
    ClassB = 1, //ITEM=Blue          MOB=Champion
    ClassC = 2, //ITEM=SOX           MOB=unused
    ClassD = 3, //ITEM=SET           MOB=Unique
    ClassE = 4, //                   MOB=Giant
    ClassF = 5, //                   MOB=Titan
    ClassG = 6, //ITEM=ROC,SET_11_B  MOB=Elite
    ClassH = 7, //ITEM=LEGEND        MOB=Elite (Strong)
    ClassI = 8 //                    MOB=Unique (TQ, GOD, SD)

    //Party = 10
    //For ITEM_: see above, this rarity is also used in SERVER_AGENT_OBJECT_SPAWN when OBJECT equals ITEM...
    //For COS_T / TRADE_COS: it might be used for TIEF/HUNTER AI target priority since behemoth and lvl60+ cos are higher than normal ones
    //For MOB_: it could affect on spawn chance unless its a unique?
}

public enum MonsterRarity : byte
{
    General = 0,
    Champion = 1,
    Unique = 3,
    Giant = 4,
    Titan = 5,
    Elite = 6,
    EliteStrong = 7,
    Unique2 = 8,
    GeneralParty = 16,
    ChampionParty = 17,
    UniqueParty = 19,
    GiantParty = 20,
    TitanParty = 21,
    EliteParty = 22,
    Unique2Party = 24,
    Event = 0xFF
}

public enum BadStatus : uint
{
    None = 0,
    Freezing = 0x1, // Universal
    Frostbite = 0x2, // None
    ElectricShock = 0x4, // Universal
    Burn = 0x8, // Universal
    Poisoning = 0x10, // Universal
    Zombie = 0x20, // Universal
    Sleep = 0x40, // None
    Bind = 0x80, // None
    Dull = 0x100, // Purification
    Fear = 0x200, // Purification
    ShortSight = 0x400, // Purification
    Bleed = 0x800, // Purification
    Petrify = 0x1000, // None
    Darkness = 0x2000, // Purification
    Stun = 0x4000, // None
    Disease = 0x8000, // Purification
    Confusion = 0x10000, // Purification
    Decay = 0x20000, // Purification
    Weaken = 0x40000, // Purification
    Impotent = 0x80000, // Purification
    Division = 0x100000, // Purification
    Panic = 0x200000, // Purification
    Combustion = 0x400000, // Purification
    Unk01 = 0x800000,
    Hidden = 0x1000000, // Purification
    Unk02 = 0x2000000,
    Unk03 = 0x4000000,
    Unk04 = 0x8000000,
    Unk05 = 0x10000000,
    Unk06 = 0x20000000,
    Unk07 = 0x40000000,
    Unk08 = 0x80000000
}

public enum CharacterAction : byte
{
    CommonAttack = 1,
    ItemPickUp = 2,
    SkillCast = 4,
    SkillRemove = 5
}

public enum PVPCape : byte
{
    None = 0,
    Red = 1,
    Gray = 2,
    Blue = 3,
    White = 4,
    Yellow = 5
}

public enum ExpIcon : byte
{
    Beginner = 0,
    Helpful = 1,
    BeginnerAndHelpful = 2
}

public enum Job : byte
{
    None = 0,
    Trader = 1,
    Thief = 2,
    Hunter = 3
}

public enum InteractMode
{
    None = 0,
    P2P = 2,
    P2N_TALK2 = 3, // newer clients
    P2N_TALK = 4,
    OPNMKT_DEAL = 6
}

public enum PvpState : byte
{
    Neutral = 0,
    Assaulter = 1,
    PlayerKiller = 2
}

public enum Scrolling : byte
{
    None = 0,
    ReturnScroll = 1,
    BanditReturnScroll = 2
}

public enum Interaction : byte
{
    None = 0,
    OnExchangeProbably = 2,
    OnStall = 4,
    OnShop = 6
}

public enum CaptureTheFlag : byte
{
    None = 0xFF,
    Red = 1,
    Blue = 2
}

public enum ScrollState
{
    Cancel = 0,
    NormalScroll = 1,
    ThiefScroll = 2 //able to move
}

public enum BattleState : byte
{
    InPeace = 0,
    InBattle = 1
}

public enum CosCommand : byte
{
    Move = 1,
    Attack = 2,
    Pickup = 8,
    Follow = 9,
    Charm = 11
}

[Flags]
public enum ItemUpdateFlag : byte
{
    RefObjID = 1,
    OptLevel = 2,
    Unknown = 3, // ???
    Variance = 4,
    Quanity = 8,
    Durability = 16,
    MagParams = 32,
    State = 64
}

public enum BindingOptionType : byte
{
    Socket = 1,
    AdvancedElixir = 2
}

public enum InventoryItemState
{
    Inactive = 1,
    Summoned = 2,
    Active = 3,
    Dead = 4
}

public enum ItemAttributeGroup
{
    Durability,
    PhysicalSpecialize,
    MagicalSpecialize,
    HitRatio,
    PhysicalDamage,
    MagicalDamage,
    Critical,
    BlockRatio,
    EvasionRatio,
    PhysicalDefense,
    MagicalDefense,
    PhysicalAbsorbRatio,
    MagicalAbsorbRatio
}