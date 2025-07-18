using System.Runtime.InteropServices;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
[StructLayout(LayoutKind.Explicit)]
public struct Region
{
    [FieldOffset(0)] public ushort Id;

    [FieldOffset(0)] public byte X;

    [FieldOffset(sizeof(byte))] public byte Y;

    public bool IsDungeon => Y == 0x80;

    public Region(ushort id)
    {
        Id = id;
    }

    public Region(byte x, byte y)
    {
        X = x;
        Y = y;
    }

    public static implicit operator ushort(Region wrapper)
    {
        return wrapper.Id;
    }

    public static implicit operator Region(ushort value)
    {
        return new Region(value);
    }

    public Region[] GetSurroundingRegions()
    {
        return new Region[]
        {
            new Region((byte)(X - 1), (byte)(Y + 1)), //TL
            new Region(X, (byte)(Y + 1)), //TC
            new Region((byte)(X + 1), (byte)(Y + 1)), //TR
            new Region((byte)(X - 1), Y), //CL
            new Region(X, Y), //CC
            new Region((byte)(X + 1), Y), //CR
            new Region((byte)(X - 1), (byte)(Y - 1)), //BL
            new Region(X, (byte)(Y - 1)), //BC
            new Region((byte)(X + 1), (byte)(Y - 1)) //BR
        };
    }

    public void Serialize(Packet packet)
    {
        packet.TryWrite(X)
            .TryWrite(Y);
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}