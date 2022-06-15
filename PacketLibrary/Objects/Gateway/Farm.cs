using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class Farm
{
    public byte ID { get; set; }
    public string Name { get; set; }

    public Farm(Packet packet)
    {
        // 1   byte    farm.ID 
        ID = packet.ReadUInt8();
        // 2   ushort  farm.Name.Length
        //     *   string  farm.Name 
        Name = packet.ReadAscii();
    }

    public Farm(byte id, string name)
    {
        ID = id;
        Name = name;
    }

    public Packet build(Packet packet)
    {
        packet.WriteUInt8(ID);
        packet.WriteAscii(Name);

        return packet;
    }
}