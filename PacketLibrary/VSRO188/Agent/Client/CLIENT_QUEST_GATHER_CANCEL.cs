using SilkroadSecurityAPI.Message;

namespace PacketLibrary.VSRO188.Agent.Client;

public class CLIENT_QUEST_GATHER_CANCEL : Packet
{
    public CLIENT_QUEST_GATHER_CANCEL() : base(0x70DB)
    {
    }

    public override PacketDirection FromDirection => PacketDirection.Client;

    public override PacketDirection ToDirection => PacketDirection.Server;


    public override async Task Read()
    {
        //throw new NotImplementedException();
    }

    public override async Task<Packet> Build()
    {
        //throw new NotImplementedException();

        //Reset();

        return this;
    }

    public static Packet of()
    {
        return new CLIENT_QUEST_GATHER_CANCEL();
    }
}