using PacketLibrary.VSRO188.Gateway.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_NOTICE#response
public class SERVER_GATEWAY_NOTICE_RESPONSE : Packet
{
    public byte Count;
    public List<Notice> Notices = new();

    public SERVER_GATEWAY_NOTICE_RESPONSE() : base(0xA104)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Count);
        for (var i = 0; i < Count; i++) Notices.Add(new Notice(this));
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Count);
        foreach (var notice in Notices) notice.Build(this);
        return this;
    }

    public static SERVER_GATEWAY_NOTICE_RESPONSE of(List<Notice> notices)
    {
        return new SERVER_GATEWAY_NOTICE_RESPONSE
        {
            Count = (byte)notices.Count,
            Notices = notices
        };
    }

    public static Packet of(Notice notice)
    {
        return new SERVER_GATEWAY_NOTICE_RESPONSE
        {
            Count = 1,
            Notices = new List<Notice> { notice }
        };
    }
}