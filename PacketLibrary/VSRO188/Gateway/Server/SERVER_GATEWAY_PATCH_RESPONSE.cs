using PacketLibrary.Global.Objects;
using PacketLibrary.VSRO188.Gateway.Enums;
using PacketLibrary.VSRO188.Gateway.Objects;
using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Server;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_PATCH#response
public class SERVER_GATEWAY_PATCH_RESPONSE : Packet
{
    public uint CurVersion;
    public HostAndPort DownloadServer;
    public PatchErrorCode ErrorCode;
    public List<DownloadFile> Files = new();

    public byte Result;

    public SERVER_GATEWAY_PATCH_RESPONSE() : base(0xA100, false, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Server;
    public override PacketDirection ToDirection => PacketDirection.Client;

    public override async Task Read()
    {
        TryRead(out Result);
        if (Result == 0x02)
        {
            TryRead(out ErrorCode);
            if (ErrorCode == PatchErrorCode.Update)
            {
                DownloadServer = new HostAndPort(this);
                TryRead(out CurVersion);

                while (true)
                {
                    TryRead<bool>(out var hasEntries); // 1	bool hasEntries
                    if (!hasEntries)
                        break;
                    Files.Add(new DownloadFile(this));
                }
            }
        }
    }

    public override async Task<Packet> Build()
    {
        Reset();

        TryWrite(Result);
        if (Result == 0x02)
        {
            TryWrite(ErrorCode);
            if (ErrorCode == PatchErrorCode.Update)
            {
                DownloadServer.Build(this);
                TryWrite(CurVersion);

                foreach (var downloadFile in Files)
                {
                    TryWrite(true);
                    downloadFile.Build(this);
                }

                TryWrite(false);
            }
        }

        return this;
    }

    public static Packet of()
    {
        return new SERVER_GATEWAY_PATCH_RESPONSE();
    }
}