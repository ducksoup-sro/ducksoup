using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class DownloadFile
{
    public string Host { get; set; }
    public ushort Port { get; set; }

    public DownloadFile(Packet packet)
    {
       // 4	uint	file.ID
       // 2	ushort	file.Name.Length			
       //     *	string	file.Name
       // 2	ushort	file.Path.Length
       //     *	string	file.Path
       // 4	uint	file.Length //in bytes
       // 1	bool	file.ToBePacked //into pk2
    }

    public DownloadFile(string host, ushort port)
    {
        Host = host;
        Port = port;
    }

    public Packet build(Packet packet)
    {
        packet.WriteAscii(Host);
        packet.WriteUInt16(Port);

        return packet;
    }
}