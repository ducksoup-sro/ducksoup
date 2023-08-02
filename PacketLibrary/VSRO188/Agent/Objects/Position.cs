using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
public struct Position
{
    private float _xOffset;
    private float _yOffset;
    public Region Region { get; set; }

    public float XOffset
    {
        get => _xOffset;
        set
        {
            _xOffset = value;

            if (Region.IsDungeon)
                return;

            while (_xOffset < 0)
            {
                _xOffset += 1920;
                Region.SetX((byte)(Region.GetX() - 1));
            }

            while (_xOffset > 1920)
            {
                _xOffset -= 1920;
                Region.SetX((byte)(Region.GetX() + 1));
            }
        }
    }

    public float YOffset
    {
        get => _yOffset;
        set
        {
            _yOffset = value;

            if (Region.IsDungeon)
                return;

            while (_yOffset < 0)
            {
                _yOffset += 1920;
                Region.SetY((byte)(Region.GetY() - 1));
            }

            while (_yOffset > 1920)
            {
                _yOffset -= 1920;
                Region.SetY((byte)(Region.GetY() + 1));
            }
        }
    }

    public float ZOffset;
    public short Angle;
    public short WorldId;
    public short LayerId;

    public float X => Region.IsDungeon ? _xOffset / 10 : (Region.GetX() - 135) * 192 + _xOffset / 10;

    public float Y => Region.IsDungeon ? _yOffset / 10 : (Region.GetY() - 92) * 192 + _yOffset / 10;

    public float XSectorOffset => Region.IsDungeon ? (127 * 192 + _xOffset / 10) * 10 % 1920 : _xOffset;

    public float YSectorOffset => Region.IsDungeon ? (128 * 192 + _yOffset / 10) * 10 % 1920 : _yOffset;

    public Position(float x, float y, ushort regionId = 0) : this()
    {
        Region = new Region(regionId);

        // World map coordinates has been provided
        if (!Region.IsDungeon)
        {
            var xOffset = (int)(Math.Abs(x) % 192 * 10);
            if (x < 0)
            {
                xOffset = 1920 - xOffset;
            }

            var yOffset = (int)(Math.Abs(y) % 192 * 10);
            if (y < 0)
            {
                yOffset = 1920 - yOffset;
            }

            Region.SetX((byte)Math.Round((x - xOffset / 10f) / 192f + 135));
            Region.SetY((byte)Math.Round((y - yOffset / 10f) / 192f + 92));

            XOffset = xOffset;
            YOffset = yOffset;
            return;
        }

        // Dungeon map coordinates

        XOffset = x * 10;
        YOffset = y * 10;
    }


    public Position(short xOffset, short yOffset, short zOffset, ushort regionId) : this()
    {
        Region = new Region(regionId);

        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;
    }

    public Position(float xOffset, float yOffset, float zOffset, byte xSector, byte ySector) : this()
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

    public static Position FromPacket(Packet packet)
    {
        packet.TryRead<ushort>(out var region)
            .TryRead<float>(out var xOffset)
            .TryRead<float>(out var zOffset)
            .TryRead<float>(out var yOffset)
            .TryRead<short>(out var angle);

        return new Position()
        {
            Region = new Region(region),
            XOffset = xOffset,
            ZOffset = zOffset,
            YOffset = yOffset,
            Angle = angle
        };
    }

    public static Position FromPacketInt(Packet packet)
    {
        packet.TryRead<ushort>(out var region)
            .TryRead<float>(out var xOffset)
            .TryRead<float>(out var zOffset)
            .TryRead<float>(out var yOffset);

        return new Position()
        {
            Region = new Region(region),
            XOffset = xOffset,
            ZOffset = zOffset,
            YOffset = yOffset
        };
    }

    public static Position FromPacketConditional(Packet packet, bool parseLayerWorldId = true)
    {
        packet.TryRead<ushort>(out var region);

        var position = new Position
        {
            Region = new Region(region)
        };

        if (!position.Region.IsDungeon)
        {
            packet.TryRead<short>(out var xOffset)
                .TryRead<short>(out var yOffset)
                .TryRead<short>(out var zOffset);
            position.XOffset = xOffset;
            position.YOffset = yOffset;
            position.ZOffset = zOffset;
        }
        else
        {
            packet.TryRead<int>(out var xOffset)
                .TryRead<int>(out var yOffset)
                .TryRead<int>(out var zOffset);
            position.XOffset = xOffset;
            position.YOffset = yOffset;
            position.ZOffset = zOffset;
        }

        if (parseLayerWorldId)
        {
            packet.TryRead<short>(out position.WorldId)
                .TryRead<short>(out position.LayerId);
        }

        return position;
    }

    public byte GetSectorFromOffset(float offset)
    {
        return (byte)(((128.0 * 192.0 + (128 * 192 + offset / 10)) / 192.0) - 128);
    }

    public override string ToString()
    {
        return $"X:{X:0.0} Y:{Y:0.0}";
    }
}