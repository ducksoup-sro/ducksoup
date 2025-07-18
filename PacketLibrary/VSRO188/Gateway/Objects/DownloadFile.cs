using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Objects;

public class DownloadFile
{
    public readonly uint Id;
    public readonly uint Length;
    public readonly string Name;
    public readonly string Path;
    public readonly bool ToBePacket;

    public DownloadFile(Packet packet)
    {
        packet.TryRead(out Id)
            .TryRead(out Name)
            .TryRead(out Path)
            .TryRead(out Length)
            .TryRead(out ToBePacket);

        // ID = packet.ReadUInt32(); // 4	uint	file.ID
        // // 2	ushort	file.Name.Length		
        // //     *	string	file.Name
        // Name = packet.ReadAscii();
        // // 2	ushort	file.Path.Length
        // //     *	string	file.Path
        // Path = packet.ReadAscii();
        // Length = packet.ReadUInt32(); // 4	uint	file.Length //in bytes
        // ToBePacket = packet.ReadBool(); // 1	bool	file.ToBePacked //into pk2
    }

    public DownloadFile(uint id, string name, string path, uint length, bool toBePacket)
    {
        Id = id;
        Name = name;
        Path = path;
        Length = length;
        ToBePacket = toBePacket;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite(Id)
            .TryWrite(Name)
            .TryWrite(Path)
            .TryWrite(Length)
            .TryWrite(ToBePacket);

        // packet.WriteUInt32(ID);
        // packet.WriteAscii(Name);
        // packet.WriteAscii(Path);
        // packet.WriteUInt32(Length);
        // packet.WriteBool(ToBePacket);
        return packet;
    }
}