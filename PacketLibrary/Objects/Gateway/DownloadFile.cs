using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class DownloadFile
{
    public uint ID { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public uint Length { get; set; }
    public bool ToBePacket { get; set; }

    public DownloadFile(Packet packet)
    {
        ID = packet.ReadUInt32(); // 4	uint	file.ID
        // 2	ushort	file.Name.Length		
        //     *	string	file.Name
        Name = packet.ReadAscii();
        // 2	ushort	file.Path.Length
        //     *	string	file.Path
        Path = packet.ReadAscii();
        Length = packet.ReadUInt32(); // 4	uint	file.Length //in bytes
        ToBePacket = packet.ReadBool(); // 1	bool	file.ToBePacked //into pk2
    }

    public DownloadFile(uint id, string name, string path, uint length, bool toBePacket)
    {
        ID = id;
        Name = name;
        Path = path;
        Length = length;
        ToBePacket = toBePacket;
    }

    public Packet build(Packet packet)
    {
        packet.WriteUInt32(ID);
        packet.WriteAscii(Name);
        packet.WriteAscii(Path);
        packet.WriteUInt32(Length);
        packet.WriteBool(ToBePacket);
        
        return packet;
    }
}