using System.Runtime.InteropServices;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects;

// https://github.com/SDClowen/RSBot/
[StructLayout(LayoutKind.Explicit)]
public struct Region : IRegion
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

    public IRegion[] GetSurroundingRegions()
    {
        return new IRegion[]
        {
            new Region((byte) (X - 1), (byte) (Y + 1)), //TL
            new Region(X, (byte) (Y + 1)), //TC
            new Region((byte) (X + 1), (byte) (Y + 1)), //TR
            new Region((byte) (X - 1), Y), //CL
            new Region(X, Y), //CC
            new Region((byte) (X + 1), Y), //CR
            new Region((byte) (X - 1), (byte) (Y - 1)), //BL
            new Region(X, (byte) (Y - 1)), //BC
            new Region((byte) (X + 1), (byte) (Y - 1)) //BR
        };
    }
    
    public void Serialize(Packet packet)
    {
        packet.WriteByte(X);
        packet.WriteByte(Y);
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}