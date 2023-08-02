using PacketLibrary.ISRO_R.Gateway.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.ISRO_R.Gateway.Server;

public class SERVER_GATEWAY_PING_LIST_RESPONSE : Packet
{
    /// <summary>
    /// Probably answer onto 0x6107 <see cref="SERVER_GATEWAY_PING_LIST_RESPONSE"/>
    /// </summary>
    public SERVER_GATEWAY_PING_LIST_RESPONSE() : base(0xA107, false, false)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public byte Count;
    public List<PingHost> PingHosts = new List<PingHost>();
    
    public async override Task Read()
    {
        // 0000000000   03 01 0B 00 31 30 2E 33 2E 31 30 2E 32 30 30 BD   ....10.3.10.200½
        // 0000000016   32 01 0B 00 31 30 2E 33 2E 31 30 2E 32 30 30 BD   2...10.3.10.200½
        // 0000000032   32 01 0B 00 31 30 2E 33 2E 31 30 2E 32 30 30 BD   2...10.3.10.200½
        // 0000000048   32                                                2...............

        TryRead<byte>(out Count);
        for (int i = 0; i < Count; i++)
        {
            PingHosts.Add(new PingHost(this));
        }
    }

    public async override Task<Packet> Build()
    {
        Reset();
        
        TryWrite<byte>(Count);
        foreach (var pingHost in PingHosts)
        {
            pingHost.Build(this);
        }
        
        return this;
    }
}