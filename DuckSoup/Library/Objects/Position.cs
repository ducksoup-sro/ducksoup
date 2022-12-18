using System;
using API.Session;
using SilkroadSecurityAPI;

namespace DuckSoup.Library.Objects;

// https://github.com/SDClowen/RSBot/
public class Position : IPosition
{
    private float _XOffset;
    private float _YOffset;
    public IRegion Region { get; set; }

    public float XOffset
    {
        get => _XOffset;
        set
        {
            _XOffset = value;

            if (Region.IsDungeon)
                return;

            while (_XOffset < 0)
            {
                _XOffset += 1920;
                Region.SetX((byte) (Region.GetX() - 1));
            }

            while (_XOffset > 1920)
            {
                _XOffset -= 1920;
                Region.SetX((byte) (Region.GetX() + 1));
            }
        }
    }

    public float YOffset
    {
        get => _YOffset;
        set
        {
            _YOffset = value;

            if (Region.IsDungeon)
                return;

            while (_YOffset < 0)
            {
                _YOffset += 1920;
                Region.SetY((byte) (Region.GetY() - 1));
            }

            while (_YOffset > 1920)
            {
                _YOffset -= 1920;
                Region.SetY((byte) (Region.GetY() + 1));
            }
        }
    }

    public float ZOffset { get; set; }
    public short Angle { get; set; }
    public short WorldId { get; set; }
    public short LayerId { get; set; }

    public float X
    {
        get { return Region.IsDungeon ? _XOffset / 10 : (Region.GetX() - 135) * 192 + _XOffset / 10; }
    }

    public float Y
    {
        get { return Region.IsDungeon ? _YOffset / 10 : (Region.GetY() - 92) * 192 + _YOffset / 10; }
    }

    public float XSectorOffset
    {
        get { return Region.IsDungeon ? (127 * 192 + _XOffset / 10) * 10 % 1920 : _XOffset; }
    }

    public float YSectorOffset
    {
        get { return Region.IsDungeon ? (128 * 192 + _YOffset / 10) * 10 % 1920 : _YOffset; }
    }

    public Position(float x, float y, ushort regionId = 0)
    {
        Region = new Region(regionId);

        // World map coordinates has been provided
        if (!Region.IsDungeon)
        {
            var xOffset = (int) (Math.Abs(x) % 192 * 10);
            if (x < 0)
            {
                xOffset = 1920 - xOffset;
            }

            var yOffset = (int) (Math.Abs(y) % 192 * 10);
            if (y < 0)
            {
                yOffset = 1920 - yOffset;
            }

            Region.SetX((byte) Math.Round((x - xOffset / 10f) / 192f + 135));
            Region.SetY((byte) Math.Round((y - yOffset / 10f) / 192f + 92));

            XOffset = xOffset;
            YOffset = yOffset;
            return;
        }

        // Dungeon map coordinates

        XOffset = x * 10;
        YOffset = y * 10;
    }


    public Position(short xOffset, short yOffset, short zOffset, ushort regionId)
    {
        Region = new Region(regionId);

        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;
    }

    public Position(float xOffset, float yOffset, float zOffset, byte xSector, byte ySector)
    {
        Region.SetX(xSector);
        Region.SetY(ySector);

        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;
    }

    public double DistanceTo(Position position)
    {
        return Math.Sqrt(Math.Pow(X - position.X, 2) + Math.Pow(Y - position.Y, 2));
    }

    public static IPosition FromPacket(Packet packet)
    {
        return new IPosition
        {
            Region = new Region(packet.ReadUInt16()),
            XOffset = packet.ReadFloat(),
            ZOffset = packet.ReadFloat(),
            YOffset = packet.ReadFloat(),
            Angle = packet.ReadInt16()
        };
    }

    public static IPosition FromPacketInt(Packet packet)
    {
        return new IPosition
        {
            Region = new Region(packet.ReadUInt16()),
            XOffset = packet.ReadInt32(),
            ZOffset = packet.ReadInt32(),
            YOffset = packet.ReadInt32()
        };
    }

    public static IPosition FromPacketConditional(Packet packet, bool parseLayerWorldId = true)
    {
        var position = new IPosition
        {
            Region = new Region(packet.ReadUInt16())
        };

        if (!position.Region.IsDungeon)
        {
            position.XOffset = packet.ReadInt16();
            position.ZOffset = packet.ReadInt16();
            position.YOffset = packet.ReadInt16();
        }
        else
        {
            position.XOffset = packet.ReadInt32();
            position.ZOffset = packet.ReadInt32();
            position.YOffset = packet.ReadInt32();
        }

        if (parseLayerWorldId)
        {
            position.WorldId = packet.ReadInt16();
            position.LayerId = packet.ReadInt16();
        }

        return position;
    }

    public byte GetSectorFromOffset(float offset)
    {
        return (byte) (((128.0 * 192.0 + (128 * 192 + offset / 10)) / 192.0) - 128);
    }

    public override string ToString()
    {
        return $"X:{X:0.0} Y:{Y:0.0}";
    }
}