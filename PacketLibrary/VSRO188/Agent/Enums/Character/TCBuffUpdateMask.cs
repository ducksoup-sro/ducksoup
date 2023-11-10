namespace PacketLibrary.VSRO188.Agent.Enums.Character;

[Flags]
public enum TCBuffUpdateMask : byte
{
    Cumulated = 0x0F,   // 0000 1111
    Accumulated = 0xF0, // 1111 0000
}