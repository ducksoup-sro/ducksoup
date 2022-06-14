using SilkroadSecurityAPI;

namespace PacketLibrary.Objects.Gateway;

public class HostAndPort
{
    
    public string Host { get; set; }
    public ushort Port { get; set; }

    public HostAndPort(Packet packet)
    {
        Host = packet.ReadAscii();
        Port = packet.ReadUInt16();
    }
    
    public HostAndPort(string host, ushort port)
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