namespace PacketLibrary.Enums.Agent;

public enum TrijobType : byte
{
    NoJob = 0x4,
    Hunter = 0x3,
    Thief = 0x2,
    Trader = 0x1,
    None = 0x0, // seems to be double?
}

