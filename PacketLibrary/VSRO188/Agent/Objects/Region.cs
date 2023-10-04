using System.Runtime.InteropServices;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
[StructLayout(LayoutKind.Explicit)]
public struct Region
{
    [FieldOffset(0)] private ushort Id;

    [FieldOffset(0)] private byte X;

    [FieldOffset(sizeof(byte))] private byte Y;

    public bool IsDungeon => Y == 0x80;

    public ushort GetId()
    {
        return Id;
    }

    public byte GetX()
    {
        return X;
    }

    public byte GetY()
    {
        return Y;
    }

    public void SetId(ushort id)
    {
        Id = id;
    }

    public void SetX(byte x)
    {
        X = x;
    }

    public void SetY(byte y)
    {
        Y = y;
    }

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
            new((byte)(X - 1), (byte)(Y + 1)), //TL
            new(X, (byte)(Y + 1)), //TC
            new((byte)(X + 1), (byte)(Y + 1)), //TR
            new((byte)(X - 1), Y), //CL
            new(X, Y), //CC
            new((byte)(X + 1), Y), //CR
            new((byte)(X - 1), (byte)(Y - 1)), //BL
            new(X, (byte)(Y - 1)), //BC
            new((byte)(X + 1), (byte)(Y - 1)) //BR
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