using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Gateway.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/GATEWAY_PATCH#request
public class CLIENT_GATEWAY_PATCH_REQUEST : Packet
{
    public byte ContentId;
    public string ModuleName;
    public uint Version;

    public CLIENT_GATEWAY_PATCH_REQUEST() : base(0x6100, true)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out ContentId)
            .TryRead(out ModuleName)
            .TryRead(out Version);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(ContentId);
        TryWrite(ModuleName);
        TryWrite(Version);
        return this;
    }

    public static Packet of(byte contentId, string moduleName, uint version)
    {
        return new CLIENT_GATEWAY_PATCH_REQUEST
        {
            ContentId = contentId,
            ModuleName = moduleName,
            Version = version
        };
    }
}