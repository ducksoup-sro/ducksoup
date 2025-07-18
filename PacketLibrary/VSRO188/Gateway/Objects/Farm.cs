using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class Farm
{
    public readonly byte Id;
    public readonly string Name;

    public Farm(Packet packet)
    {
        packet.TryRead(out Id)
            .TryRead(out Name);
        // // 1   byte    farm.ID 
        // ID = packet.ReadUInt8();
        // // 2   ushort  farm.Name.Length
        // //     *   string  farm.Name 
        // Name = packet.ReadAscii();
    }

    public Farm(byte id, string name)
    {
        Id = id;
        Name = name;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Id)
            .TryWrite(Name);

        // packet.WriteUInt8(ID);
        // packet.WriteAscii(Name);
        return packet;
    }
}