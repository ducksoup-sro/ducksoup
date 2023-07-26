using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Download.Client;

// https://github.com/DummkopfOfHachtenduden/SilkroadDoc/wiki/DOWNLOAD_FILE
public class CLIENT_DOWNLOAD_FILE_REQUEST : Packet
{
    public uint Id; // 4   uint    ID

    public uint Unk2; //4   uint    unk2
    //Drew: "Might be the high word of the id, that's just not implemented"

    public CLIENT_DOWNLOAD_FILE_REQUEST() : base(0x6004)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;
    public override PacketDirection ToDirection => PacketDirection.Server;

    public override async Task Read()
    {
        TryRead(out Id)
            .TryRead(out Unk2);
    }

    public override async Task<Packet> Build()
    {
        Reset();
        TryWrite(Id);
        TryWrite(Unk2);
        return this;
    }

    public static Packet of(uint id, uint unk2)
    {
        return new CLIENT_DOWNLOAD_FILE_REQUEST
        {
            Id = id,
            Unk2 = unk2
        };
    }
}