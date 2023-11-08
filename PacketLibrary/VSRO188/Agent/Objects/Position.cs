using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Objects;

// https://github.com/SDClowen/RSBot/
public struct Position
{
    private float _xOffset;
    private float _yOffset;
    public Region Region;

    public float XOffset
    {
        get => _xOffset;
        set
        {
            _xOffset = value;

            if (Region.IsDungeon)
                return;

            while (XOffset < 0)
            {
                XOffset += 1920;
                Region.X -= 1;
            }

            while (XOffset > 1920)
            {
                XOffset -= 1920;
                Region.X += 1;
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

            while (YOffset < 0)
            {
                YOffset += 1920;
                Region.Y -= 1;
            }

            while (YOffset > 1920)
            {
                YOffset -= 1920;
                Region.Y += 1;
            }
        }
    }

    public float ZOffset;
    public short Angle;
    public short WorldId;
    public short LayerId;

    // public float X => Region.IsDungeon ? _xOffset / 10 : (Region.GetX() - 135) * 192 + _xOffset / 10;
    public float X => XOffset == 0 ? 0 : Region.IsDungeon ? XOffset / 10 : (Region.X - 135) * 192 + XOffset / 10;


    // public float Y => Region.IsDungeon ? _yOffset / 10 : (Region.GetY() - 92) * 192 + _yOffset / 10;
    public float Y => YOffset == 0 ? 0 : Region.IsDungeon ? YOffset / 10 : (Region.Y - 92) * 192 + YOffset / 10;

    public float XSectorOffset => Region.IsDungeon ? (127 * 192 + _xOffset / 10) * 10 % 1920 : _xOffset;

    public float YSectorOffset => Region.IsDungeon ? (128 * 192 + _yOffset / 10) * 10 % 1920 : _yOffset;

    public Position(float x, float y, ushort regionId = 0) : this()
    {
        Region = new Region(regionId);

        // World map coordinates has been provided
        if (!Region.IsDungeon)
        {
            var xOffset = (int)(Math.Abs(x) % 192 * 10);
            if (x < 0) xOffset = 1920 - xOffset;

            var yOffset = (int)(Math.Abs(y) % 192 * 10);
            if (y < 0) yOffset = 1920 - yOffset;

            Region.X = (byte)MathF.Round((x - xOffset / 10.0f) / 192.0f + 135.0f);
            Region.Y = (byte)MathF.Round((y - yOffset / 10.0f) / 192.0f + 92.0f);

            XOffset = xOffset;
            YOffset = yOffset;
            return;
        }

        // Dungeon map coordinates

        XOffset = x * 10;
        YOffset = y * 10;
    }

    public Position(Region region, float xOffset, float yOffset, float zOffset)
        : this()
    {
        Region = region;

        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;
    }

    public Position(byte xSector, byte ySector, float xOffset, float yOffset, float zOffset)
        : this()
    {
        XOffset = xOffset;
        YOffset = yOffset;
        ZOffset = zOffset;

        Region.X = xSector;
        Region.Y = ySector;
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

        return new Position
        {
            Region = new Region(region),
            XOffset = xOffset,
            ZOffset = zOffset,
            YOffset = yOffset,
            Angle = angle
        };
    }

    public Packet ToPacket(Packet packet)
    {
        packet.TryWrite<ushort>(Region)
            .TryWrite(XOffset)
            .TryWrite(ZOffset)
            .TryWrite(YOffset)
            .TryWrite(Angle);
        return packet;
    }

    public static Position FromPacketInt(Packet packet)
    {
        packet.TryRead<ushort>(out var region)
            .TryRead<float>(out var xOffset)
            .TryRead<float>(out var zOffset)
            .TryRead<float>(out var yOffset);

        return new Position
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
            Region = region
        };

        if (!position.Region.IsDungeon)
        {
            packet.TryRead<short>(out var xOffset)
                .TryRead<short>(out var zOffset)
                .TryRead<short>(out var yOffset);
            position.XOffset = xOffset;
            position.YOffset = yOffset;
            position.ZOffset = zOffset;
        }
        else
        {
            packet.TryRead<int>(out var xOffset)
                .TryRead<int>(out var zOffset)
                .TryRead<int>(out var yOffset);
            position.XOffset = xOffset;
            position.YOffset = yOffset;
            position.ZOffset = zOffset;
        }

        if (parseLayerWorldId)
            packet.TryRead(out position.WorldId)
                .TryRead(out position.LayerId);

        return position;
    }

    public Position ToPacketConditional(Packet packet, bool parseLayerWorldId = true)
    {
        packet.TryWrite(Region);

        if (!Region.IsDungeon)
        {
            packet.TryWrite((short)XOffset);
            packet.TryWrite((short)ZOffset);
            packet.TryWrite((short)YOffset);
        }
        else
        {
            packet.TryWrite((int)XOffset);
            packet.TryWrite((int)ZOffset);
            packet.TryWrite((int)YOffset);
        }

        if (parseLayerWorldId)
        {
            packet.TryWrite(WorldId);
            packet.TryWrite(LayerId);
        }

        return this;
    }

    public bool IsEmpty()
    {
        return X == 0 && Y == 0 && ZOffset == 0;
    }

    public byte GetSectorFromOffset(float offset)
    {
        return (byte)((128.0 * 192.0 + (128 * 192 + offset / 10)) / 192.0 - 128);
    }

    public override string ToString()
    {
        return $"X:{X:0.0} Y:{Y:0.0}";
    }
}