using SilkroadSecurityAPI.Message;

namespace PacketLibrary.Global.Objects;

public class HostAndPort
{
    public string Host;
    public ushort Port;

    public HostAndPort(Packet packet)
    {
        packet.TryRead(out Host)
            .TryRead(out Port);
    }

    public HostAndPort(string host, ushort port)
    {
        Host = host;
        Port = port;
    }

    public virtual Packet Build(Packet packet)
    {
        packet.TryWrite(Host)
            .TryWrite(Port);

        return packet;
    }
}