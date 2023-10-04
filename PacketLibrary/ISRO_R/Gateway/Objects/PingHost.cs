using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Objects;

public class PingHost
{
    public string Host;

    /**
     * 0    0    interface\outer\login_window_eu_located_ckorea.ddj
     * 0    1    interface\outer\login_window_eu_located_eu.ddj
     * 0    2    interface\outer\login_window_eu_located_cusa.ddj
     * 0    3    interface\outer\login_window_eu_located_union.ddj
     * Media\server_dep\silkroad\textdata\countryimage.txt
     */
    public byte NationId;

    public ushort Port;

    public PingHost(Packet packet)
    {
        packet.TryRead(out NationId)
            .TryRead(out Host)
            .TryRead(out Port);
    }

    public PingHost(byte nationId, string host, ushort port)
    {
        NationId = nationId;
        Host = host;
        Port = port;
    }

    public Packet Build(Packet packet)
    {
        packet.TryWrite(NationId)
            .TryWrite(Host)
            .TryWrite(Port);

        return packet;
    }
}